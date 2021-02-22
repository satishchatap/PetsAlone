namespace PetsAlone.Mvc.Models
{
    public class ErrorViewModel
    {
        public string Error { get; set; } = string.Empty;
        public string RequestId { get; set; } = string.Empty;

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}