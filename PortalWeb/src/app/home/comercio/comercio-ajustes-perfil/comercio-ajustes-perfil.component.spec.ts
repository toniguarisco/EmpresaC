import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ComercioAjustesPerfilComponent } from './comercio-ajustes-perfil.component';

describe('ComercioAjustesPerfilComponent', () => {
  let component: ComercioAjustesPerfilComponent;
  let fixture: ComponentFixture<ComercioAjustesPerfilComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ComercioAjustesPerfilComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ComercioAjustesPerfilComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
