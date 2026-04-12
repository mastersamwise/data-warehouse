import { Observable } from "rxjs/internal/Observable";
import { ICoreDwRow } from "../../classes/Common/ICoreDwRow";

export interface ICoreDwCrudService {
  getData(): Observable<any>;
  getDataByID(): Observable<any>;
  saveData(rowData: ICoreDwRow): Observable<any>;
  updateData(rowData: ICoreDwRow): Observable<any>;
  deleteData(rowData: ICoreDwRow): Observable<any>;
}
