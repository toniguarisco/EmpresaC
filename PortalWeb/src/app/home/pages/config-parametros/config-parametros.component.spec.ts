import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfigParametrosComponent } from './config-parametros.component';

describe('ConfigParametrosComponent', () => {
  let component: ConfigParametrosComponent;
  let fixture: ComponentFixture<ConfigParametrosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConfigParametrosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConfigParametrosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
