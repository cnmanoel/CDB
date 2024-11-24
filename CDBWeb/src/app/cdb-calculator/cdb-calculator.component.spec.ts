import { TestBed, ComponentFixture } from '@angular/core/testing';
import { CdbCalculatorComponent } from './cdb-calculator.component';
import { FormsModule } from '@angular/forms';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { By } from '@angular/platform-browser';

describe('CdbCalculatorComponent', () => {
  let component: CdbCalculatorComponent;
  let fixture: ComponentFixture<CdbCalculatorComponent>;
  let httpMock: HttpTestingController;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FormsModule, HttpClientTestingModule, CdbCalculatorComponent]
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CdbCalculatorComponent);
    component = fixture.componentInstance;
    httpMock = TestBed.inject(HttpTestingController);
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should calculate CDB and display results', () => {
    component.initialValue = 1110;
    component.months = 12;

    fixture.detectChanges();

    const calculateButton = fixture.debugElement.query(By.css('button')).nativeElement;
    calculateButton.click();

    const req = httpMock.expectOne('http://localhost:5050/api/cdb/calculate');
    expect(req.request.method).toBe('POST');
    req.flush({ grossValue: 1234.56, netValue: 1111.11 });

    fixture.detectChanges();

    const grossValueElement = fixture.debugElement.query(By.css('p')).nativeElement;
    const netValueElement = fixture.debugElement.queryAll(By.css('p'))[1].nativeElement;

    expect(grossValueElement.textContent).toContain('1234.56');
    expect(netValueElement.textContent).toContain('1111.11');
  });

  afterEach(() => {
    httpMock.verify();
  });
});