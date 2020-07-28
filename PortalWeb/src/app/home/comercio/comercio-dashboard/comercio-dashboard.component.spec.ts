import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ComercioDashboardComponent } from './comercio-dashboard.component';

describe('ComercioDashboardComponent', () => {
  let component: ComercioDashboardComponent;
  let fixture: ComponentFixture<ComercioDashboardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ComercioDashboardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ComercioDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
