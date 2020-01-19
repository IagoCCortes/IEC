/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { LogRegModalComponent } from './logReg-modal.component';

describe('LogRegModalComponent', () => {
  let component: LogRegModalComponent;
  let fixture: ComponentFixture<LogRegModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LogRegModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LogRegModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
