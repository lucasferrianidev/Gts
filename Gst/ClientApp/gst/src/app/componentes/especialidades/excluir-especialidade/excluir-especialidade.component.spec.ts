import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExcluirEspecialidadeComponent } from './excluir-especialidade.component';

describe('ExcluirEspecialidadeComponent', () => {
  let component: ExcluirEspecialidadeComponent;
  let fixture: ComponentFixture<ExcluirEspecialidadeComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ExcluirEspecialidadeComponent]
    });
    fixture = TestBed.createComponent(ExcluirEspecialidadeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
