import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SoapDetailsComponent } from './soap-details.component';

describe('SoapDetailsComponent', () => {
  let component: SoapDetailsComponent;
  let fixture: ComponentFixture<SoapDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SoapDetailsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SoapDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
