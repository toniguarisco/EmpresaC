import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ComercioConsultarSolicitudesRetiroComponent } from './comercio-consultar-solicitudes-retiro.component';

describe('ComercioConsultarSolicitudesRetiroComponent', () => {
  let component: ComercioConsultarSolicitudesRetiroComponent;
  let fixture: ComponentFixture<ComercioConsultarSolicitudesRetiroComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ComercioConsultarSolicitudesRetiroComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ComercioConsultarSolicitudesRetiroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
