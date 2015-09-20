using FileManager.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FileManager.Helpers
{
    public class FileManager
    {
        private static FileManager _instance;

        public static FileManager Instance
        {
            get
            {
                if (_instance == null) _instance = new FileManager();
                return _instance;
            }

        }

        private FileManager()
        { }

        private IEnumerable<FileInfo> fileInfo;

        public FileBrowsingModel GetBaseDirectoryFiles()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;

            return GetFiles(baseDir);
        }

        public FileBrowsingModel GetFiles(string path)
        {
            if (!String.IsNullOrEmpty(path) && !Directory.Exists(path))
                throw new Exception("Directory not found");

            String parentDir = String.Empty;

            var path1 = Path.GetFullPath(path+"\\");
            var path2 = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory);


            if (!string.Equals(path1, path2, StringComparison.OrdinalIgnoreCase))
            { 
                parentDir = Directory.GetParent(path).FullName;
            }

         
            var model = new FileBrowsingModel()
            {
                CurrentPath = path,
                UpPath = parentDir
            };

            fileInfo = new DirectoryInfo(path).GetFiles("*", SearchOption.AllDirectories);

            model.LessThen10MbCount = LessThan10();

            model.Beetween10and50MbCount = Beetween10and50();

            model.More100MbCount = More100();

            model.Files = new DirectoryInfo(path).EnumerateFileSystemInfos()
                                                 .Select(x => x.Name)
                                                 .ToList();
            return model;
        }

        private int LessThan10()
        {
            int Less10Mb = 10 * 1024 * 1024;

            var count = fileInfo.Where(x => x.Length <= Less10Mb).Count();

            return count;
        }

        private int Beetween10and50()
        {
            int Less10Mb = 10 * 1024 * 1024;
            int To50Mb = 50 * 1024 * 1024;


            var count = fileInfo.Where(x => x.Length >= Less10Mb && x.Length <= To50Mb).Count();
            return count;
        }

        private int More100()
        {
            int More100Mb = 100 * 1024 * 1024;

            var count = fileInfo.Where(x => x.Length >= More100Mb).Count();

            return count;
        }
    }
}