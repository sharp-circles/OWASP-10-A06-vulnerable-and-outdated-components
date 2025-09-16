namespace owasp10.A03.business.UseCases.GetUserMedicalHistoryRecords.Dtos;

public record GetUserMedicalHistoryRecordsInput
{
    public string Username { get; set; }
}