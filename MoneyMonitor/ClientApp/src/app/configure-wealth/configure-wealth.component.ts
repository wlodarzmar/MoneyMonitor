import { Component } from '@angular/core';
import { Wealth } from '../services/wealth.service';

@Component({
  selector: 'app-configure-wealth',
  templateUrl: './configure-wealth.component.html',
  styleUrls: ['./configure-wealth.component.scss']
})
/** configure-wealth component*/
export class ConfigureWealthComponent {

  public wealth: Wealth;

  constructor() {
    this.wealth = new Wealth();
    this.wealth.name = 'wealth name';
  }
}
