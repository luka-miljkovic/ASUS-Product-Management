import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProizvodiUnosComponent } from './proizvodi-unos.component';

describe('ProizvodiUnosComponent', () => {
  let component: ProizvodiUnosComponent;
  let fixture: ComponentFixture<ProizvodiUnosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProizvodiUnosComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProizvodiUnosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
