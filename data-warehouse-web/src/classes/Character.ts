import { ClassLevel } from "./ClassLevel";

const EMPTY_STAT: number = 0;

export class Character {
    name: string = "";
    classLevel: ClassLevel[] = [];

    baseStrength: number = EMPTY_STAT;
    baseDexterity: number = EMPTY_STAT;
    baseConstitution: number = EMPTY_STAT;
    baseIntelligence: number = EMPTY_STAT;
    baseWisdom: number = EMPTY_STAT;
    baseCharisma: number = EMPTY_STAT;

    constructor() {
        
    }
}