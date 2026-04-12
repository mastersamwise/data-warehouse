export type CoreDwColumnType = 'text' | 'date' | 'textarea' | 'numberic';

export interface ICoreDwColumn {
  field: string;
  header: string;
  type: CoreDwColumnType;
  width: string;
  isEditable: boolean;

  // public constructor(
  //   field: string,
  //   header: string,
  //   type: CoreDwColumnType,
  //   width: string,
  //   isEditable: boolean
  // ) {
  //   this.field = field;
  //   this.header = header;
  //   this.type = type;
  //   this.width = width;
  //   this.isEditable = isEditable;
  // }
}
