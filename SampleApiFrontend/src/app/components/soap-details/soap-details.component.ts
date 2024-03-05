import { Component, OnInit } from '@angular/core';
import { SoapDetailsModel } from '../../models/soapDetails.model';
import { ActivatedRoute, Router } from '@angular/router';
import { SoapService } from '../../services/soap.service';
import { validationHandler } from '../../utils/validationHandler';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { UpdateSoapModel } from '../../models/updateSoap.model';

@Component({
  selector: 'app-soap-details',
  templateUrl: './soap-details.component.html',
  styleUrl: './soap-details.component.css'
})
export class SoapDetailsComponent implements OnInit{

  form!: FormGroup;
  
  soapId: number = 0;
  soapDetails: SoapDetailsModel = {
    name: '',
    description: '',
    price: 0
  }
  
  constructor(private formbuilder: FormBuilder,
              private activateRout: ActivatedRoute,
              private soapService: SoapService,
              private router: Router)
  {
    
  }
  
  ngOnInit(): void {
    this.form = this.formbuilder.group({
      name: [null, Validators.required],
      description: [null, Validators.required],
      price: [0, [Validators.required, Validators.min(0)]],
    });

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
      next: (result: SoapDetailsModel) => {
        this.soapDetails = result;
        this.form.patchValue({
          name: this.soapDetails.name,
          description: this.soapDetails.description,
          price: this.soapDetails.price
        });
      },
      error: (error) => console.log(error)      
    })
  
  }
  refresh() {
      
      const updatedName = this.form.get('name')?.value;
      const updatedDescription = this.form.get('description')?.value;
      const updatedPrice = this.form.get('price')?.value;
      
      const formData: UpdateSoapModel = {
        id: this.soapId,
        name: updatedName,
        description: updatedDescription,
        price: updatedPrice
      };
      console.log(formData);
      this.soapService.updateSoap(formData).subscribe({
        next: () => this.router.navigate(['soap-list']),
        error: (error) => validationHandler(error, this.form)
      })
      console.log(formData);
    }
}
