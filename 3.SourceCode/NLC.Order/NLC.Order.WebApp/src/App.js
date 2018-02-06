import React, {Component} from 'react';

import store from './store/store';
import {Provider} from 'react-redux';
import {Route, Router, IndexRoute} from 'react-router';
import createBrowserHistory from 'history/createBrowserHistory';
import {Link, withRouter} from 'react-router-dom';
import Nav from './component/Nav/Nav';
import TodayMenu from './component/TodayMenu';
import Login from './component/Login/Login';
import TodayStar from './component/TodayStar';
import Admin from './component/Administrator';
import User from './component/User';

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
            <Route path="/" component={Login} exact/>
            {
              routes.map((route, index) =>
                <Route key={index} path={route.path} component={route.component}/>)
            }
          </div>
        </Router>
      </Provider>
    );
  }
}
