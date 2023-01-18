import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
 

interface IRequestOptions {
    headers?: HttpHeaders;
    observe?: 'body';
    params?: HttpParams;
    reportProgress?: boolean;
    responseType?: 'json';
    withCredentials?: boolean;
    body?: any;
}
 
@Injectable()
export class ProxyService {
 
    public constructor(private http: HttpClient) {}
 
    public get(url: string, options?: IRequestOptions): any {
        return this.http.get(url, options);     
    }
 
    public post(url: string, any: any, options?: IRequestOptions): Observable<any> {
        return this.http.post<any>(url, any, options);            
    }
 
    public put(url: string, body: any, options?: IRequestOptions): Observable<any> {
        return this.http.put(url, body, options);
    }
    
    public async getAsync(url: string, options?: IRequestOptions): Promise<any> {
        return this.http.get(url, options).toPromise();
    }
 
    public async postAsync(url: string, body: any, options?: IRequestOptions): Promise<any> {
        return this.http.post<any>(url, body, options).toPromise();
    }
    
    public async putAsync(url: string, body: any, options?: IRequestOptions): Promise<any> {
        return this.http.put(url, body, options).toPromise();
    }
}