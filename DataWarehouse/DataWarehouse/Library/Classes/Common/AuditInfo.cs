using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataWarehouse.Library.Classes.Common
{
    public class AuditInfo
    {
        public DateTime createdDate;
        public string createdBy;
        public DateTime updatedDate;
        public string updatedBy;
        public bool isDeleted;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public AuditInfo()
            : this(DateTime.Now, "", DateTime.Now, "", false)
        {
            // intentionally left blank
        }

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="inCreatedDate"></param>
        /// <param name="inCreatedBy"></param>
        /// <param name="inUpdatedDate"></param>
        /// <param name="inUpdatedBy"></param>
        /// <param name="inIsDeleted"></param>
        public AuditInfo(DateTime inCreatedDate, string inCreatedBy, DateTime inUpdatedDate, string inUpdatedBy, bool inIsDeleted)
        {
            createdDate = inCreatedDate;
            createdBy = inCreatedBy;
            updatedDate = inUpdatedDate;
            updatedBy = inUpdatedBy;
            isDeleted = inIsDeleted;
        }

        /// <summary>
        /// Copy Constructor
        /// </summary>
        /// <param name="inAuditInfo"></param>
        public AuditInfo(AuditInfo inAuditInfo)
            : this(inAuditInfo.createdDate, inAuditInfo.createdBy, inAuditInfo.updatedDate, inAuditInfo.updatedBy, inAuditInfo.isDeleted)
        {
            // intiontionally left blank
        }
    }
}