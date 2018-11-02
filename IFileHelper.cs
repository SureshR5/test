using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaturityData.DataLoader
{
    public interface IFileHelper
    {
        IList<LipperDataFile> GetFiles(string directory);
        void MoveFile(string sourceFile, string destinationDirectory, string destinationFile);
    }
}
