import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { SoapDetailsComponent } from './components/soap-details/soap-details.component';
import { SoapListComponent } from './components/soap-list/soap-list.component';
import { SoapFormComponent } from './components/soap-form/soap-form.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { SoapService } from './services/soap.service';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    SoapDetailsComponent,
    SoapListComponent,
    SoapFormComponent,
    NavbarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [SoapService],
  bootstrap: [AppComponent]
})
export class AppModule { }
