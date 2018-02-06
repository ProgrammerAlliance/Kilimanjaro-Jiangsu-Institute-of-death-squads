import React, {Component} from 'react';
import {bindActionCreators} from 'redux';
import {connect} from 'react-redux';
import {actionCreators} from '../../actions/actions';

export class TodayMenu extends Component {
  render() {
    return (
      <div>
        <h1>今日菜单</h1>
      </div>
    );
  }
}

export default connect(state => state, (dispatch) => bindActionCreators(actionCreators, dispatch))(TodayMenu);
