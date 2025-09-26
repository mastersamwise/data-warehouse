using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataWarehouse.Library.Classes.Common
{
    public class Constants
    {   
        /// <summary>
        /// 
        /// </summary>
        private static string CHAR_SET = "charset=utf8mb4;";
        public static string DB_CONNECTION_NAS = $"server=10.160.0.123;port=3306;user=nbourne;password=Sam4wise8!;database=nbourne;{CHAR_SET}";
        
    }
}