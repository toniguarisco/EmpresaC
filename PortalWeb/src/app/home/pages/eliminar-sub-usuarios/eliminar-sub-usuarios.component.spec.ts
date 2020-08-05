import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EliminarSubUsuariosComponent } from './eliminar-sub-usuarios.component';

describe('EliminarSubUsuariosComponent', () => {
  let component: EliminarSubUsuariosComponent;
  let fixture: ComponentFixture<EliminarSubUsuariosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EliminarSubUsuariosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EliminarSubUsuariosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
