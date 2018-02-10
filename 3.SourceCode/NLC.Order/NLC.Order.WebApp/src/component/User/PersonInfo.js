import React, {Component} from 'react';
import {bindActionCreators} from 'redux';
import {connect} from 'react-redux';
import {actionCreators} from '../../actions/actions';
import {Link} from 'react-router-dom';

export class PersonInfo extends Component {
  render() {
    return (
      <div>
        <div className="fdw-pricing-table">
          <div className="plan plan1">
            <div className="header">
              <h1>个人信息</h1>
            </div>
            <ul className="user-info">
              <li><b>姓名：</b> {this.props.user.UserName}</li>
              <li><b>卡号：</b> {this.props.user.UserId}</li>
              <li><b>部门：</b> {this.props.user.DeptName}</li>
              <li><b>密码：</b> <Link to="/user/menu/pwd">修改</Link></li>
            </ul>
          </div>
        </div>
      </div>
    );
  }
}

export default connect(state => state, (dispatch) => bindActionCreators(actionCreators, dispatch))(PersonInfo);
