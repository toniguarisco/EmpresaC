import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ComercioSolicitudRetiroComponent } from './comercio-solicitud-retiro.component';

describe('ComercioSolicitudRetiroComponent', () => {
  let component: ComercioSolicitudRetiroComponent;
  let fixture: ComponentFixture<ComercioSolicitudRetiroComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ComercioSolicitudRetiroComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ComercioSolicitudRetiroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
