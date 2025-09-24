using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataWarehouse.Classes.Common;

namespace DataWarehouse.Classes.Pokemon
{
    public class PokemonEvent
    {
        public int _eventID;
        public bool _isEventActive;
        public string _eventName;
        public string _eventType;
        public DateTime _startDate;
        public DateTime _endDate;
        public string _serialCode;
        public string _description;
        public AuditInfo _auditInfo;

        public PokemonEvent(int eventID, bool isEventActive, string eventName, string eventType, DateTime startDate, DateTime endDate
                            string serialCode, string description, AuditInfo inAuditInfo)
        {

        }

        public PokemonEvent()
        {

        }
        
    }
}