/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { ConfigureWealthComponent } from './configure-wealth.component';

let component: ConfigureWealthComponent;
let fixture: ComponentFixture<ConfigureWealthComponent>;

describe('configure-wealth component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ ConfigureWealthComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(ConfigureWealthComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});