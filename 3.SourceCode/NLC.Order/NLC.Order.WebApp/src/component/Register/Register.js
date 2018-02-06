import React, {Component} from 'react';
import {bindActionCreators} from 'redux';
import {connect} from 'react-redux';
import {actionCreators} from '../../actions/actions';
import {Link} from 'react-router-dom';

export class Register extends Component {
  render() {
    return (
      <div>
        <div className="banner">
          <div className="container">
            <div className="b_room">
              <div className="booking_room">
                <div className="reservation">
                  <form className="nalong-register">
                    <h2 className="register-title">注册界面</h2>
                    <ul>
                      <li className="span1_of_1">
                        <span>用户名：</span>
                        <input type="text" className="textbox"
                               placeholder="用户名由6-12位字母或数字组成"/>
                        <b>用户名格式不正确</b>
                      </li>
                      <li className="span1_of_1">
                        <span>姓名：</span>
                        <input type="text"
                               className="textbox"
                               placeholder="姓名由2-6位汉字组成"/>
                        <b>姓名格式不正确</b>
                      </li>
                      <li className="span1_of_1">
                        <span>卡号：</span>
                        <input type="text" className="textbox"
                               placeholder="卡号由6-10数字组成"/>
                        <b>卡号格式不正确</b>
                      </li>
                      <li className="span1_of_1">
                        <span>密码：</span>
                        <input type="text" className="textbox"
                               placeholder="密码由6-12数字或字母组成"/>
                        <b>密码格式不正确</b>
                      </li>
                      <li className="span1_of_1">
                        <span>确认密码：</span>
                        <input type="text" className="textbox"
                               placeholder="两次密码必须一致"/>
                        <b>两次密码不一致</b>
                      </li>
                      <li className="span1_of_3">
                        <div className="date_btn">
                          <input type="submit" defaultValue="确认提交"/>
                        </div>
                        <b className="go-login">
                          <Link to="/login">已有账号？去登陆</Link>
                        </b>
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

export default connect(state => state, (dispatch) => bindActionCreators(actionCreators, dispatch))(Register);
