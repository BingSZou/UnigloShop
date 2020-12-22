import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ProductServices } from './Data/product.service';
import { appRoutes } from './routes'
import { ToastrService } from './common/toaster.service';
import { CartModule } from './cart/cart.module';
import { UserModule } from './user/user.module';
import { ProductModule } from './product/product.module';
import { AuthService } from './user/auth.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(appRoutes),
    ProductModule,
    CartModule,
    UserModule
  ],
  providers: [ProductServices,
              ToastrService,
              AuthService],

  bootstrap: [AppComponent]
})
export class AppModule { }
