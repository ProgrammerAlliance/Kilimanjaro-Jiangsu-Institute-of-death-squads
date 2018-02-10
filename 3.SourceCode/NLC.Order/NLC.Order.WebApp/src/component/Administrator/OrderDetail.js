import React, {Component} from 'react';
import {bindActionCreators} from 'redux';
import {connect} from 'react-redux';
import {actionCreators} from '../../actions/actions';
import swal from 'sweetalert';

export class OrderDetail extends Component {
  constructor() {
    super();
    this.handleOrderPeopleToday = this.handleOrderPeopleToday.bind(this);
    this.handleOrderPeopleTodayByDept = this.handleOrderPeopleTodayByDept.bind(this);
  }

  componentDidMount() {
    this.handleOrderPeopleToday(1);
    this.props.queryDept().then(data => {
      //console.log('status', data);
      if (data.payload.Status === 200 && data.payload.Status.Result) {
        swal('错误！', '部门为空！', 'error');
      }
      else if (data.payload.Status === 500) {
        swal('错误:500！', '服务器异常！', 'error');
      }
    });
  }

  handleOrderPeopleTodayByDept(dept) {
    this.props.queryOrderToday({
      rows: 10,
      page: 1,
      deptId: dept
    }).then(data => {
      //console.log('status', data);
      if (data.payload.Status === 200 && data.payload.Result.length === 0) {
        swal('今日未有人订餐！');
      }
      else if (data.payload.Status === 500) {
        swal('错误:500！', '服务器异常！', 'error');
      }
    });

  }

  handleOrderPeopleToday(page) {
    this.props.queryOrderToday({
      rows: 10,
      page: page,
      deptId: 0
    }).then(data => {
      //console.log('status', data);
      if (data.payload.Status === 200 && data.payload.Result.length === 0) {
        swal('今日未有人订餐！');
      }
      else if (data.payload.Status === 500) {
        swal('错误:500！', '服务器异常！', 'error');
      }
    });
  }

  render() {
    //console.log(this.props.orderToday.orderPeople);
    return (
      <div className={this.props.order === 'hide' ? 'hide' : ''}>
        <div className="order-detail">
          <div className="fdw-pricing-table">
            <div className="plan plan1 order-details">
              <div className="header">
                <h1>订餐详情</h1>
              </div>
              <table className="table table-striped table-order">
                <thead>
                  <tr>
                  <th>编号</th>
                  <th>姓名</th>
                  <th><select name="dept"
                              id="dept-select"
                              className="select-dept"
                              onChange={e => {
                                this.handleOrderPeopleTodayByDept(e.target.value);
                              }}
                  >
                    <option value="0">所有部门</option>
                    {this.props.select.map((item, index) => {
                      return (
                        <option key={index} value={item.DeptNo}>{item.DeptName}</option>
                      );
                    })}
                  </select></th>
                  <th>备注</th>
                </tr>
                </thead>
                <tbody>
                  {this.props.orderToday.orderPeople.map((item, index) => {
                  return (
                    <tr className="trow" key={index}>
                      <td>{index + 1 + (this.props.orderToday.currentPage - 1) * 10}</td>
                      <td>{item.UserName}</td>
                      <td>{item.DeptName}</td>
                      <td>{item.Remark}</td>
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
                        this.handleOrderPeopleToday(this.props.orderToday.currentPage - 1);
                      }
                    }
                  }><span>&larr;</span> 上一页</a>
                </li>
                <li className={this.props.orderToday.currentPage < this.props.orderToday.totalPage ? '' : 'hide'}>
                  <a href="#" onClick={
                    e => {
                      e.preventDefault();
                      if (this.props.orderToday.currentPage < this.props.orderToday.totalPage) {
                        this.handleOrderPeopleToday(this.props.orderToday.currentPage + 1);
                      }
                    }
                  }>下一页 <span>&rarr;</span>
                  </a>
                </li>
              </ul>
              <input type="button" value="退出" className="btn btn-lg btn-primary"
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
