using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarkExplorerDB
{
    public class DataFunctions
    {
        public static string GetDbPath()
        {
            using var db = new DataContext();
            return db.DbPath;
        }


    }
}
