namespace DevTrackR.API.Entities
{
    public class PackageUpdate
    {
        public PackageUpdate(string status, int packageId)
        {
            Status = status;
            PackageId = packageId;
        }

        public int Id { get; private set; }
        public int PackageId { get; private set; }
        public string Status { get; private set; }
    }
}