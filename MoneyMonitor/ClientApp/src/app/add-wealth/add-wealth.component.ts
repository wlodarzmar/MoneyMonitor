import { Component } from '@angular/core';
import { WealthService, Wealth } from '../services/wealth.service';

@Component({
  selector: 'app-add-wealth',
  templateUrl: './add-wealth.component.html',
  styleUrls: ['./add-wealth.component.scss']
})
/** add-wealth component*/
export class AddWealthComponent {

  public name: string = '';

  constructor(private wealthService: WealthService) {

  }

  onSubmit() {

    let wealth = new Wealth();
    wealth.name = this.name;
    this.wealthService.addWealth(wealth)
      .subscribe(
        (value) => console.log(value, 'ok'),
        (e) => console.log('Error', e));
  }
}
