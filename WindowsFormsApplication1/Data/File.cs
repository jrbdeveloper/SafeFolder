//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SafeFolder.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class File
    {
        public File()
        {
            this.FileRecipients = new HashSet<FileRecipient>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public bool CanCopy { get; set; }
        public bool CanDelete { get; set; }
        public bool CanModify { get; set; }
        public bool CanForward { get; set; }
    
        public virtual ICollection<FileRecipient> FileRecipients { get; set; }
    }
}
