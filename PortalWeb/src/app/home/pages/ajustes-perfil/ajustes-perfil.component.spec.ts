import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AjustesPerfilComponent } from './ajustes-perfil.component';

describe('AjustesPerfilComponent', () => {
  let component: AjustesPerfilComponent;
  let fixture: ComponentFixture<AjustesPerfilComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AjustesPerfilComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AjustesPerfilComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
