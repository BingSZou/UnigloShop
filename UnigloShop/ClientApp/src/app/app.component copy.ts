import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styles: [`
            .site-branding {
              background-color: rgb(79, 102, 15);
              display: flex;
              text-align: center;
              color: white;
            }
            .site-header {
              margin: auto;
            }
            .site-branding a {
                color: white;
                width: 100%;
            }
            .login-and-basket {
              display: flex;
              margin: 2rem;
            }
        `]
})
export class AppComponent {
  title = 'ekotee';
}
