using System;
using System.Collections.Generic;

namespace radioapi.Db
{
    public partial class Program
    {
        public Program()
        {
            File = new HashSet<File>();
        }

        public int Id { get; set; }
        public int RadioId { get; set; }
        public DateTime Timestamp { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }

        public Radio Radio { get; set; }
        public ICollection<File> File { get; set; }
    }
}
