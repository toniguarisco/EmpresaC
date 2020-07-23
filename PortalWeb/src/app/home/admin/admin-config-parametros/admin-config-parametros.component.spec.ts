import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminConfigParametrosComponent } from './admin-config-parametros.component';

describe('AdminConfigParametrosComponent', () => {
  let component: AdminConfigParametrosComponent;
  let fixture: ComponentFixture<AdminConfigParametrosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminConfigParametrosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminConfigParametrosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
