import React, {Component} from 'react';
import {bindActionCreators} from 'redux';
import {connect} from 'react-redux';
import {actionCreators} from '../../actions/actions';

export class PersonInfo extends Component {
  render() {
    return (
      <div>
        <div className="fdw-pricing-table">
          <div className="plan plan1">
            <div className="header">
              <h1>个人信息</h1>
            </div>
            {/*<div className="monthly">per month</div>*/}
            <ul>
              <li><b>姓名：</b> {this.props.user.UserName}</li>
              <li><b>卡号：</b> {this.props.user.UserId}</li>
              <li><b>部门：</b> {this.props.user.DeptName}</li>
            </ul>
            {/*<a className="signup">Sign up</a>*/}
          </div>
        </div>
      </div>
    );
  }
}

export default connect(state => state, (dispatch) => bindActionCreators(actionCreators, dispatch))(PersonInfo);
