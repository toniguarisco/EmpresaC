import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BloqueoOperacionesComponent } from './bloqueo-operaciones.component';

describe('BloqueoOperacionesComponent', () => {
  let component: BloqueoOperacionesComponent;
  let fixture: ComponentFixture<BloqueoOperacionesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BloqueoOperacionesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BloqueoOperacionesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
