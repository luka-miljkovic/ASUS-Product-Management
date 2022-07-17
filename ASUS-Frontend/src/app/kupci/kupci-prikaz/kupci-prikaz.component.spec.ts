import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KupciPrikazComponent } from './kupci-prikaz.component';

describe('KupciPrikazComponent', () => {
  let component: KupciPrikazComponent;
  let fixture: ComponentFixture<KupciPrikazComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ KupciPrikazComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(KupciPrikazComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
