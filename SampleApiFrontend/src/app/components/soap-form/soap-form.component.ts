import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { SoapService } from '../../services/soap.service';
import { Router } from '@angular/router';
import { ScentOptionItemModel } from '../../models/scentOptionItem.model';
import { HttpErrorResponse } from '@angular/common/http';
import { validationHandler } from '../../utils/validationHandler';

@Component({
  selector: 'app-soap-form',
  templateUrl: './soap-form.component.html',
  styleUrl: './soap-form.component.css'
})
export class SoapFormComponent implements OnInit {

  form: FormGroup;
  scents: Array<ScentOptionItemModel> = [];

  constructor(private formbuilder: FormBuilder,
              private soapservice: SoapService,
              private router: Router)
  {
    this.form = this.formbuilder.group({
      name: [null], //, Validators.required
      scenttype: [null], //, Validators.required
      description: [null, this.descriptionValidator], //egyszerűbben: Validators.maxLenght(255)
      price: [0, Validators.min(0)],
      // picture: [null]
    })
  }

  ngOnInit(): void {
    this.soapservice.fetchFormInitData().subscribe({
      next: (respons) => this.scents = respons.scents,
      error: (error) => console.log(error)
    })
  }

  onSubmit() {
    this.soapservice.createSoap(this.form.value).subscribe({
      next: () => this.router.navigate(['soap-list']),
      error: (error) => validationHandler(error, this.form)
    })    
  }

  descriptionValidator(control: FormControl): {tooMany: boolean} | null {
    let result = null;
    if (control.value) {
      const descriptionText = control.value;

      if (descriptionText > 255) {
        result = {tooMany: true};
      }
    }
    return result;
  }

}
