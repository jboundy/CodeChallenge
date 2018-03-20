import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable()
export class CustomerService {

    constructor(private http: HttpClient) {
    
    }

    getCustomers() {
        return this.http.get("Home/GetCustomers")
    }
}