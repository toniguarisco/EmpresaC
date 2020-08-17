import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EncriptacionComponent } from './encriptacion.component';

describe('EncriptacionComponent', () => {
  let component: EncriptacionComponent;
  let fixture: ComponentFixture<EncriptacionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EncriptacionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EncriptacionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
