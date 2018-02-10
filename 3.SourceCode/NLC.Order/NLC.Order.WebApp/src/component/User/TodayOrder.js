import React, {Component} from 'react';
import {bindActionCreators} from 'redux';
import {connect} from 'react-redux';
import {actionCreators} from '../../actions/actions';
import swal from 'sweetalert';

export class TodayOrder extends Component {
  constructor() {
    super();
    this.state = {
      elememt: '时间',
      remark: '',
      end: 16
    };
    this.ticking = this.ticking.bind(this);
    this.handleOrderConfirm = this.handleOrderConfirm.bind(this);
    this.handleOrderCancel = this.handleOrderCancel.bind(this);
    this.addLabel = this.addLabel.bind(this);
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

  handleOrderConfirm() {
    let orderConfirm = {
      UserId: this.props.user.UserId,
      Remark: this.state.remark
    };
    this.props.orderConfirm(orderConfirm)
      .then((data) => {
        if (data.payload.Status === 200 && data.payload.Result) {
          this.props.addOne(true);
          swal('成功', '订餐成功！', 'success');
        }
        else if (data.payload.Status === 200 && !data.payload.Result) {
          swal('错误！', '订餐失败！', 'error');
        }
        else if (data.payload.Status === 404) {
          swal('错误:404！', '已超过订餐时间！', 'error');
        }
        else if (data.payload.Status === 201) {
          swal('错误:201！', '您今日已订餐！', 'error');
        }
        else if (data.payload.Status === 500) {
          swal('错误:500！', '服务器异常！', 'error');
        }
      });
  }

  handleOrderCancel() {
    let orderCancel = {
      UserId: this.props.user.UserId
    };
    this.props.orderCancel(orderCancel)
      .then((data) => {
        if (data.payload.Status === 200 && data.payload.Result) {
          this.props.addOne(false);
          swal('成功', '取消成功！', 'success');
        }
        else if (data.payload.Status === 500) {
          swal('错误:500！', '服务器异常！', 'error');
        }
      });
  }

  addLabel(e) {
    let remark = this.state.remark;
    remark += ' ' + e.target.value;
    if (remark.length <= 20) {
      this.setState({
        remark: remark
      });
    }
    else {
      swal('添加失败！', '已超过20个字符长度！', 'error');
    }
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
              <h4>提醒：请在每天17:00之前确定加餐</h4>
            </div>
            <ul>
              <li>
                <b className="order-state">状态：</b>
                <b className="order-state">{this.props.add === false ? '未加餐' : '已加餐'}</b>
              </li>
              <li className={new Date().getHours() <= this.state.end
              && this.props.add === false
                ? '' : 'hide'}>
                <h4>备注：</h4>
                <textarea
                  name="remark"
                  id="remark"
                  className="remark"
                  maxLength="20"
                  value={this.state.remark}
                  placeholder="最多20字！"
                  onChange={e => {
                    this.setState({
                      remark: e.target.value
                    });
                  }}
                />
              </li>
              <li className={new Date().getHours() <= this.state.end
              && this.props.add === false
                ? 'label1' : 'hide'}>
                {this.props.label1.map((item, index) => {
                  return (
                    <input type="button"
                           key={index}
                           className="btn1 pbtn1"
                           value={item}
                           onClick={e => {
                             this.addLabel(e);
                           }}
                    />
                  );
                })}
              </li>
              <li className={new Date().getHours() <= this.state.end
              && this.props.add === false
                ? 'label1' : 'hide'}>
                {this.props.label2.map((item, index) => {
                  return (
                    <input type="button"
                           className="btn1 pbtn1"
                           key={index}
                           value={item}
                           onClick={e => {
                             this.addLabel(e);
                           }}
                    />
                  );
                })}
              </li>
              <li className={new Date().getHours() > 16 ? '' : 'hide'}>
                <b>未到或已过订取餐+1时间，无法订餐！</b>
              </li>
              <li><a className={new Date().getHours() <= 24 ?
                'btn btn-lg btn-primary' : 'hide'} href="" onClick={
                e => {
                  e.preventDefault();
                  if (this.props.add === false) {
                    this.handleOrderConfirm();
                  }
                  else if (this.props.add === true) {
                    this.handleOrderCancel();
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
    )
      ;
  }
}

export default connect(state => state, (dispatch) => bindActionCreators(actionCreators, dispatch))(TodayOrder);
