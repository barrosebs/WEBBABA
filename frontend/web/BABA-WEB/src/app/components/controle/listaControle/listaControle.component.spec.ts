/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { ListaControleComponent } from './listaControle.component';

describe('ListaControleComponent', () => {
  let component: ListaControleComponent;
  let fixture: ComponentFixture<ListaControleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListaControleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListaControleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
