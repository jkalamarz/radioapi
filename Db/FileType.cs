using System;
using System.Collections.Generic;

namespace radioapi.Db
{
    public partial class FileType
    {
        public FileType()
        {
            File = new HashSet<File>();
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public string Ext { get; set; }
        public string Description { get; set; }

        public ICollection<File> File { get; set; }
    }
}
