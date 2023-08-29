import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/core/service/user.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {

  user$ = this.userService.retornarUser();

  constructor(
    private router: Router,
    private userService: UserService
  ) {}

  logout() {
    this.userService.logout();
    this.router.navigate(['/login'])
  }

}
