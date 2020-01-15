/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { OpenAuthModalService } from './openAuthModal.service';

describe('Service: OpenAuthModal', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [OpenAuthModalService]
    });
  });

  it('should ...', inject([OpenAuthModalService], (service: OpenAuthModalService) => {
    expect(service).toBeTruthy();
  }));
});
