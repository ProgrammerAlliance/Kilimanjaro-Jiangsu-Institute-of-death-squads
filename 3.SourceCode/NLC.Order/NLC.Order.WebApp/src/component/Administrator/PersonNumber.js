import React, {Component} from 'react';
import {bindActionCreators} from 'redux';
import {connect} from 'react-redux';
import {actionCreators} from '../../actions/actions';
import OrderDetail from './OrderDetail';
import swal from 'sweetalert';

export class PersonNumber extends Component {

  render() {
    return (
      <div>
        <div className="fdw-pricing-table">
          <div className="plan plan1">
            <div className="header">
              <h1>统计人数</h1>
            </div>
            {/*<div className="monthly">per month</div>*/}
            <ul>
              <li>
                <h3>
                  <b>订餐总人数：</b> {this.props.orderToday.totalRecord}人
                </h3>
              </li>
              <li>
                <h3>
                  <b>预计订餐金额：</b> {this.props.orderToday.totalRecord * 20}元
                </h3>
              </li>
              <li>
                <a href="#" className="a-btn1"
                   onClick={
                     e => {
                       e.preventDefault();
                       this.props.showOrder('show');
                     }
                   }
                >
                  <span className="a-btn1-text">查看详情</span>
                  <span className="a-btn1-slide-text">订餐人员</span>
                  <span className="a-btn1-icon-right"><span/></span>
                </a>
              </li>
              <li className={new Date().getHours() <= 24 &&
              new Date().getHours() >= 0 ?
                '' : 'hide'}>
                <a href="#" className="a-btn" onClick={() => {
                  this.props.todayStar().then(data => {
                    if (data.payload.Status === 200) {
                      swal('成功', '打扫人员产生成功！', 'success');
                    }
                    else if (data.payload.Status === 303) {
                      swal('错误:303！', '无人订餐！', 'error');
                    }
                    else if (data.payload.Status === 405) {
                      swal('错误:404！', '未到订餐截止时间！', 'error');
                    }
                    else if (data.payload.Status === 500) {
                      swal('错误：500！', '服务器异常！', 'error');
                    }
                  });
                  this.props.queryIsHaveStar().then(data => {
                    if (data.payload.Status === 200 && data.payload.Result) {
                      swal('错误！', '已有打扫人员！', 'error');
                    }
                    else if (data.payload.Status === 500) {
                      swal('错误:500！', '服务器异常！', 'error');
                    }
                  });
                }}>
                  <span/>
                  <span>今日之星</span>
                  <span>就是你了!</span>
                </a>
              </li>
            </ul>
          </div>
        </div>
        <OrderDetail/>
      </div>
    );
  }
}

export default connect(state => state, (dispatch) => bindActionCreators(actionCreators, dispatch))(PersonNumber);
