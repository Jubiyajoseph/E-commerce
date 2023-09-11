import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateaddressComponent } from './updateaddress.component';

describe('UpdateaddressComponent', () => {
  let component: UpdateaddressComponent;
  let fixture: ComponentFixture<UpdateaddressComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UpdateaddressComponent]
    });
    fixture = TestBed.createComponent(UpdateaddressComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
