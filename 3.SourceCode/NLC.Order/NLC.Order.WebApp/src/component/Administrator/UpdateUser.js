import React, {Component} from 'react';
import {bindActionCreators} from 'redux';
import {connect} from 'react-redux';
import {actionCreators} from '../../actions/actions';
import swal from 'sweetalert';
export class UpdateUser extends Component {
  constructor() {
    super();
    this.state = {
      name: '',
      id: '',
      dept: '',
    };
    this.changeUpdate = this.changeUpdate.bind(this);
  }

  changeUpdate(id, value) {
    if (id === 'update-name') {
      this.setState({
        name: value
      });
    }
  }

  render() {
    return (
      <div className={this.props.update === 'hide' ? 'hide' : ''}>
        <div className="update update-user">
          <div className="animate-box fadeInUp animated-fast">
            <div className="fdw-pricing-table">
              <div className="plan plan1">
                <div className="header">
                  <h1>修改用户信息</h1>
                  <b>(该功能暂未开放...)</b>
                </div>
                <form action="#">
                  {this.props.userInfo.list.map((item, index) => {
                    if (index === this.props.id) {
                      return (
                        <div key={index}>
                          <div className="form-group1" key={index}>
                            <label htmlFor="update-name">姓名：</label>
                            <input type="text" id="update-name"
                                   className="form-control"
                                   placeholder="请输入姓名"
                                   defaultValue={item.UserName}
                                   onChange={e => {
                                     let tar = e.target;
                                     this.changeUpdate(tar.id, tar.value);
                                   }}
                            />
                          </div>
                          <div className="form-group1">
                            <label htmlFor="update-cardId">卡号：</label>
                            <input type="text" id="update-cardId"
                                   className="form-control"
                                   placeholder="请输入卡号"
                                   defaultValue={item.UserId}
                            />
                          </div>
                          <div className="form-group1">
                            <label htmlFor="update-dept">部门：</label>
                            <input type="text" id="update-dept"
                                   className="form-control"
                                   placeholder="请输入部门编号"
                                   defaultValue={item.DeptName}
                            />
                          </div>
                        </div>
                      );
                    }
                  })}
                  <div>
                    <input type="submit" value="确认" className="btn btn-lg btn-primary btn-add"
                           onClick={e => {
                             e.preventDefault();
                             swal('', '该功能尚未开放！', 'error');
                           }}/>
                    <input type="button" value="退出" className="btn btn-lg btn-primary btn-add"
                           onClick={e => {
                             e.preventDefault();
                             this.props.showUpdate('hide', '');
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

export default connect(state => state, (dispatch) => bindActionCreators(actionCreators, dispatch))(UpdateUser);
