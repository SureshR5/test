using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;

namespace MaturityData.DataLoader
{
    public sealed class MaturityMap: CsvClassMap<Maturity>
    {
        public MaturityMap()
        {
            this.AutoMap();
        }
    }
}
