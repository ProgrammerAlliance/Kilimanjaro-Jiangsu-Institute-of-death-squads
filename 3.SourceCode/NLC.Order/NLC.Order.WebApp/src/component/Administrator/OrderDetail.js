import React, {Component} from 'react';
import {bindActionCreators} from 'redux';
import {connect} from 'react-redux';
import {actionCreators} from '../../actions/actions';

export class OrderDetail extends Component {
  render() {
    //console.log(this.props.orderToday.orderPeople);
    return (
      <div className={this.props.order === 'hide' ? 'hide' : ''}>
        <div className="order-detail">
          <div className="fdw-pricing-table">
            <p>
              <select name="dept"
                      id="dept-select"
                      className="select-dept"
                      onChange={e => {
                        this.props.queryOrderToday({
                          rows: 10,
                          page: 1,
                          deptId: e.target.value
                        });
                      }}
              >
                <option value="0">所有部门</option>
                {this.props.select.map((item, index) => {
                  return (
                    <option key={index} value={item.DeptNo}>{item.DeptName}</option>
                  );
                })}
              </select>
            </p>
            <div className="plan plan1">
              <div className="header">
                <h1>订餐详情</h1>
              </div>
              {/*<div className="monthly">per month</div>*/}
              <table id="table-5">
                <thead>
                <tr>
                  <th>编号:</th>
                  <th>姓名:</th>
                  <th>部门:</th>
                </tr>
                </thead>
                <tbody>
                {this.props.orderToday.orderPeople.map((item, index) => {
                  return (
                    <tr className="trow" key={index}>
                      <td>{index + 1 + (this.props.orderToday.currentPage - 1) * 10}</td>
                      <td>{item.UserName}</td>
                      <td>{item.DeptName}</td>
                    </tr>
                  );
                })}
                </tbody>
              </table>
              <ul className="pager">
                <li className={this.props.orderToday.currentPage - 1 > 0 ? '' : 'hide'}>
                  <a href="#" onClick={
                    e => {
                      e.preventDefault();
                      if (this.props.orderToday.currentPage - 1 > 0) {
                        this.props.queryOrderToday({
                          rows: 10,
                          page: this.props.orderToday.currentPage - 1,
                          deptId: 0
                        });
                      }
                    }
                  }><span>&larr;</span> 上一页</a>
                </li>
                <li className={this.props.orderToday.currentPage < this.props.orderToday.totalPage ? '' : 'hide'}>
                  <a href="#" onClick={
                    e => {
                      e.preventDefault();
                      if (this.props.orderToday.currentPage < this.props.orderToday.totalPage) {
                        this.props.queryOrderToday({
                          rows: 10,
                          page: this.props.orderToday.currentPage + 1,
                          deptId: 0
                        });
                      }
                    }
                  }>下一页 <span>&rarr;</span>
                  </a>
                </li>
              </ul>
              <input type="button" value="退出" className="btn btn-primary"
                     onClick={e => {
                       e.preventDefault();
                       this.props.showOrder('hide');
                     }}/>
            </div>
          </div>
        </div>
      </div>
    );
  }
}

export default connect(state => state, (dispatch) => bindActionCreators(actionCreators, dispatch))(OrderDetail);
