import { AuditInfo } from "../Common/AuditInfo";

export class PokemonEvent {

    public eventID: number;
    public isEventActive: boolean;
    public eventName: string;
    public eventType: string;
    public startDate: Date;
    public endDate: Date;
    public serialCode: string;
    public teraType: string;
    public description: string;
    public isNew: boolean;
    public auditInfo: AuditInfo;
    
    static emptyEvent: PokemonEvent = {
        eventID: -1,
        isEventActive : true,
        eventName: '',
        eventType: '',
        startDate: new Date(),
        endDate: new Date(),
        serialCode: '',
        teraType: '',
        description: '',
        isNew: false,
        auditInfo: new AuditInfo(new Date(), '', new Date(), '', false)
    };

    constructor(inEventID: number,
                inIsEventActive: boolean,
                inEventName: string,
                inEventType: string,
                inStartDate: Date,
                inEndDate: Date,
                inSerialCode: string,
                inTeraType: string,
                inDescription: string,
                inIsNew: boolean,
                inCreatedDate: Date,
                inCreatedBy: string,
                inUpdatedDate: Date,
                inUpdatedBy: string,
                inIsDeleted: boolean) {
        this.eventID = inEventID;
        this.isEventActive = inIsEventActive;
        this.eventName = inEventName;
        this.eventType = inEventType;
        this.startDate = inStartDate;
        this.endDate = inEndDate;
        this.serialCode = inSerialCode;
        this.teraType = inTeraType;
        this.description = inDescription;
        this.isNew = inIsNew;
        this.auditInfo = new AuditInfo(inCreatedDate, inCreatedBy, inUpdatedDate, inUpdatedBy, inIsDeleted);
    }
}
