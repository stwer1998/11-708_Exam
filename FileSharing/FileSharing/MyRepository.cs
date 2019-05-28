using FileSharing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FileSharing
{
    public class MyRepository
    {
        private MyDbContext db;
        public MyRepository()
        {
            db = new MyDbContext();
        }
        public AplicationFile SaveSimpleFile(string shortdescription, string description,string filename,string path1,string path2)
        {
            string key = GetUniqueKey(6);
            bool b = Cheker(key);
            while (b)
            {
                key = GetUniqueKey(6);
            }

            AplicationFile file = new AplicationFile
            {
                NameFile = filename,
                DiscriptionFile = description,
                ShortDiscriptionFile = shortdescription,
                FileCountDownload = 0,
                Type = FileType.SimpleFile,
                FileShortKey = key,
                FilePath=path1+key+path2
            };
            db.aplicationFiles.Add(file);
            return file;
        }

        public AplicationFile GetFile(string key)
        {
            var a=db.aplicationFiles.FirstOrDefault(x=>x.FileShortKey==key);
            return a;
        }

        private string GetUniqueKey(int size)
        {
            char[] chars =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            byte[] data = new byte[size];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetBytes(data);
            }
            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }

        private bool Cheker(string str)
        {
            var f = db.aplicationFiles.FirstOrDefault(x => x.FileShortKey == str);
            if (f!=null&& f.FileShortKey != str) { return true; }
            else return false;
        }

    }
}
