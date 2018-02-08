import React, {Component} from 'react';
import {bindActionCreators} from 'redux';
import {connect} from 'react-redux';
import {actionCreators} from '../../actions/actions';
import {Link, withRouter} from 'react-router-dom';
import PersonCenter from './PersonCenter';
import {Route, Router, IndexRoute} from 'react-router';
import TodayOrder from './TodayOrder';
import Info from './PersonInfo';
import Pwd from './UpdatePwd';

const routes = [
  {path: '/user/order', component: TodayOrder},
  {path: '/user/menu/info', component: Info},
  {path: '/user/menu/pwd', component: Pwd},
];

export class User extends Component {
  // componentWillMount() {
  //   this.props.history.push('/user');
  // }

  render() {
    return (
      <div className="banner">
        <ul className="user-person">
          <li><Route path="/user/menu" component={PersonCenter}/></li>
          <li>
            {
              routes.map((route, index) =>
                <Route key={index} path={route.path} component={route.component}/>)
            }
          </li>
        </ul>
      </div>
    );
  }
}

export default connect(state => state, (dispatch) => bindActionCreators(actionCreators, dispatch))(User);
