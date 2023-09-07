import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WishlistProductDetailsComponent } from './wishlist-product-details.component';

describe('WishlistProductDetailsComponent', () => {
  let component: WishlistProductDetailsComponent;
  let fixture: ComponentFixture<WishlistProductDetailsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [WishlistProductDetailsComponent]
    });
    fixture = TestBed.createComponent(WishlistProductDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
