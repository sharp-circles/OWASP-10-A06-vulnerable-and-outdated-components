using AutoMapper;
using owasp10.A03.business.Entities;

namespace owasp10.A03.data.access.Repositories;

public class SqLiteRepositoryProfile : Profile
{
    public SqLiteRepositoryProfile()
    {
        CreateMap<MedicalHistory, Tables.MedicalHistory>();
        CreateMap<Tables.MedicalHistory, MedicalHistory>();
        CreateMap<Tests, Tables.Tests>();
        CreateMap<Tables.Tests, Tests>();
    }
}
