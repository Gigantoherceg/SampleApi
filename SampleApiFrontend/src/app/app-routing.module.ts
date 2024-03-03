import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { SoapListComponent } from './components/soap-list/soap-list.component';
import { SoapDetailsComponent } from './components/soap-details/soap-details.component';
import { SoapFormComponent } from './components/soap-form/soap-form.component';

const routes: Routes = [
  {path : '', component: HomeComponent},
  {path : 'soap-list', component: SoapListComponent},
  {path : 'soap-list/:id', component: SoapDetailsComponent},
  {path : 'soap-form', component: SoapFormComponent},
  {path : '**', redirectTo: ''}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
