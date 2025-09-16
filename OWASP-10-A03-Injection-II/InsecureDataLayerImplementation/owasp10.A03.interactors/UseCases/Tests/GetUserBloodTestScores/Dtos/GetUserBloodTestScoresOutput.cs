namespace owasp10.A03.business.UseCases.Tests.GetUserBloodTestScores.Dtos;

public record GetUserBloodTestScoresOutput()
{
    public int UserId { get; set; }
    public int Score { get; set; }
}