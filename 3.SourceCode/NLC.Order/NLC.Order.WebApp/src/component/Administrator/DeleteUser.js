import React, {Component} from 'react';
import {bindActionCreators} from 'redux';
import {connect} from 'react-redux';
import {actionCreators} from '../../actions/actions';

export class DeleteUser extends Component {
  render() {
    return (
      <div className={this.props.delete === 'hide' ? 'hide' : ''}>
        <div className="del-user">
          <h4>你确定要删除姓名为 "{this.props.userInfo.delUser.UserName}" 的用户吗？</h4>
          <input type="button" value="确定" className="btn btn-primary"
                 onClick={e => {
                   e.preventDefault();
                   this.props.showDelete('hide');
                   this.props.deleteUser({userId: this.props.userInfo.delUser.UserId})
                     .then(() => {
                     this.props.queryAllUser({rows: 10, page: this.props.userInfo.currentPage});
                   });
                 }}/>
          <input type="button" value="取消" className="btn btn-primary"
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
