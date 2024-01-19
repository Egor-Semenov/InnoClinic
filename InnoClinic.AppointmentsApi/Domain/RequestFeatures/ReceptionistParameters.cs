namespace Domain.RequestFeatures
{
    public sealed class ReceptionistParameters : RequestParameters
    {
        public int OfficeId { get; set; }
        public string? SearchTerm { get; set; }
    }
}
