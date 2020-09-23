/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { AddWealthComponent } from './add-wealth.component';

let component: AddWealthComponent;
let fixture: ComponentFixture<AddWealthComponent>;

describe('add-wealth component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ AddWealthComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(AddWealthComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});