namespace DevTrackR.API.Models
{
    public class AddPackageInputModel
    {
        public string Title { get; set; } = string.Empty;

        public decimal Weight { get; set; }

        public string SenderName { get; set; } = string.Empty;

        public string SenderEmail { get; set; } = string.Empty;
    }
}