import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Customer } from "../interfaces/customer";
import 'rxjs/add/operator/map';

@Injectable()
export class CustomerService {

    constructor(private http: HttpClient) {

    }

    public customers: Customer[];

    public getCustomers(): Observable<Customer[]> {
        return this.http.get("/Home/GetCustomers")
            .map((result: Response) => this.customers = ((result.json()) as any));
    }
}