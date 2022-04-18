using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DB
{
    public class QueryResults
    {
        public QueryResults()
        {
            ColumnNames = new List<string>();
            ColumnDataTypes = new List<string>();
            Results2D = new List<List<string>>();
        }
        public List<string> ColumnNames { get; set; }
        public List<string> ColumnDataTypes { get; set; }
        public List<List<string>> Results2D { get; set; }
    }
    
}
