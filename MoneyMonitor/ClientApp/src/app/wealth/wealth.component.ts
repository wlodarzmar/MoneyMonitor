import { Component } from '@angular/core';
import { Wealth } from '../services/wealth.service';

@Component({
  selector: 'app-wealth',
  templateUrl: './wealth.component.html',
  styleUrls: ['./wealth.component.scss']
})
/** wealth component*/
export class WealthComponent {

  wealths: Wealth[] = [];

  constructor(
  ) { }

  ngOnInit() {
    
    this.wealths.push({ id: 1, name: 'wealth 1' });
  }

  addWealth() {
  }
}
