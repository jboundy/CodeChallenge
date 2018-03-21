import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from "@angular/common/http";

import { AppComponent } from './app.component';
import { CustomerCreateComponent } from './customer/customer-create-component';
import { CustomerListComponent } from './customer/customer-list-component';
import { CustomerService } from './services/customer-service';

@NgModule({
  declarations: [
      AppComponent,
      CustomerCreateComponent,
      CustomerListComponent
  ],
  imports: [
      BrowserModule,
      HttpClientModule
  ],
  providers: [CustomerService],
  bootstrap: [AppComponent]
})
export class AppModule { }
