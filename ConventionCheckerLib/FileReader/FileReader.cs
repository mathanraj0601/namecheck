using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CLI.FileReader
{
    public class FileReader
    {
        public List<string> files { get; set; }
        public FileReader()
        {
            files = new List<string>();
        }

        public void ReadFileByFullPath(string path)
        {
            if (Regex.IsMatch(path,"^*.cs$"))
                 files.Add(path);
        }

        public void ReadFile(string path)
        {
            if (Regex.IsMatch(path, "^*.cs$"))
                files.Add($"{Environment.CurrentDirectory}\\{path}");
        }


        public void ReadFilesByDirectory(string path)
        {
            string[] fileEntries = Directory.GetFiles(path,"*.cs");
            foreach (string fileName in fileEntries)
            {
                files.Add(fileName);
            }
        }

        public void ReadFilesByDirectoryRecursively(string path)
        {
            string[] fileEntries = Directory.GetFiles(path, "*.cs");
            string[] dirEntries = Directory.GetDirectories(path);
            foreach (string dirName in dirEntries)
            {
                ReadFilesByDirectoryRecursively(dirName);
            }
            foreach (string fileName in fileEntries)
            {
                   files.Add(fileName);
            }
        }
    }
}

