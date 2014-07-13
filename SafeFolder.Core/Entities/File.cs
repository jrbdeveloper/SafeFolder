
using System.Collections.Generic;

namespace SafeFolder.Core.Entities
{
    public class File
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public bool CanCopy { get; set; }

        public bool CanForward { get; set; }

        public List<FileRecipient> FileRecipients { get; set; }
    }
}
