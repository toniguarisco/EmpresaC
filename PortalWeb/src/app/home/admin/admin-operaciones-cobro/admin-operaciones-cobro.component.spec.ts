import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminOperacionesCobroComponent } from './admin-operaciones-cobro.component';

describe('AdminOperacionesCobroComponent', () => {
  let component: AdminOperacionesCobroComponent;
  let fixture: ComponentFixture<AdminOperacionesCobroComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminOperacionesCobroComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminOperacionesCobroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
