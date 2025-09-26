using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DataWarehouse.Library.Classes.Common;

namespace DataWarehouse.Library.Classes.Pokemon
{
    public class PokemonEvent
    {

        public int EventID;
        public bool IsEventActive;
        public string EventName;
        public string EventType;
        public DateTime StartDate;
        public DateTime EndDate;
        public string SerialCode;
        public string Description;
        public AuditInfo AuditInfo;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inEventID"></param>
        /// <param name="inIsEventActive"></param>
        /// <param name="inEventName"></param>
        /// <param name="inEventType"></param>
        /// <param name="inStartDate"></param>
        /// <param name="inEndDate"></param>
        /// <param name="inSerialCode"></param>
        /// <param name="inDescription"></param>
        /// <param name="inAuditInfo"></param>
        public PokemonEvent(int inEventID, bool inIsEventActive, string inEventName, string inEventType, DateTime inStartDate, DateTime inEndDate,
                            string inSerialCode, string inDescription, AuditInfo inAuditInfo)
        {
            EventID = inEventID;
            IsEventActive = inIsEventActive;
            EventName = inEventName;
            EventType = inEventType;
            StartDate = inStartDate;
            EndDate = inEndDate;
            SerialCode = inSerialCode;
            Description = inDescription;
            AuditInfo = new AuditInfo(inAuditInfo);
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public PokemonEvent()
            : this(0, true, string.Empty, string.Empty, DateTime.UtcNow, DateTime.UtcNow, string.Empty, string.Empty, new AuditInfo())
        {
            // intentionally left blank
        }

        /// <summary>
        /// Copy Constructor
        /// </summary>
        /// <param name="inCopy"></param>
        public PokemonEvent(PokemonEvent inCopy)
            : this(inCopy.EventID, inCopy.IsEventActive, inCopy.EventName, inCopy.EventType,
                 inCopy.StartDate, inCopy.EndDate, inCopy.SerialCode, inCopy.Description, inCopy.AuditInfo)
        {
            // intentionally left blank
        }
    }
}