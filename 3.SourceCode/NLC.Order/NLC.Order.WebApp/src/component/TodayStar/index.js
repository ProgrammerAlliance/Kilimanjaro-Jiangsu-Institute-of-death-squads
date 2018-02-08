import React, {Component} from 'react';
import {bindActionCreators} from 'redux';
import {connect} from 'react-redux';
import {actionCreators} from '../../actions/actions';
import {Link} from 'react-router-dom';
import swal from 'sweetalert';

export class Contact extends Component {
  componentDidMount() {
    this.props.queryStar().then(data => {
      if (data.payload.Status === 200 && data.payload.Result.length === 0) {
        //swal('', '未有打扫人员！', 'success');
      }
      else if (data.payload.Status === 500) {
        swal('错误:500！', '服务器异常！', 'error');
      }
    });
  }

  render() {
    let url = this.props.url;
    return (
      <div className="today-star banner">
        <div className="box6">
          <h2>
            今日之星：
          </h2>
          {this.props.star.map((item, index) => {
            return (
              <h3 key={index}><b>{item.UserName}</b></h3>
            );
          })}

          <img
            src={url + 'todayStar.jpg'}
            className="img-responsive" alt=""/>
          <p>不就是吃饭几十个人就刚好选到你了嘛！</p>
          <p>不就是吃饭几十个人就刚好选到你了嘛！</p>
          <p>不就是吃饭几十个人就刚好选到你了嘛！</p>
          <p>不就是吃饭几十个人就刚好选到你了嘛！</p>
          <div className="box6_corner_lf"/>
          <div className="box6_corner_rt"/>
        </div>
      </div>
    );
  }
}

export default connect(state => state, (dispatch) => bindActionCreators(actionCreators, dispatch))(Contact);
