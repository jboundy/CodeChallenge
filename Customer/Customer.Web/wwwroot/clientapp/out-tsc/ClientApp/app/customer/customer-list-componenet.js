"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var customer_service_1 = require("../services/customer-service");
var CustomerListComponent = /** @class */ (function () {
    function CustomerListComponent(service) {
        this.service = service;
        this.customers = service.customers;
    }
    CustomerListComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.service.getCustomers()
            .map(function (success) {
            if (success) {
                _this.customers = _this.service.customers;
            }
        });
    };
    CustomerListComponent = __decorate([
        core_1.Component({
            selector: 'customer-list',
            templateUrl: 'customer-list-component.html',
            styles: []
        }),
        __metadata("design:paramtypes", [customer_service_1.CustomerService])
    ], CustomerListComponent);
    return CustomerListComponent;
}());
exports.CustomerListComponent = CustomerListComponent;
//# sourceMappingURL=customer-list-componenet.js.map