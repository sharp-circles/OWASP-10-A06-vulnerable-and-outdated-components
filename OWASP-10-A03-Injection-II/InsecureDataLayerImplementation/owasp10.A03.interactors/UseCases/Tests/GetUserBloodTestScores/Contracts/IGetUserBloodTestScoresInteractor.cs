using owasp10.A03.business.UseCases.Tests.GetUserBloodTestScores.Dtos;

namespace owasp10.A03.business.UseCases.Tests.GetUserBloodTestScores.Contracts;

public interface IGetUserBloodTestScoresInteractor
{
    Task<IEnumerable<GetUserBloodTestScoresOutput>> Handle(GetUserBloodTestScoresInput getUserBloodTestScoresInput);
}
