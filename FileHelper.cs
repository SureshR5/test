using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CsvHelper.Configuration;

namespace MaturityData.DataLoader
{
    public class FileHelper: IFileHelper
    {
        public IList<LipperDataFile> GetFiles(string directory)
        {
            var lipperFiles = new List<LipperDataFile>();
            var dataFiles = new DirectoryInfo(directory).GetFiles("*", SearchOption.AllDirectories);
           if(dataFiles.Any())
            {
                lipperFiles = dataFiles.Select(
                    f =>
                    new LipperDataFile
                    {
                        Name = Path.GetFileNameWithoutExtension(f.Name)
                    }).ToList();
            }
            return lipperFiles;
        }

        public void MoveFile(string sourceFile, string destinationDirectory, string destinationFile)
        {
            if(!Directory.Exists(destinationDirectory))
            {
                Directory.CreateDirectory(destinationDirectory);
            }

            if(File.Exists(destinationDirectory + "\\"+ destinationFile))
            {
                File.Delete(destinationDirectory + "\\" + destinationFile);
            }

            File.Move(sourceFile, destinationDirectory + "\\" + destinationFile);

            var config = new CsvConfiguration();
            config.Delimiter = ",";
            config.HasHeaderRecord = false;

            ////var dd = new DataLoader<>(config);
            ////dd.Load();
            ////dd.Read();
            ////dd.Records.foreach()

        }

    }
}
