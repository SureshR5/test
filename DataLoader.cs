namespace MaturityData.DataLoader
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CsvHelper;
    using CsvHelper.Configuration;

    public class DataLoader<TModel> : IDataLoader<TModel>, IDisposable
        where TModel : class
    {
        private const int HeaderRecordCount = 3;

        private readonly CsvConfiguration csvConfiguration;

        private ICsvReader csvReader;

        public DataLoader(CsvConfiguration csvConfiguration)
        {
            this.csvConfiguration = csvConfiguration;
        }

        public string Header { get; private set; }

        public int RecordCount { get; private set; }

        public IList<TModel> Records { get; private set; }

        public void Load(string filePath)
        {
            this.RecordCount = File.ReadLines(filePath).Count() - HeaderRecordCount;
            var reader = new StreamReader(filePath, Encoding.Default);
            this.SetHeader(reader.ReadLine());
            this.Load(new CsvReader(reader, this.csvConfiguration));
        }

        public void Load(ICsvReader reader){
            this.csvReader = reader;
        }

        public void Read()
        {
            var readLine = 0;
            this.Records = new List<TModel>();

            while(this.csvReader.Read() && readLine < this.RecordCount)
            {
                var record = this.csvReader.GetRecord<TModel>();
                this.Records.Add(record);
                readLine++;
            }
            this.Dispose();
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(disposing && this.csvReader != null)
            {
                this.csvReader.Dispose();
            }
            this.csvReader = null;
        }

        private void SetHeader(string header)
        {
            this.Header = !string.IsNullOrEmpty(header)
                ? header.Split(char.Parse(this.csvConfiguration.Delimiter)).FirstOrDefault()
                : string.Empty;
        }
    }
}
