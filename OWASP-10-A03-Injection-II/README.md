# OWASP-10-A03-Injection-II

Second lab for the two deliveries series on the OWASP injection segment

### Structure

The following lab provides a full web application scaffolding with a special separation at the data access layer, proposing one secure implementation in contrast of a vulnerable one.

The main parts or layers are:

1. API/Controllers
2. Business interactors. The core policy
3. The data access layer, divided in two

Clean architecture concepts have been applied to arrange the dependencies in the most compliant way. This diagram explains the overview of the layout.

<img src="https://github.com/sharp-circles/OWASP-10-A03-Injection-II/blob/main/Diagrams/architecture-diagram.png" alt="Architecture diagram" />

#### Attacks and payloads

This lab is based on SQL injection, as mentioned. The main content is divided in two steps:

1. Regular injection. This one consists in the most classic SQL injection with alphanumeric output.
2. Blind injection. This other one portraits a landscape a bit more challenging. The output in this case is **numeric**, so there's some translation to be done after the successful execution.

The structure is divided in different folders for comprehension.

For further understanding, you can take a look at the snapshots, as well as the article on the official site.

Happy hacking.
