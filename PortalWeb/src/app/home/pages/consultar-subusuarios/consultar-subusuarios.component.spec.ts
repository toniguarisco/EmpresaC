import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsultarSubusuariosComponent } from './consultar-subusuarios.component';

describe('ConsultarSubusuariosComponent', () => {
  let component: ConsultarSubusuariosComponent;
  let fixture: ComponentFixture<ConsultarSubusuariosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConsultarSubusuariosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsultarSubusuariosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
