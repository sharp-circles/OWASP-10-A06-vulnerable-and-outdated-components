namespace owasp10.A03.business.Entities;

public class MedicalHistory : Entity
{
    public long UserId { get; set; }
    public string UserName { get; set; }
    public sbyte Age { get; set; }
    public string Treatment { get; set; }
    public string Affection { get; set; }
    public bool UndergoneSurgery { get; set; }
}
