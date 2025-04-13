import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LogErroModalComponent } from './log-erro-modal.component';

describe('LogErroModalComponent', () => {
  let component: LogErroModalComponent;
  let fixture: ComponentFixture<LogErroModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LogErroModalComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LogErroModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
