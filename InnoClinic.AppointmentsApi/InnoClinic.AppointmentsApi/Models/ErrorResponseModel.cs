namespace InnoClinic.AppointmentsApi.Models
{
    public sealed class ErrorResponseModel
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
