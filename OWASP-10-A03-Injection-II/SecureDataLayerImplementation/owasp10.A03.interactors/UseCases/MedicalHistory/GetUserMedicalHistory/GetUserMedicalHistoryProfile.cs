using AutoMapper;
using owasp10.A03.business.UseCases.GetUserMedicalHistory.Dtos;

namespace owasp10.A03.business.UseCases.MedicalHistory.GetUserMedicalHistory;

public class GetUserMedicalHistoryProfile : Profile
{
    public GetUserMedicalHistoryProfile()
    {
        CreateMap<Entities.MedicalHistory, GetUserMedicalHistoryOutput>();
    }
}
