import { Component, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  rota = '';
  constructor(private router: Router) { 

  }

  ngOnInit(): void {

  }
  goToLogin(){
    this.router.navigate(['user/registro'])
  }
}
