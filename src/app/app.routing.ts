import { NgModule } from '@angular/core';
import { RouterModule, PreloadAllModules } from '@angular/router';
import{UserComponent} from './user/user.component';
import{AboutComponent} from './about/about.component';
import{LoginComponent} from "./login/login.component";

@NgModule({
    imports: [
    RouterModule.forRoot([
         { path: 'user', component: UserComponent },
         { path: 'about', component: AboutComponent },
         { path: 'login',component: LoginComponent}


    ],{preloadingStrategy:PreloadAllModules})
  ],
  exports:[RouterModule]
 })
export class AppRoutingModule {}
