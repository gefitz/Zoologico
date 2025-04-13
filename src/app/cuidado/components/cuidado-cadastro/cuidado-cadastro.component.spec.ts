import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CuidadoCadastroComponent } from './cuidado-cadastro.component';

describe('CuidadoCadastroComponent', () => {
  let component: CuidadoCadastroComponent;
  let fixture: ComponentFixture<CuidadoCadastroComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CuidadoCadastroComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CuidadoCadastroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
