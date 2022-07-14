import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LoginownerComponent } from './loginowner.component';

describe('LoginownerComponent', () => {
  let component: LoginownerComponent;
  let fixture: ComponentFixture<LoginownerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LoginownerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LoginownerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
