using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeFolder.Entities
{
    public class Configuration
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LocalPath { get; set; }

        public string ServicePath { get; set; }

        public bool IsDefault { get; set; }
    }
}
