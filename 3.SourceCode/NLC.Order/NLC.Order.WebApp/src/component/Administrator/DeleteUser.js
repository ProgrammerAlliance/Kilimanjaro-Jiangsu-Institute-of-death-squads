import React, {Component} from 'react';
import {bindActionCreators} from 'redux';
import {connect} from 'react-redux';
import {actionCreators} from '../../actions/actions';
import swal from 'sweetalert';

export class DeleteUser extends Component {
  constructor() {
    super();
    this.deleteConfirm = this.deleteConfirm.bind(this);
  }

  deleteConfirm() {
    this.props.showDelete('hide');
    this.props.deleteUser({userId: this.props.userInfo.delUser.UserId})
      .then(data => {
        if (data.payload.Status === 200 && data.payload.Result) {
          swal('成功！', '删除成功！', 'success');
        }
        else if (data.payload.Status === 200 && !data.payload.Result) {
          swal('错误！', '删除失败！', 'error');
        }
        else if (data.payload.Status === 405) {
          swal('错误:405！', '数据库异常！', 'error');
        }
        else if (data.payload.Status === 500) {
          swal('错误:500！', '服务器异常！', 'error');
        }
        this.props.queryAllUser({rows: 10, page: this.props.userInfo.currentPage});
      });
  }

  render() {
    return (
      <div className={this.props.delete === 'hide' ? 'hide' : ''}>
        <div className="del-user">
          <h4>你确定要删除姓名为 "{this.props.userInfo.delUser.UserName}" 的用户吗？</h4>
          <input type="button" value="确定" className="btn btn-lg btn-add btn-primary"
                 onClick={e => {
                   e.preventDefault();
                   this.deleteConfirm();
                 }}/>
          <input type="button" value="取消" className="btn btn-lg btn-add btn-primary"
                 onClick={e => {
                   e.preventDefault();
                   this.props.showDelete('hide');
                 }}/>
        </div>
      </div>
    );
  }
}

export default connect(state => state, (dispatch) => bindActionCreators(actionCreators, dispatch))(DeleteUser);
