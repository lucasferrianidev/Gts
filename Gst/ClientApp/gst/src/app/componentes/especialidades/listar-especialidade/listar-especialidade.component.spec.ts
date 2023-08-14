import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListarEspecialidadeComponent } from './listar-especialidade.component';

describe('ListarEspecialidadeComponent', () => {
  let component: ListarEspecialidadeComponent;
  let fixture: ComponentFixture<ListarEspecialidadeComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ListarEspecialidadeComponent]
    });
    fixture = TestBed.createComponent(ListarEspecialidadeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
