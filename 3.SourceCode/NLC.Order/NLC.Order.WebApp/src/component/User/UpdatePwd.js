import React, {Component} from 'react';
import {bindActionCreators} from 'redux';
import {connect} from 'react-redux';
import {actionCreators} from '../../actions/actions';
import {Link, withRouter} from 'react-router-dom';
import swal from 'sweetalert';

export class UpdatePwd extends Component {
  constructor() {
    super();
    this.state = {
      newPwd1: '',
      newPwd2: '',
      tip1: false,
      tip2: false,
      tip3: false
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
      tip2: false,
      tip3: false,
    });
  }

  updatePwd() {
    let reg = /^\d{3,6}$/;
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
    else if (!reg.test(this.state.newPwd2)) {
      this.setState({
        tip3: true
      });
    }
    else {
      this.props.updatePwd({
        'UserId': this.props.user.UserId,
        'UserPwd': this.state.newPwd2
      }).then(data => {
        if (data.payload.Status === 200 && data.payload.Result) {
          swal('', '密码修改成功！', 'success');
        }
        else if (data.payload.Status === 200 && !data.payload.Result) {
          swal('错误！', '密码修改失败！', 'error');
        }
        else if (data.payload.Status === 405) {
          swal('错误:405！', '数据库异常！', 'error');
        }
        else if (data.payload.Status === 500) {
          swal('错误:500！', '服务器异常！', 'error');
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
              <form action="#">
                <div className="form-group">
                  <label htmlFor="newPwd">新密码：</label>
                  <input type="text" id="newPwd"
                         className="form-control"
                         placeholder="请输入新密码(3-6位数字)"
                         onChange={e => {
                           this.changePwd(e.target.id, e.target.value);
                         }}
                  />
                </div>
                <div className="form-group">
                  <label htmlFor="newPwd2">再次输入新密码：</label>
                  <input type="text" id="newPwd2"
                         className="form-control"
                         placeholder="请再次输入新密码"
                         onChange={e => {
                           this.changePwd(e.target.id, e.target.value);
                         }}
                  />
                </div>
                <b className={this.state.tip1 === false ? 'opacity' : 'pwd-tip'}>输入不能为空！</b>
                <b className={this.state.tip2 === false ? 'hide' : 'pwd-tip'}>两次密码不一致！</b>
                <b className={this.state.tip3 === false ? 'hide' : 'pwd-tip'}>密码由3-6数字组成！</b>
                <div>
                  <input type="submit" value="确认"
                         className="btn btn-lg btn-add btn-primary"
                         onClick={e => {
                           e.preventDefault();
                           this.updatePwd();
                         }}
                  />
                  <input type="submit" value="退出"
                         className="btn btn-lg btn-add btn-primary"
                         onClick={e => {
                           e.preventDefault();
                           this.props.history.push('/user/menu/info');
                         }}
                  />
                </div>
              </form>
            </div>
          </div>

        </div>
      </div>

    );
  }
}

export default connect(state => state, (dispatch) => bindActionCreators(actionCreators, dispatch))(UpdatePwd);
