import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from "@angular/common/http";


import { AppComponent } from './app.component';
import { CustomerCreateComponent } from './customer/customer-create-component';

@NgModule({
  declarations: [
      AppComponent,
      CustomerCreateComponent
  ],
  imports: [
      BrowserModule,
      HttpClientModule
  ],
  providers: [CustomerService],
  bootstrap: [AppComponent]
})
export class AppModule { }
