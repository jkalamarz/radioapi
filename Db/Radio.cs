using System;
using System.Collections.Generic;

namespace radioapi.Db
{
    public partial class Radio
    {
        public Radio()
        {
            FileOld = new HashSet<FileOld>();
            Program = new HashSet<Program>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string StreamUrl { get; set; }

        public ICollection<FileOld> FileOld { get; set; }
        public ICollection<Program> Program { get; set; }
    }
}
