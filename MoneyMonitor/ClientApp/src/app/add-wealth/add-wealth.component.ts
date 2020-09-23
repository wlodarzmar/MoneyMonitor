import { Component } from '@angular/core';

@Component({
  selector: 'app-add-wealth',
  templateUrl: './add-wealth.component.html',
  styleUrls: ['./add-wealth.component.scss']
})
/** add-wealth component*/
export class AddWealthComponent {

  public name: string = '';

  constructor() {

  }

  onSubmit() {
    console.log(this.name);
  }
}
