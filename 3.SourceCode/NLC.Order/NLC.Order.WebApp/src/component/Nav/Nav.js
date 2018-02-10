import React, {Component} from 'react';
import {bindActionCreators} from 'redux';
import {connect} from 'react-redux';
import {actionCreators} from '../../actions/actions';
import {Link} from 'react-router-dom';

export class Nav extends Component {
  render() {
    let url = this.props.url;
    return (
      <div>
        <div className="head-top"/>
        <div className="header">
          <div className="container">
            <div className="logo">
              <b className="logo-title">纳龙科技</b>
              <span className={this.props.userType !== 'admin-success'
              && this.props.userType !== 'user-success' ? 'visible' : 'title'}>
                欢迎回来，<b>{this.props.userType === 'user-success'
                ? this.props.user.UserName : '管理员'}</b>
                <b style={{opacity: 0}}>000</b>
                <Link to="/" onClick={() => {
                  this.props.changeUserType('user');
                }}>注销</Link>
              </span>
            </div>
            <div className="header-left">
              <div className="head-nav">
                <span className="menu"/>
                <ul>
                  <li className={this.props.userType === 'user-success' ? '' : 'visible'}>
                    <ul>
                      <li><Link to="/user/menu/info">个人中心 </Link></li>
                      <li><Link to="/user/order">今日订餐 </Link></li>
                      <li><Link to="/contact">今日之星</Link></li>
                    </ul>
                  </li>
                  <li className={this.props.userType === 'admin-success' ? '' : 'visible'}>
                    <ul>
                      <li><Link to="/admin/manage">用户管理</Link></li>
                      <li><Link to="/admin/number">统计人数</Link></li>
                      <li><Link to="/contact">今日之星</Link></li>
                    </ul>
                  </li>
                  <li
                    className={this.props.userType !== 'admin-success'
                    && this.props.userType !== 'user-success' ? '' : 'visible'}>
                    <ul>
                      <li><Link to="/login">登录</Link></li>
                      <li><Link to="/contact">今日之星</Link></li>
                    </ul>
                  </li>
                  <div className="clearfix"/>
                </ul>
              </div>
              <div className="clearfix"/>
            </div>
            <div className="clearfix"/>
          </div>
        </div>
      </div>
    );
  }
}

export default connect(state => state, (dispatch) => bindActionCreators(actionCreators, dispatch))(Nav);
