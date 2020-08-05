import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsultarSubUsuariosComponent } from './consultar-sub-usuarios.component';

describe('ConsultarSubUsuariosComponent', () => {
  let component: ConsultarSubUsuariosComponent;
  let fixture: ComponentFixture<ConsultarSubUsuariosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConsultarSubUsuariosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsultarSubUsuariosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
