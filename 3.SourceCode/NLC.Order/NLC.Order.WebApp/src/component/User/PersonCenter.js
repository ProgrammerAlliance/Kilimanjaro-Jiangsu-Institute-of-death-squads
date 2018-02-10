import React, {Component} from 'react';
import {bindActionCreators} from 'redux';
import {connect} from 'react-redux';
import {actionCreators} from '../../actions/actions';
import {Link, withRouter} from 'react-router-dom';

export class Menu extends Component {
  render() {
    return (
      <div className="card-holder opacity">
        <div className="card-wrapper">
          <div className="card bg-01">
            <Link to="/user/menu/info" className="card-content">个人信息</Link>
          </div>
        </div>
        <div className="card-wrapper">
          <div className="card bg-02">
            <Link to="/user/menu/pwd" className="card-content">修改密码</Link>
          </div>
        </div>
      </div>
    );
  }
}

export default connect(state => state, (dispatch) => bindActionCreators(actionCreators, dispatch))(Menu);
