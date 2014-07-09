using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeFolder.Entities
{
    public class Owner
    {
        #region Member Variables
        private List<Configuration> _configs = new List<Configuration>();
        #endregion

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public List<Configuration> Configurations 
        { 
            get { return _configs; } 
            set { _configs = value; } 
        }
    }
}
