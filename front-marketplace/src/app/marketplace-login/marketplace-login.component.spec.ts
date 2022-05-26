import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MarketplaceLoginComponent } from './marketplace-login.component';

describe('MarketplaceLoginComponent', () => {
  let component: MarketplaceLoginComponent;
  let fixture: ComponentFixture<MarketplaceLoginComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MarketplaceLoginComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MarketplaceLoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
// a