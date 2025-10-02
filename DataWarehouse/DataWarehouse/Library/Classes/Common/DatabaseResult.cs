using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataWarehouse.Library.Classes.Common
{
    public class DatabaseResult
    {
        public int id { get; set; }
        public bool wasCallSuccessful { get; set; }
        public DateTime updatedDate { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary> 
        public DatabaseResult()
        {
            id = -1;
            wasCallSuccessful = false;
            updatedDate = DateTime.MinValue;
        }
    }
}