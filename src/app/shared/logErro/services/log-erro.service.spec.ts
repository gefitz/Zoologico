import { TestBed } from '@angular/core/testing';

import { LogErroService } from './log-erro.service';

describe('LogErroService', () => {
  let service: LogErroService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LogErroService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
