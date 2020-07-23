import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SubUsuariosComponent } from './sub-usuarios.component';

describe('SubUsuariosComponent', () => {
  let component: SubUsuariosComponent;
  let fixture: ComponentFixture<SubUsuariosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SubUsuariosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SubUsuariosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
