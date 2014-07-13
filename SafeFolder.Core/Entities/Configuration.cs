namespace SafeFolder.Core.Entities
{
    public class Configuration
    {
        public string Name { get; set; }
        
        public string LocalFilePath { get; set; }
        
        public string ServicePath { get; set; }
        
        public bool IsDefault { get; set; }

        public OwnerProfile OwnerProfile { get; set; }
    }
}
