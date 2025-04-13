import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CuidadoDialogDeletarComponent } from './cuidado-dialog-deletar.component';

describe('CuidadoDialogDeletarComponent', () => {
  let component: CuidadoDialogDeletarComponent;
  let fixture: ComponentFixture<CuidadoDialogDeletarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CuidadoDialogDeletarComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CuidadoDialogDeletarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
