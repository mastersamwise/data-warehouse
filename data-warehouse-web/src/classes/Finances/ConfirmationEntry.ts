import { AuditInfo } from "../Common/AuditInfo";

export class ConfirmationEnty {
  public dateOfPayment: Date;
  public dateOfArrival: Date;
  public recipient: string;
  public category: string;
  public accountUsed: string;
  public amount: number;
  public confirmationNumber: string;
  public comment: string;
  public auditInfo: AuditInfo;

  constructor(inDateOfPayment: Date,
              inDateOfArrival: Date,
              inRecipient: string,
              inCategory: string,
              inAccountUsed: string,
              inAmount: number,
              inConfirmationNumber: string,
              inComment: string,
              inAuditInfo: AuditInfo) {
    this.dateOfPayment = inDateOfPayment;
    this.dateOfArrival = inDateOfArrival;
    this.recipient = inRecipient;
    this.category = inCategory;
    this.accountUsed = inAccountUsed;
    this.amount = inAmount;
    this.confirmationNumber = inConfirmationNumber;
    this.comment = inComment;
    this.auditInfo = new AuditInfo(inAuditInfo.createdDate, inAuditInfo.createdBy, inAuditInfo.updatedDate, inAuditInfo.updatedBy, inAuditInfo.isDeleted);
  }
}
