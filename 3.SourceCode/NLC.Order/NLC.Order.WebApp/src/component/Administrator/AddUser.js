import React, {Component} from 'react';
import {bindActionCreators} from 'redux';
import {connect} from 'react-redux';
import {actionCreators} from '../../actions/actions';
import swal from 'sweetalert';

export class AddUser extends Component {
  constructor() {
    super();
    this.state = {
      UserId: '',
      UserName: '',
      UserPwd: 111,
      Deptno: 1,
      UserType: 2,
      Gender: '男',
      cardTip: 'hide',
      tip: 'hide',
      cardTip2: 'hide'
    };
    this.addUserInfo = this.addUserInfo.bind(this);
    this.addConfirm = this.addConfirm.bind(this);
    this.addCancel = this.addCancel.bind(this);
  }

  addUserInfo(id, val) {
    switch (id) {
      case 'add-name':
        this.setState({
          UserName: val
        });
        break;
      case 'add-cardId':
        this.setState({
          UserId: val
        });
        break;
      case 'male':
        this.setState({
          Gender: val
        });
        break;
      case 'female':
        this.setState({
          Gender: val
        });
        break;
      case 'add-dept':
        this.setState({
          Deptno: val
        });
        break;
      default:
    }
    this.setState({
      cardTip: 'hide',
      tip: 'hide',
      cardTip2: 'hide'
    });
  }

  add() {
    this.props.addUser(
        {
        UserId: parseInt(this.state.UserId),
        UserName: this.state.UserName,
        UserPwd: this.state.UserPwd,
        Deptno: this.state.Deptno,
        UserType: this.state.UserType,
        Gender: this.state.Gender
      }
    ).then(data => {
      if (data.payload.Status === 200 && data.payload.Result) {
        swal('成功！', '添加成功！', 'success');
        this.props.showAdd('hide');
        this.props.queryAllUser({rows: 10, page: 1});
        this.setState({
          UserId: '',
          UserName: '',
          UserPwd: 111,
          Deptno: 1,
          UserType: 2,
          Gender: '男',
          cardTip: 'hide',
          cardTip2: 'hide',
          tip: 'hide'
        });
      }
      else if (data.payload.Status === 200 && !data.payload.Result) {
        swal('错误！', '添加失败！', 'error');
      }
      else if (data.payload.Status === 405) {
        swal('错误:405！', '数据库异常！', 'error');
      }
      else if (data.payload.Status === 500) {
        swal('错误:500！', '服务器异常！', 'error');
      }
      else if (data.payload.Status === 201) {
        this.setState({
          cardTip: 'show'
        });
      }
    });
  }

  addConfirm() {
    let reg = /^\d{4}$/;
    if (
      this.state.UserName.trim() === ''
      || this.state.UserId.trim() === '') {
      this.setState({tip: 'show'});
    }
    else if (!reg.test(this.state.UserId)) {
      this.setState({cardTip2: 'show'});
    }
    else {
      this.add();
    }
  }

  addCancel() {
    this.setState({
      cardTip: 'hide',
      tip: 'hide',
      UserId: '',
      UserName: '',
      UserPwd: 111,
      Deptno: 1,
      UserType: 2,
      Gender: '男',
    });
    this.props.showAdd('hide');
  }

  render() {
    return (
      <div className={this.props.addUserBox === 'hide' ? 'hide' : ''}>
        <div className="update-background"/>
        <div className="update update-user">
          <div className="animate-box fadeInUp animated-fast">
            <div className="fdw-pricing-table">
              <div className="plan plan1">
                <div className="header">
                  <h1>添加用户信息</h1>
                </div>
                <form action="#">
                  <div className="form-group1">
                    <label htmlFor="add-name">姓名：</label>
                    <input type="text" id="add-name" className="form-control"
                           placeholder="请输入姓名"
                           value={this.state.UserName}
                           onChange={e => {
                             this.addUserInfo(e.target.id, e.target.value);
                           }}/>
                  </div>
                  <div className="form-group1">
                    <label htmlFor="add-cardId">卡号：</label>
                    <input type="text" id="add-cardId" className="form-control"
                           placeholder="请输入卡号"
                           value={this.state.UserId}
                           onChange={e => {
                             this.addUserInfo(e.target.id, e.target.value);
                           }}/>
                    <b className={this.state.cardTip === 'hide'
                      ? 'hide' : 'card-tip tip'}>卡号重复！</b>
                    <b className={this.state.cardTip2 === 'hide'
                      ? 'hide' : 'card-tip tip'}>卡号只能为4位数字！</b>
                  </div>
                  <div className="form-group1">
                    <div className="group">
                      <label htmlFor="add-sex">性别：</label>
                      <label htmlFor="male" className="sex">男</label>
                      <input type="radio" name="sex" value="男" id="male" checked={this.state.Gender === '男'}
                             onChange={e => {
                               this.addUserInfo(e.target.id, e.target.value);
                             }}/>
                      <label htmlFor="female" className="sex">女</label>
                      <input type="radio" name="sex" value="女" id="female" onChange={e => {
                        this.addUserInfo(e.target.id, e.target.value);
                      }}/>
                    </div>
                  </div>
                  <div className="form-group1">
                    <div className="group">
                      <label htmlFor="add-dept">部门：</label>
                      <select name="dept" id="add-dept"
                              value={this.state.Deptno}
                              onChange={e => {
                                this.addUserInfo(e.target.id, e.target.value);
                              }}>
                        {this.props.select.map((item, index) => {
                          return (
                            <option key={index} value={item.DeptNo}>{item.DeptName}</option>
                          );
                        })}
                      </select>
                    </div>
                  </div>
                  <h5 className={this.state.tip === 'hide'
                    ? 'hide' : 'tip'}>请填写完整！</h5>
                  <div>
                    <input type="submit" value="确认" className="btn btn-lg btn-primary btn-add"
                           onClick={e => {
                             e.preventDefault();
                             this.addConfirm();
                           }}/>
                    <input type="button" value="退出" className="btn btn-lg btn-primary btn-add"
                           onClick={e => {
                             e.preventDefault();
                             this.addCancel();
                           }}/>
                  </div>
                </form>
              </div>
            </div>
          </div>
        </div>
      </div>

    );
  }
}

export default connect(state => state, (dispatch) => bindActionCreators(actionCreators, dispatch))(AddUser);
