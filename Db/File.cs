using System;
using System.Collections.Generic;

namespace radioapi.Db
{
    public partial class File
    {
        public int Id { get; set; }
        public int ProgramId { get; set; }
        public int FileTypeId { get; set; }
        public string Path { get; set; }

        public FileType FileType { get; set; }
        public Program Program { get; set; }
    }
}
