import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { Title } from '@angular/platform-browser';
import { LOCAL_STORAGE_KEYS } from './constants';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  title: string = 'My App';

  constructor(private router: Router, private titleService: Title) {
    this.router.events
      .pipe(filter((event) => event instanceof NavigationEnd)) // Only listen to NavigationEnd event
      .subscribe(() => {
        const currentRoute = this.router.routerState.snapshot.root.firstChild;
        if (currentRoute && currentRoute.data && currentRoute.data['title']) {
          this.titleService.setTitle(currentRoute.data['title']); // Set dynamic title
          this.title = currentRoute.data['title'];
        } else {
          this.titleService.setTitle('My App'); // Default title
          this.title = 'My App';
        }
      });
  }

  ngOnInit() {}

  get isLoggedIn() {
    const gstTokenData = localStorage.getItem(LOCAL_STORAGE_KEYS.GST_AUTH_DATA);
    const token = localStorage.getItem(LOCAL_STORAGE_KEYS.INTERNAL_AUTH_TOKEN);
    return token && gstTokenData;
  }

  logout() {
    localStorage.removeItem(LOCAL_STORAGE_KEYS.GST_AUTH_DATA);
    localStorage.removeItem(LOCAL_STORAGE_KEYS.INTERNAL_AUTH_DATA);
    localStorage.removeItem(LOCAL_STORAGE_KEYS.INTERNAL_AUTH_TOKEN);
    this.router.navigate(['/login']);
  }
}
