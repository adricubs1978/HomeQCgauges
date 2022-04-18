using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MariaDB.Classes
{
    public class QueryResults
    {
        public List<string> ColumnNames { get; set; }
        public List<List<string>> Results2D { get; set; }
    }
}
