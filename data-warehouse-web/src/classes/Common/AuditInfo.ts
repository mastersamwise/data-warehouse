export class AuditInfo {
    
    public createdDate: Date;
    public createdBy: string;
    public updatedDate: Date;
    public updatedBy: string;
    public isDeleted: boolean;

    constructor(inCreatedDate: Date, inCreatedBy: string, inUpdatedDate: Date, inUpdatedBy: string, inIsDeleted: boolean) {
        this.createdDate = inCreatedDate;
        this.createdBy = inCreatedBy;
        this.updatedDate = inUpdatedDate;
        this.updatedBy = inUpdatedBy;
        this.isDeleted = inIsDeleted;
    }
}