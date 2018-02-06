import React, {Component} from 'react';
import {bindActionCreators} from 'redux';
import {connect} from 'react-redux';
import {actionCreators} from '../../actions/actions';
import {Link, withRouter} from 'react-router-dom';

export class Login extends Component {
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

  componentDidMount() {
    this.props.queryDept();
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
    let reg = /\d/;
    if (this.state.userId.trim() !== '' && this.state.Pwd.trim() !== '') {
      if (reg.test(this.state.userId)) {
        a.props.queryUser({
          userId: a.state.userId,
          Pwd: a.state.Pwd,
          Type: a.props.userType === 'admin' ? 1 : 2
        }).then(function(data) {
          if (data.payload.Status === 200) {
            //console.log('登录成功');
            if (a.props.userType === 'admin') {
              a.props.history.push('/admin');
              //console.log('登录管理员');
              a.props.changeUserType('admin-success');
            }
            else if (a.props.userType === 'user') {
              a.props.history.push('/user');
              //console.log('登录用户');
              a.props.changeUserType('user-success');
              a.props.saveUser(data.payload);
            }
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
      <div>
        <div className="banner">
          <div className="container">
            <div className="b_room">
              <div className="booking_room">
                <div className="reservation">
                  <form className="nalong-register">
                    <h2 className="register-title">登陆界面</h2>
                    <ul>
                      <li className="span1_of_1">
                        <span>用户ID：</span>
                        <input type="text" className="textbox"
                               placeholder="请输入用户卡号！"
                               onChange={e => {
                                 this.userId(e.target.value);
                               }}
                        />
                      </li>
                      <li className="span1_of_1">
                        <span>密码：</span>
                        <input type="text" className="textbox"
                               placeholder="请输入密码！"
                               onChange={e => {
                                 this.Pwd(e.target.value);
                               }}
                        />
                        {/*<b>login:{this.props.login}</b>*/}
                        <b
                          className={this.props.login === 200 || this.props.login === '' ? 'hide' : 'tip'}>用户ID或密码不正确</b>
                        <b className={this.state.tip1 === '' ? 'hide' : 'tip'}>用户ID或密码不能为空</b>
                        <b className={this.state.tip2 === '' ? 'hide' : 'tip'}>用户ID只能为数字</b>
                      </li>
                      <li className="span1_of_1">
                        <label htmlFor="admin" className="admin">
                          管理员
                          <input type="radio"
                                 className="textbox"
                                 id="admin"
                                 name="u"
                                 value="admin"
                                 onChange={e => {
                                   this.props.changeUserType(e.target.value);
                                 }}
                          />
                        </label>
                        <label htmlFor="user">
                          普通用户
                          <input type="radio"
                                 className="textbox"
                                 id="user"
                                 name="u"
                                 value="user"
                                 checked={this.props.userType === 'user'}
                                 onChange={e => {
                                   this.props.changeUserType(e.target.value);
                                 }}
                          />
                        </label>
                      </li>
                      <li className="span1_of_3">
                        <div className="date_btn">
                          <input
                            type="submit"
                            defaultValue="登陆"
                            onClick={e => {
                              e.preventDefault();
                              this.login();
                            }}
                          />
                        </div>
                      </li>
                      <div className="clearfix"/>
                    </ul>
                  </form>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    );
  }
}

export default connect(state => state, (dispatch) => bindActionCreators(actionCreators, dispatch))(Login);
