using AutoMapper;
using owasp10.A03.business.UseCases.GetUserMedicalHistoryRecords.Dtos;

namespace owasp10.A03.business.UseCases.MedicalHistory.GetUserMedicalHistoryRecords;

public class GetUserMedicalHistoryRecordsProfile : Profile
{
    public GetUserMedicalHistoryRecordsProfile()
    {
        CreateMap<Entities.MedicalHistory, GetUserMedicalHistoryRecordsOutput>();
    }
}
