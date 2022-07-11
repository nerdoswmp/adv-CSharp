import { Component, Input, OnInit } from '@angular/core';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-top-bar',
  templateUrl: './top-bar.component.html',
  styleUrls: ['./top-bar.component.css']
})
export class TopBarComponent implements OnInit {

  user = "Não logado"
  logado = false
  @Input() titulo = ""
  constructor(private router: Router) { }

  logout(): void{
    if (this.logado === false){
      this.router.navigate(['/login']) 
    }
    else{
      localStorage.removeItem('authToken');
      localStorage.removeItem('user');
      this.logado = false;
      alert("Logout realizado com sucesso");
      window.location.reload();
      this.router.navigate(['/']);
    }
  }

  ngOnInit(): void {
    if(localStorage.getItem('authToken') != null){
      this.user = localStorage.getItem('user')!;
      this.logado = true;
    }
  }

}
