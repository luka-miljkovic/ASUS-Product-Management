import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KupciUnosComponent } from './kupci-unos.component';

describe('KupciUnosComponent', () => {
  let component: KupciUnosComponent;
  let fixture: ComponentFixture<KupciUnosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ KupciUnosComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(KupciUnosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
