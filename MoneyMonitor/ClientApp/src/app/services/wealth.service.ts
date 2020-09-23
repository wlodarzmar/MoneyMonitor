import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class WealthService {

  baseUrl: string;
  wealthUrl: string = 'api/wealth';

  constructor(@Inject('BASE_URL') baseUrl: string, private http: HttpClient) {
    this.baseUrl = baseUrl;
    console.log(baseUrl, "BASEURL");
  }

  addWealth(wealth: Wealth) {
    console.log(wealth, 'serv');
    return this.http.post(`${this.baseUrl}${this.wealthUrl}`, wealth).subscribe((value) => console.log(value, 'ok'));
  }
}

export class Wealth {
  id: number;
  name: string;
}
