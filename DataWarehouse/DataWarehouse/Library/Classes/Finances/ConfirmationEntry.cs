using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataWarehouse.Library.Classes.Common;

namespace DataWarehouse.Library.Classes.Finances
{
    public class ConfirmationEntry
    {
        public DateTime DateOfPayment { get; set; }
        public DateTime DateOfArrival { get; set; }
        public string Recipient { get; set; }
        public string Category { get; set; }
        public string AccountUsed { get; set; }
        public double Amount { get; set; }
        public string ConfirmationNumber { get; set; }
        public string Comment { get; set; }
        public AuditInfo AuditInfo { get; set; }


        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="inDateOfPayment"></param>
        /// <param name="inDateOfArrival"></param>
        /// <param name="inRecipient"></param>
        /// <param name="inCategory"></param>
        /// <param name="inAccountUsed"></param>
        /// <param name="inAmount"></param>
        /// <param name="inConfirmationNumber"></param>
        /// <param name="inComment"></param>
        /// <param name="inAuditInfo"></param> 
        public ConfirmationEntry(DateTime inDateOfPayment, DateTime inDateOfArrival, string inRecipient, string inCategory, string inAccountUsed,
                                    double inAmount, string inConfirmationNumber, string inComment, AuditInfo inAuditInfo)
        {
            DateOfPayment = inDateOfPayment;
            DateOfArrival = inDateOfArrival;
            Recipient = inRecipient;
            Category = inCategory;
            AccountUsed = inAccountUsed;
            Amount = inAmount;
            ConfirmationNumber = inConfirmationNumber;
            Comment = inComment;
            AuditInfo = new AuditInfo(inAuditInfo);
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ConfirmationEntry()
            : this(DateTime.UtcNow, DateTime.UtcNow, string.Empty, string.Empty, string.Empty, 0.0, string.Empty, string.Empty, new AuditInfo())
        {
            // intentionally left blank
        }

        /// <summary>
        /// Copy Constructor
        /// </summary>
        /// <param name="inCopy"></param>
        public ConfirmationEntry(ConfirmationEntry inCopy)
            : this(inCopy.DateOfPayment, inCopy.DateOfArrival, inCopy.Recipient, inCopy.Category, inCopy.AccountUsed, inCopy.Amount,
                    inCopy.ConfirmationNumber, inCopy.Comment, inCopy.AuditInfo)
        {
            // intentionally left blank        
        }
    }
}