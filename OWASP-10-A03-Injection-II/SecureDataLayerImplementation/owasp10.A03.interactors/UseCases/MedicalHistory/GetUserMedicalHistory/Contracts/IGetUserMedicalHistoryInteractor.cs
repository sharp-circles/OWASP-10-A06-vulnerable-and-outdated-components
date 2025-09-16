using owasp10.A03.business.UseCases.GetUserMedicalHistory.Dtos;

namespace owasp10.A03.business.UseCases.GetUserMedicalHistory.Contracts;

public interface IGetUserMedicalHistoryInteractor
{
    Task<GetUserMedicalHistoryOutput> Handle(GetUserMedicalHistoryInput getUserMedicalHistoryInput);
}
