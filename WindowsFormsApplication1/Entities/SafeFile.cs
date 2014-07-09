using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeFolder.Entities
{
    public class SafeFile
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }

        public bool CanCopy { get; set; }

        public bool CanDelete { get; set; }

        public bool CanModify { get; set; }

        public bool CanForward { get; set; }
    }
}
