import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CrearSubusuarioComponent } from './crear-subusuario.component';

describe('CrearSubusuarioComponent', () => {
  let component: CrearSubusuarioComponent;
  let fixture: ComponentFixture<CrearSubusuarioComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CrearSubusuarioComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CrearSubusuarioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
