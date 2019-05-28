using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileSharing.Models
{
    public class AplicationFile
    {
        public int Id { get; private set; }
        public string NameFile { get; set; }
        public DateTime DateFIle { get; set; }
        public int FileCountDownload { get; set; }
        public string FileShortKey { get; set; }
        public string DiscriptionFile { get; set; }
        public string ShortDiscriptionFile { get; set; }
        public string Password { get; set; }
        public int DayCount { get; set; }
        public FileType Type { get; set; }
        public string FilePath;
    }

    public enum FileType
    {
        SimpleFile,
        WhithPasswordFile,
        CountableFile,
        DateFile
    }
}
