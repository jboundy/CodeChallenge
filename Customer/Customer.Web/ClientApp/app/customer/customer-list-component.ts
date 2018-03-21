import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../services/customer-service';
import { Customer } from '../interfaces/customer';

@Component({
    selector: 'customer-list',
    templateUrl: "customer-list-component.html",
    styles: []
})
export class CustomerListComponent implements OnInit{
    public customers: Customer[];

    constructor(private service: CustomerService) {
        this.customers = service.customers;
    }

    ngOnInit(): void {
        this.service.getCustomers()
            .map(success => {
                if (success) {
                    this.customers = this.service.customers;
                }
            });
    }
}
