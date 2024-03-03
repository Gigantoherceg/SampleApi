import { Component, OnInit } from '@angular/core';
import { SoapDetailsModel } from '../../models/soapDetails.model';
import { ActivatedRoute } from '@angular/router';
import { SoapService } from '../../services/soap.service';

@Component({
  selector: 'app-soap-details',
  templateUrl: './soap-details.component.html',
  styleUrl: './soap-details.component.css'
})
export class SoapDetailsComponent implements OnInit{
  
  soapId: number = 0;
  soapDetails: SoapDetailsModel = {
    name: '',
    scentType: '',
    description: '',
    price: 0
  }

  constructor(private activateRout: ActivatedRoute, private soapService: SoapService) {}
  
  ngOnInit(): void {
    this.activateRout.paramMap.subscribe({
      next: (paramMap) => {
        const soapId: number = Number(paramMap.get('id'));
        
        if (soapId) {
          this.soapId = soapId;
          this.loadSoapDetails();
        }
      }
    })
  }

  loadSoapDetails() {
    this.soapService.loadSoapDetails(this.soapId).subscribe({
      next: (data: SoapDetailsModel) => this.soapDetails = data,
      error: (error) => console.log(error)
    })
  }
}
