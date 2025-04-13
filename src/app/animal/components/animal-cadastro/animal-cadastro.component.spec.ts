import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AnimalCadastroComponent } from './animal-cadastro.component';

describe('AnimalCadastroComponent', () => {
  let component: AnimalCadastroComponent;
  let fixture: ComponentFixture<AnimalCadastroComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AnimalCadastroComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AnimalCadastroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
