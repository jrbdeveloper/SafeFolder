namespace SafeFolder.Core.Entities
{
    public class File
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public bool CanCopy { get; set; }
        
        public bool CanDelete { get; set; }

        public bool CanModify { get; set; }
        
        public bool CanForward { get; set; }
    }
}
