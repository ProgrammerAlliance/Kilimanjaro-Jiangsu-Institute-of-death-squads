import React, {Component} from 'react';
import {bindActionCreators} from 'redux';
import {connect} from 'react-redux';
import {actionCreators} from '../../actions/actions';

export class UpdatePwd extends Component {
  constructor() {
    super();
    this.state = {
      newPwd1: '',
      newPwd2: '',
      tip1: false,
      tip2: false,
      update: false
    };
    this.changePwd = this.changePwd.bind(this);
    this.updatePwd = this.updatePwd.bind(this);
  }

  changePwd(id, val) {
    if (id === 'newPwd') {
      this.setState({
        newPwd1: val
      });
    }
    else {
      this.setState({
        newPwd2: val
      });
    }
    this.setState({
      tip1: false,
      tip2: false
    });
  }

  updatePwd() {
    if (
      this.state.newPwd1.trim() === '' ||
      this.state.newPwd2.trim() === ''
    ) {
      this.setState({
        tip1: true
      });
    } else if (this.state.newPwd1 !== this.state.newPwd2) {
      this.setState({
        tip2: true
      });
    }
    else {
      // console.log(this.props.user,this.props.user.userId);
      this.props.updatePwd({
        'userId': this.props.user.UserId,
        'newPassword': this.state.newPwd2
      }).then(data => {
        console.log(data);
        if (data.payload.Status === 200) {
          this.setState({
            update: true
          });
        }
      });
    }
  }

  render() {
    return (
      <div className="update">
        <div className="animate-box fadeInUp animated-fast">
          <div className="fdw-pricing-table">
            <div className="plan plan1">
              <div className="header">
                <h1>修改密码</h1>
              </div>
              {/*<div className="monthly">per month</div>*/}
              <form action="#">
                {/*<div className="form-group">*/}
                {/*<label htmlFor="oldPwd">旧密码：</label>*/}
                {/*<input type="text" id="oldPwd"*/}
                {/*className="form-control"*/}
                {/*placeholder="请输入旧密码"*/}
                {/*onChange={e => {*/}
                {/*this.changePwd(e.target.id, e.target.value);*/}
                {/*}}*/}
                {/*/>*/}
                {/*</div>*/}
                <div className="form-group">
                  <label htmlFor="newPwd">新密码：</label>
                  <input type="text" id="newPwd"
                         className="form-control"
                         placeholder="请输入旧密码"
                         onChange={e => {
                           this.changePwd(e.target.id, e.target.value);
                         }}
                  />
                </div>
                <div className="form-group">
                  <label htmlFor="newPwd2">再次输入新密码：</label>
                  <input type="text" id="newPwd2"
                         className="form-control"
                         placeholder="请输入新密码"
                         onChange={e => {
                           this.changePwd(e.target.id, e.target.value);
                         }}
                  />
                </div>
                <b className={this.state.tip1 === false ? 'hide' : 'pwd-tip'}>输入不能为空！</b>
                <b className={this.state.tip2 === false ? 'hide' : 'pwd-tip'}>两次密码不一致！</b>
                <div>
                  <input type="submit" value="确认修改"
                         className="btn btn-primary"
                         onClick={e => {
                           e.preventDefault();
                           this.updatePwd();
                         }}
                  />
                </div>
                <div className={this.state.update === false ? 'hide' : 'update-success1'}>
                  <h4>密码修改成功！</h4>
                  <input type="button" value="退出" className="btn btn-primary"
                         onClick={e => {
                           e.preventDefault();
                           this.setState({
                             update: false
                           });
                         }}/>
                </div>
              </form>
              {/*<a className="signup">Sign up</a>*/}
            </div>
          </div>

        </div>
      </div>

    );
  }
}

export default connect(state => state, (dispatch) => bindActionCreators(actionCreators, dispatch))(UpdatePwd);