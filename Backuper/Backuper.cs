using System;
using System.IO;

using Backuper.Interfaces;

namespace Backuper
{
    public class Backuper : IBackuper
    {
        private readonly string _pathFrom;
        private readonly string _pathTo;
        private readonly string _directory;
        
        public Backuper(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                //to do something
            }

            var hashName = path + "_" + Math.Abs((path + DateTime.Now).GetHashCode());
            hashName = hashName.Remove(0, hashName.LastIndexOf('\\'));

            _pathFrom = path;
            _directory = Environment.CurrentDirectory + @"\Backup";
            _pathTo =  _directory + hashName;
        }

        public void Backup()
        {
            if (!Directory.Exists(_pathTo))
            {
                Directory.CreateDirectory(_directory);
            }

            File.Copy(_pathFrom, _pathTo, true);
        }
    }
}
