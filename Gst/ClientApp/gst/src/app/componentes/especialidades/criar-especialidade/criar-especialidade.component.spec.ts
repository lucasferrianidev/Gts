import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CriarEspecialidadeComponent } from './criar-especialidade.component';

describe('CriarEspecialidadeComponent', () => {
  let component: CriarEspecialidadeComponent;
  let fixture: ComponentFixture<CriarEspecialidadeComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CriarEspecialidadeComponent]
    });
    fixture = TestBed.createComponent(CriarEspecialidadeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
