using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeFolder.Classes
{
    public class EncryptionService
    {
        public string FileLocation { get; set; }

        public void EncryptFile() 
        {
            File.Encrypt(FileLocation);
        }

        public void DecryptFile() 
        {
            File.Decrypt(FileLocation);
        }
    }
}
