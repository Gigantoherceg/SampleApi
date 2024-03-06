import { Component, OnInit } from '@angular/core';
import { SoapListItemModel } from '../../models/soapListItem.model';
import { SoapService } from '../../services/soap.service';
import { Route, Router } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-soap-list',
  templateUrl: './soap-list.component.html',
  styleUrl: './soap-list.component.css'
})
export class SoapListComponent implements OnInit {

  soaps: Array<SoapListItemModel> = [];

  constructor(private soapService: SoapService, private router: Router) {}

  ngOnInit(): void {
    this.loadSoaps();
  }

  loadSoaps() {
    this.soapService.fetchSoaps().subscribe({
      next: (response: SoapListItemModel[]) => this.soaps = response,
      error: (error) => console.log(error)
    });
  }
  
  goToDetails(id: number) {
    this.router.navigate(['soap-list', id]);
  }

  deleteSoap(id: number) {
    this.soapService.deleteSoap(id).subscribe({
      next: () => this.loadSoaps(),
      error: (error) => console.log(error)
    })
  }

}
