/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { UserMovieService } from './userMovie.service';

describe('Service: UserMovie', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [UserMovieService]
    });
  });

  it('should ...', inject([UserMovieService], (service: UserMovieService) => {
    expect(service).toBeTruthy();
  }));
});
