import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SoapFormDataModel } from '../models/soapFormData.model';
import { FormInitDataItemModel } from '../models/formInitDataItem.model';
import { SoapListItemModel } from '../models/soapListItem.model';
import { SoapDetailsModel } from '../models/soapDetails.model';
import { UpdateSoapModel } from '../models/updateSoap.model';

const BASE_URL = 'https://localhost:7150/api/Soaps';

@Injectable({
  providedIn: 'root'
})
export class SoapService {
  
  constructor(private http: HttpClient) { }

  createSoap(data: SoapFormDataModel): Observable<any>{
    return this.http.post<any>(BASE_URL, data);
  }

  fetchFormInitData(): Observable<FormInitDataItemModel>{
    return this.http.get<FormInitDataItemModel>(`${BASE_URL}/formdata`);
  }

  fetchSoaps(): Observable<Array<SoapListItemModel>> {
    return this.http.get<Array<SoapListItemModel>>(`${BASE_URL}/list`);
  }

  deleteSoap(id: number): Observable<any>{
    return this.http.delete(`${BASE_URL}/${id}`);
  }

  loadSoapDetails(id: number): Observable<SoapDetailsModel> {
    return this.http.get<SoapDetailsModel>(`${BASE_URL}/${id}`);
  }

  updateSoap(data: UpdateSoapModel): Observable<any>{
    return this.http.put<any>(BASE_URL,data);
  }

}
