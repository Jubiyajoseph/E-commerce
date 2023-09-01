import { TestBed } from '@angular/core/testing';

import { EcommerceService } from './lECommerce.service';

describe('LoginService', () => {
  let service: EcommerceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EcommerceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
