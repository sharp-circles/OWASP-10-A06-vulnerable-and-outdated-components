# OWASP TOP 10 - A06: Vulnerable and Outdated Components

Using the native OWASP Dependency Check tool with the docker approach to analyze vulnerabilities in a .NET web application

This repository serves as a practical lab to explore and address the OWASP TOP 10's sixth position: **Vulnerable and Outdated Components**. This lab uses a .NET project and the **OWASP Dependency-Check** tool to perform a Software Composition Analysis (SCA) and identify known vulnerabilities in third-party libraries.

---

## What is Dependency-Check? 🔎

Dependency-Check is a free SCA tool provided by the OWASP foundation. It analyzes project dependencies and their nested components to identify publicly disclosed vulnerabilities. The tool works by:

* **Collecting Evidence**: It inspects dependencies and gathers information, or "evidence."
* **CPE Matching**: It attempts to match this evidence to a **Common Platform Enumeration (CPE)**, a structured naming scheme for software, hardware, and operating systems.
* **CVE Retrieval**: If a match is found, the tool retrieves a list of associated **Common Vulnerability and Exposure (CVE)** items from databases like the National Vulnerability Database (NVD).

---

## Installation and Execution 🛠️

The primary method for running Dependency-Check is via its command-line interface (CLI). However, a common issue is the dependency on a local Java installation. To avoid this, we'll use a **Dockerized approach** for a cleaner and more portable setup.

### Prerequisites

* Docker installed on your system.
* The .NET project to be scanned.

### The Docker Launcher Script

A custom Windows batch script (`.bat`) is used to manage the Docker execution. This script automates several key steps:

* Creates persistent directories for the NVD database and cache, ensuring faster subsequent scans.
* Pulls the latest Dependency-Check Docker image.
* Mounts volumes to connect the local project source code, data directories, and report output folder to the Docker container.
* Executes the scan and generates reports in various formats.

### Custom Script for Windows

Below is the modified Windows batch script (`.bat`) used in this lab. It places the persistent `data` and `cache` folders inside the project's root directory, keeping everything in one place.

```batch
@echo offset DC_VERSION="latest"
SET DC_PROJECT="dependency-check scan: %CD%"
set DATA_DIRECTORY="%CD%\data"
set CACHE_DIRECTORY="%CD%\data\cache"

IF NOT EXIST %DATA_DIRECTORY% (
    echo Initially creating persistent directory: %DATA_DIRECTORY%
    mkdir %DATA_DIRECTORY%
)
IF NOT EXIST %CACHE_DIRECTORY% (
    echo Initially creating persistent directory: %CACHE_DIRECTORY%
    mkdir %CACHE_DIRECTORY%
)

rem Make sure we are using the latest version
docker pull owasp/dependency-check:%DC_VERSION%

docker run --rm ^
    --volume %CD%:/src ^
    --volume %DATA_DIRECTORY%:/usr/share/dependency-check/data ^
    --volume %CD%/odc-reports:/report ^
    owasp/dependency-check:%DC_VERSION% ^
    --scan /src ^
    --format "ALL" ^
    --project "%DC_PROJECT%" ^
    --out /report
    rem Use suppression like this: (where /src == %CD%)
    rem --suppression "/src/security/dependency-check-suppression.xml"
````

To run the scan, place this script in the root of your project directory and execute it from the command line.

-----

## Scan Results and Findings ⚠️

The scan on the sample .NET project identified several vulnerabilities. The most significant finding was the presence of **25 CVEs** associated with the **`sqlite-net`** package.

### Notable Vulnerabilities Found

The generated HTML report provided detailed information on each finding. Here's a brief breakdown of a few key CVEs discovered in the `sqlite-net` package:

  * **CVE-2017-10989**: A heap-based buffer over-read due to mishandling of RTree blobs. This could lead to a denial of service or unauthorized data access.
      * **CWE**: [CWE-125: Out-of-bounds Read](https://cwe.mitre.org/data/definitions/125.html)
  * **CVE-2018-20346**: An integer overflow and resultant buffer overflow in the FTS3 extension. This could allow remote attackers to execute arbitrary code.
      * **CWE**: [CWE-190: Integer Overflow or Wraparound](https://cwe.mitre.org/data/definitions/190.html)
  * **CVE-2016-6153**: Improper temporary directory handling, which could lead to information disclosure or a denial-of-service attack.
      * **CWE**: [CWE-20: Improper Input Validation](https://cwe.mitre.org/data/definitions/20.html)

### Key Observations

  * **NVD API Key**: The initial run of the tool downloads a massive amount of vulnerability data from the NVD, which can be time-consuming. The output warned that using an **NVD API Key** is highly recommended to speed up this process and avoid rate limiting.
  * **Persistent Cache**: The persistent `data` and `cache` directories are crucial. They allow the tool to store the downloaded NVD data locally, so subsequent scans only require incremental updates, drastically reducing the analysis time.

-----

## Recommendations for a Secure Workflow ✅

  * **Automate SCA Scans**: Integrate tools like Dependency-Check into your CI/CD pipeline to automatically scan for vulnerabilities with every build.
  * **Use an NVD API Key**: For production and regular use, obtain an NVD API key to ensure efficient and reliable access to vulnerability data.
  * **Maintain Up-to-Date Dependencies**: The scan results clearly show the risk of using outdated libraries. Regularly update your third-party components to their latest, most secure versions.
  * **Review Reports**: Don't just run the scan; actively review the reports to understand the risks and prioritize remediation efforts.

## Source article

https://sharpcircles.org/post/wtm16-owasp-10-a06-vulnerable-and-outdated-components-lab-analysis-of
