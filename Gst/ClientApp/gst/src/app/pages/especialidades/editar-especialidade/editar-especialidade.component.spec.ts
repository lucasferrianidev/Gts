import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditarEspecialidadeComponent } from './editar-especialidade.component';

describe('EditarEspecialidadeComponent', () => {
  let component: EditarEspecialidadeComponent;
  let fixture: ComponentFixture<EditarEspecialidadeComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [EditarEspecialidadeComponent]
    });
    fixture = TestBed.createComponent(EditarEspecialidadeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
