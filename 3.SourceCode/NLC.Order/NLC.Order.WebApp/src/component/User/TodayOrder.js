import React, {Component} from 'react';
import {bindActionCreators} from 'redux';
import {connect} from 'react-redux';
import {actionCreators} from '../../actions/actions';

export class TodayOrder extends Component {
  constructor() {
    super();
    this.state = {
      elememt: '时间'
    };
    this.ticking = this.ticking.bind(this);
  }

  componentDidMount() {
    setInterval(this.ticking, 1000);
    this.props.addOne(this.props.user.IsOrder);
  }

  ticking() {
    this.setState({
      element: new Date().toLocaleTimeString()
    });
  }

  render() {
    return (
      <div className="today-order">
        <div className="fdw-pricing-table">
          <div className="plan plan1">
            <div className="header">
              <h1>今日订餐</h1>
            </div>
            <div className="monthly">
              <p>提醒：请在每天0:00至24:00之间确定加餐</p>
            </div>
            <ul>
              <li><b>状态：</b>{this.props.add === false ? '未加餐' : '已加餐'}</li>
              <li className={new Date().getHours() < 24 ||
              new Date().getHours() > 0 ?
                'hide' : ''}><b>未到或已过订餐+1时间，无法订餐！</b></li>
              <li><a className={new Date().getHours() < 24 ||
              new Date().getHours() > 0 ?
                'signup' : 'hide'} href="" onClick={
                e => {
                  e.preventDefault();
                  let orderConfirm = {
                    UserId: this.props.user.UserId,
                    Remark: ''
                  };
                  let orderCancel = {
                    userId: this.props.user.UserId
                  };
                  if (this.props.add === false) {
                    this.props.orderConfirm({order: JSON.stringify(orderConfirm)})
                      .then((data) => {
                        // console.log('+1');
                        // console.log(data.payload.Status);
                        if (data.payload.Status === 200) {
                          this.props.addOne(true);
                        }
                      });
                  }
                  else if (this.props.add === true) {
                    this.props.orderCancel(orderCancel)
                      .then((data) => {
                        // console.log('-1');
                        // console.log(data.payload.Status);
                        if (data.payload.Status === 200) {
                          this.props.addOne(false);
                        }
                      });
                  }


                }
              }>{this.props.add === false ? '确定加餐+1' : '取消加餐-1'}</a></li>
              <li>
                {this.state.element}
              </li>
            </ul>
          </div>
        </div>
      </div>
    );
  }
}

export default connect(state => state, (dispatch) => bindActionCreators(actionCreators, dispatch))(TodayOrder);
