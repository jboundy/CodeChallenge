import { Component } from '@angular/core';

@Component({
    selector: 'customer-create',
    templateUrl: "customer-create-component.html",
    styles: []
})
export class CustomerCreateComponent {
    public FirstName: string;
    public LastName: string;
    public Email: string;
}
