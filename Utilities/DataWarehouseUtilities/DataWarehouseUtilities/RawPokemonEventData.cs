using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataWarehouseUtilities
{
    public class RawPokemonEventData
    {
        public string eventID;
        public string isEventActive;
        public string eventName;
        public string eventType;
        public string startDate;
        public string endDate;
        public string serialCode;
        public string teraType;
        public string description;

        public RawPokemonEventData()
        {
            eventID = "";
            isEventActive = "";
            eventName = "";
            eventType = "";
            startDate = "";
            endDate = "";
            serialCode = "";
            teraType = "";
            description = "";
        }
    }
}
