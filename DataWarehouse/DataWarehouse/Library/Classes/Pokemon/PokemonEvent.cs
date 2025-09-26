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
        public string EventName { get; set; }

        public PokemonEvent(string inEventName)
        {
            EventName = inEventName;
        }

        #region temp commented out
        // public int eventID;
        // public bool isEventActive;
        // public string eventName;
        // public string eventType;
        // public DateTime startDate;
        // public DateTime endDate;
        // public string serialCode;
        // public string description;
        // public AuditInfo auditInfo;

        // /// <summary>
        // /// 
        // /// </summary>
        // /// <param name="inEventID"></param>
        // /// <param name="inIsEventActive"></param>
        // /// <param name="inEventName"></param>
        // /// <param name="inEventType"></param>
        // /// <param name="inStartDate"></param>
        // /// <param name="inEndDate"></param>
        // /// <param name="inSerialCode"></param>
        // /// <param name="inDescription"></param>
        // /// <param name="inAuditInfo"></param>
        // public PokemonEvent(int inEventID, bool inIsEventActive, string inEventName, string inEventType, DateTime inStartDate, DateTime inEndDate,
        //                     string inSerialCode, string inDescription, AuditInfo inAuditInfo)
        // {
        //     eventID = inEventID;
        //     isEventActive = inIsEventActive;
        //     eventName = inEventName;
        //     eventType = inEventType;
        //     startDate = inStartDate;
        //     endDate = inEndDate;
        //     serialCode = inSerialCode;
        //     description = inDescription;
        //     auditInfo = new AuditInfo(inAuditInfo);
        // }

        // /// <summary>
        // /// Default Constructor
        // /// </summary>
        // public PokemonEvent()
        //     : this(0, true, string.Empty, string.Empty, DateTime.UtcNow, DateTime.UtcNow, string.Empty, string.Empty, new AuditInfo())
        // {
        //     // intentionally left blank
        // }

        // /// <summary>
        // /// Copy Constructor
        // /// </summary>
        // /// <param name="inCopy"></param>
        // public PokemonEvent(PokemonEvent inCopy)
        //     : this(inCopy.eventID, inCopy.isEventActive, inCopy.eventName, inCopy.eventType,
        //          inCopy.startDate, inCopy.endDate, inCopy.serialCode, inCopy.description, inCopy.auditInfo)
        // {
        //     // intentionally left blank
        // }
        
        #endregion
    }
}