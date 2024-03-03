import { HttpErrorResponse } from "@angular/common/http";
import { FormGroup } from "@angular/forms";

export function validationHandler(error: Error, form: FormGroup){    
    if (error instanceof HttpErrorResponse && error.status ===400) {
        const backendErrors = error.error.errors;

        for (const key of Object.keys(backendErrors)) {            
          const formControl = form.get(key.toLowerCase())
          console.log(formControl);

          if (formControl) {
            for (const message of backendErrors[key]) {
              formControl.setErrors({serverError: message});
            }
          }
        }          
      }
}