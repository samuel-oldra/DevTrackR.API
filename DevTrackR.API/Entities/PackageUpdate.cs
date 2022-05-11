namespace DevTrackR.API.Entities
{
    public class PackageUpdate
    {
        public int Id { get; private set; }

        public string Status { get; private set; }

        public int PackageId { get; private set; }

        public PackageUpdate(string status, int packageId)
        {
            Status = status;
            PackageId = packageId;
        }
    }
}