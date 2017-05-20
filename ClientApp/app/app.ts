import {autoinject, Aurelia} from 'aurelia-framework';
import {Router, RouterConfiguration} from 'aurelia-router';
import {AuthenticateStep, AuthService} from 'aurelia-authentication';

@autoinject
export class App {
  router: Router;

  constructor(private authService: AuthService) {

  }

  configureRouter(config: RouterConfiguration, router: Router) {
    config.title = "Covalence";
    config.addAuthorizeStep(AuthenticateStep);
    config.map([
      { route: '', name: 'home', moduleId: 'pages/home/home', nav: false, title: 'Home' },
      { route: 'search/mentors', name: 'mentors', moduleId: 'pages/search/search', nav: true, title: 'Mentors', auth: true },
      { route: 'search/proteges', name: 'proteges', moduleId: 'pages/search/search', nav: true, title: 'Proteges', auth: true },
      { route: 'profile', name: 'profile', moduleId: 'pages/profile/profile', nav: false, title: 'Profile', auth: true },
      { route: 'login', name: 'login', moduleId: 'pages/login/login', nav: false, title: 'Login' },
      { route: 'register', name: 'register', moduleId: 'pages/register/register', nav: false, title: 'Sign Up' },
      { route: 'logout', name: 'logout', redirect: 'pages/home/home', nav: false, title: 'Logout', auth: true }
    ]);
    this.router = router;
  }
}
