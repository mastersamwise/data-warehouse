using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataWarehouse.Classes.Common
{
    public class AuditInfo
    {
        public DateTime _createdDate;
        public string _createdBy;
        public DateTime _updatedDate;
        public string _updatedBy;
        public bool _isDeleted;

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
        /// <param name="createdDate"></param>
        /// <param name="createdBy"></param>
        /// <param name="updatedDate"></param>
        /// <param name="updatedBy"></param>
        /// <param name="isDeleted"></param>
        public AuditInfo(DateTime createdDate, string createdBy, DateTime updatedDate, string updatedBy, bool isDeleted)
        {
            _createdDate = createdDate;
            _createdBy = createdBy;
            _updatedDate = updatedDate;
            _updatedBy = updatedBy;
            _isDeleted = isDeleted;
        }

        /// <summary>
        /// Copy Constructor
        /// </summary>
        /// <param name="auditInfo"></param>
        public AuditInfo(AuditInfo auditInfo)
            : this(auditInfo._createdDate, auditInfo._createdBy, auditInfo._updatedDate, auditInfo._updatedBy, auditInfo._isDeleted)
        {
            // intiontionally left blank
        }
    }
}