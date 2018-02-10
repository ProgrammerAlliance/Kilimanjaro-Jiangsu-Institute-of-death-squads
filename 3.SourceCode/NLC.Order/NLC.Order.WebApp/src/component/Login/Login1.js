import React, {Component} from 'react';
import {bindActionCreators} from 'redux';
import {connect} from 'react-redux';
import {actionCreators} from '../../actions/actions';
import {Link, withRouter} from 'react-router-dom';
import swal from 'sweetalert';

export class Login1 extends Component {
  constructor() {
    super();
    this.state = {
      userId: '',
      Pwd: '',
      Type: '2',
      tip1: '',
      tip2: ''
    };
    this.login = this.login.bind(this);
    this.userId = this.userId.bind(this);
  }

  userId(text) {
    this.setState({
        userId: text,
        tip1: '',
        tip2: '',
      }
    );
    this.props.clearLogin();
  }

  Pwd(text) {
    this.setState({
        Pwd: text,
        tip1: '',
        tip2: '',
      }
    );
    this.props.clearLogin();
  }

  login() {
    let a = this;
    let reg = /^\d{3,6}$/;
    if (this.state.userId.trim() !== '' && this.state.Pwd.trim() !== '') {
      if (reg.test(this.state.userId)) {
        a.props.queryUser({
          UserId: a.state.userId,
          UserPwd: a.state.Pwd,
          UserType: a.props.userType === 'admin' ? 1 : 2
        }).then(function(data) {
          if (data.payload.Status === 200) {
            // if (true) {
            if (a.props.userType === 'admin') {
              a.props.history.push('/admin/number');
              a.props.changeUserType('admin-success');
            }
            else if (a.props.userType === 'user') {
              a.props.history.push('/user/order');
              a.props.changeUserType('user-success');
              a.props.saveUser(data.payload);
            }
          }
          else if (
            data.payload.Status === 405
          ) {
            swal('错误:405!', '数据库异常！', 'error');
          }
          else if (
            data.payload.Status === 500
          ) {
            swal({
              title: '错误:500!',
              text: '服务器异常!',
              type: 'error',
              confirmButtonText: 'Cool'
            });
          }
        });
      }
      else {
        this.setState({
          tip2: 'show'
        });
      }
    }
    else {
      this.setState({
        tip1: 'show'
      });
    }
  }

  render() {
    return (
      <div className="banner">
        <div className="wrap">
          <div className="header-title">
            <h3>登录账号</h3>
          </div>
          <div className="main">
            <form action="">
              <p className="login-tips">
                <b className={this.state.tip2 === '' ? 'hide' : ''}>用户ID只能为数字</b>
                <b
                  className={this.props.login === 200 ||
                  this.props.login === '' ? 'hide' : ''}>
                  用户ID或密码不正确
                </b>
                <b className={this.state.tip1 === '' ? 'opacity' : ''}>用户ID或密码不能为空</b>
              </p>
              <input type="text" className="inputDiv"
                     placeholder="请输入用户ID"
                     onChange={e => {
                       this.userId(e.target.value);
                     }}
              />
              <input type="password" className="inputDiv"
                     placeholder="请输入3-6位密码"
                     onChange={e => {
                       this.Pwd(e.target.value);
                     }}
              />
              <input type="radio"
                     className="user"
                     id="user"
                     name="u"
                     value="user"
                     checked={this.props.userType === 'user'}
                     onChange={e => {
                       this.props.changeUserType(e.target.value);
                     }}
              />
              <label htmlFor="user" className="user">普通用户</label>
              <input type="radio"
                     className="textbox"
                     id="admin"
                     name="u"
                     value="admin"
                     onChange={e => {
                       this.props.changeUserType(e.target.value);
                     }}
              />
              <label htmlFor="admin" className="admin">管理员</label>
              <input type="submit" value="登录" className="inputDiv smBtn"
                     onClick={e => {
                       e.preventDefault();
                       this.login();
                     }}
              />
            </form>
          </div>
        </div>
      </div>
    );
  }
}

export default connect(state => state, (dispatch) => bindActionCreators(actionCreators, dispatch))(Login1);
