using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace MaturityData.DataLoader
{
    public interface IDataLoader<TModel>
        where TModel : class
    {
        string Header { get; }

        int RecordCount { get; }

        IList<TModel> Records { get; }

        void Load(string filepath);
        void Read();
        void Load(ICsvReader reader);
        void dispose();

    }
}
