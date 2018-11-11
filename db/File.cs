using System;
using System.Collections.Generic;

namespace radioapi.db
{
    public partial class File
    {
        public File()
        {
            InverseRadio = new HashSet<File>();
        }

        public DateTime? CreatedOn { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public string PathMp3 { get; set; }
        public string PathNoads { get; set; }
        public string PathAac { get; set; }
        public int? RadioId { get; set; }

        public File Radio { get; set; }
        public ICollection<File> InverseRadio { get; set; }
    }
}
