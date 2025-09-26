import { AuditInfo } from "../Common/AuditInfo";

export class PokemonEvent {
    
    public eventID: number;
    public isEventActive: boolean;
    public eventName: string;
    public eventType: string;
    public startDate: Date;
    public endDate: Date;
    public serialCode: string;
    public description: string;
    public auditInfo: AuditInfo;

    constructor(inEventID: number, 
                inIsEventActive: boolean, 
                inEventName: string, 
                inEventType: string,
                inStartDate: Date, 
                inEndDate: Date, 
                inSerialCode: string, 
                inDescription: string, 
                inAuditInfo: AuditInfo) {
        this.eventID = inEventID;
        this.isEventActive = inIsEventActive;
        this.eventName = inEventName;
        this.eventType = inEventType;
        this.startDate = inStartDate;
        this.endDate = inEndDate;
        this.serialCode = inSerialCode;
        this.description = inDescription;
        this.auditInfo = new AuditInfo(inAuditInfo.createdDate, inAuditInfo.createdBy, inAuditInfo.updatedDate, inAuditInfo.updatedBy, inAuditInfo.isDeleted);
    }
}