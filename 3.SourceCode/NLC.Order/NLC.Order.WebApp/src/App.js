import React, {Component} from 'react';

import store from './store/store';
import {Provider} from 'react-redux';
import {Route, Router, IndexRoute} from 'react-router';
import createBrowserHistory from 'history/createBrowserHistory';
import {Link, withRouter, Switch} from 'react-router-dom';
import Nav from './component/Nav/Nav';
import TodayMenu from './component/TodayMenu';
import Login from './component/Login/Login';
import TodayStar from './component/TodayStar';
import Admin from './component/Administrator';
import User from './component/User';
// import '../src/public/css/bootstrap.min.css';
// import '../src/public/css/style.css';
// import '../src/public/css/table.css';
// import '../src/public/css/update.css';
// import '../src/public/css/demo.css';
// import '../src/public/css/btn.css';

const history = createBrowserHistory();
/**
 * 自定义路由
 */
const routes = [
  {path: '/todaymenu', component: TodayMenu},
  {path: '/login', component: Login},
  {path: '/contact', component: TodayStar},
  {path: '/admin', component: Admin},
  {path: '/user', component: User},
];

export default class App extends Component {
  render() {
    return (
      <Provider store={store}>
        <Router history={history}>
          <div>
            <Nav/>
            <Switch>
              <Route path="/" component={Login} exact/>
              {
                routes.map((route, index) =>
                  <Route key={index} path={route.path} component={route.component}/>)
              }
            </Switch>
          </div>
        </Router>
      </Provider>
    );
  }
}
