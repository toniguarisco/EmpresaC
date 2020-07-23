import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminOperacionesFallidasComponent } from './admin-operaciones-fallidas.component';

describe('AdminOperacionesFallidasComponent', () => {
  let component: AdminOperacionesFallidasComponent;
  let fixture: ComponentFixture<AdminOperacionesFallidasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminOperacionesFallidasComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminOperacionesFallidasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
