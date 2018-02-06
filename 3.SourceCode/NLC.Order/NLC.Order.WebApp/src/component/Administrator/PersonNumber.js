import React, {Component} from 'react';
import {bindActionCreators} from 'redux';
import {connect} from 'react-redux';
import {actionCreators} from '../../actions/actions';
import OrderDetail from './OrderDetail';

export class PersonNumber extends Component {
  componentDidMount() {
    this.props.queryOrderToday({rows: 10, page: 1, deptId: 0});
  }

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
              new Date().getHours() >= 17 ?
                '' : 'hide'}>
                <a href="#" className="a-btn" onClick={() => {
                  this.props.todayStar();
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
