import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KarakteristikaComponent } from './karakteristika.component';

describe('KarakteristikaComponent', () => {
  let component: KarakteristikaComponent;
  let fixture: ComponentFixture<KarakteristikaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ KarakteristikaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(KarakteristikaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
