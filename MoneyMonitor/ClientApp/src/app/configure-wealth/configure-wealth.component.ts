import { Component } from '@angular/core';
import { Wealth } from '../services/wealth.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-configure-wealth',
  templateUrl: './configure-wealth.component.html',
  styleUrls: ['./configure-wealth.component.scss']
})
/** configure-wealth component*/
export class ConfigureWealthComponent {

  public wealth: Wealth;

  constructor(private route: ActivatedRoute) {
    this.wealth = new Wealth();
    this.wealth.name = 'wealth name';
    route.paramMap.subscribe((params) => {
      let wealthId = parseInt(params.get('id'));
      console.log(wealthId, 'ID');
    });
  }
}
