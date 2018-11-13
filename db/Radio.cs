using System;
using System.Collections.Generic;

namespace radioapi.db
{
    public partial class Radio
    {
        public Radio()
        {
            File = new HashSet<File>();
        }

        public string Name { get; set; }
        public string StreamUrl { get; set; }
        public int Id { get; set; }

        public ICollection<File> File { get; set; }
    }
}
