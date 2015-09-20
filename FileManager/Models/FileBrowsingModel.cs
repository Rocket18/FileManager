using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileManager.Models
{
    public class FileBrowsingModel
    {
        public int LessThen10MbCount { get; set; }

        public int Beetween10and50MbCount { get; set; }

        public int More100MbCount { get; set; }

        public string CurrentPath { get; set; }

        public string UpPath { get; set; }

        public List<string> Files { get; set; }
    }
}