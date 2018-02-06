import React, {Component} from 'react';
import {bindActionCreators} from 'redux';
import {connect} from 'react-redux';
import {actionCreators} from '../../actions/actions';
import {Route, Router, IndexRoute} from 'react-router';
import PersonManage from './PersonManage';
import PersonNumber from './PersonNumber';

const routes = [
  {path: '/admin/number', component: PersonNumber},
  {path: '/admin/manage', component: PersonManage},
];

export class Admin extends Component {
  render() {
    return (
      <div>
        {
          routes.map((route, index) =>
            <Route key={index} path={route.path} component={route.component}/>)
        }
      </div>
    );
  }
}

export default connect(state => state, (dispatch) => bindActionCreators(actionCreators, dispatch))(Admin);
