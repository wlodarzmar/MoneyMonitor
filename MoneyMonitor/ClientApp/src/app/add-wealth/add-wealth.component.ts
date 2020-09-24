import { Component } from '@angular/core';
import { WealthService, Wealth } from '../services/wealth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-wealth',
  templateUrl: './add-wealth.component.html',
  styleUrls: ['./add-wealth.component.scss']
})
/** add-wealth component*/
export class AddWealthComponent {

  public name: string = '';

  constructor(private wealthService: WealthService, private router: Router) {

  }

  onSubmit() {

    let wealth = new Wealth();
    wealth.name = this.name;
    this.wealthService.addWealth(wealth)
      .subscribe(
        (value: Wealth) => {
          console.log(value, 'ok');
          this.router.navigate(['configure-wealth', value.id]);
          },
        (e) => console.log('Error', e));
  }
}
