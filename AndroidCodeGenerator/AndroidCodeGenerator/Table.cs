using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AndroidCodeGenerator
{
    public class Table
    {
        public string TableName { get; set; }
        public List<Column> Columns { get; set; }
        public List<Table> SubTables { get; set; }


        public Table(string name) {
            this.TableName = name;
            this.Columns = new List<Column>();
            this.SubTables = new List<Table>();
        }
        
        public List<Column> GetPrimaryKeyColumns() {
            var tmp = this.Columns.Where(w => w.IsPK == true);
            if (tmp.Count() > 0)
                return tmp.ToList();
            else
                return new List<Column>();
        }
    }
}
