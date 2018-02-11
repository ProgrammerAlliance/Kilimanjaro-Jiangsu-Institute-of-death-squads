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
    return (
      <div className="today-star banner">
        <div className="update update-user">
          <div className="animate-box fadeInUp animated-fast">
            <div className="fdw-pricing-table">
              <div className="plan plan1 header-star">
                <div className="header">
                  <h1>今日之星</h1>
                </div>
                <div className="monthly">
                  {this.props.star.map((item, index) => {
                    return (
                      <h2 key={index}><b>{item.UserName}</b></h2>
                    );
                  })}
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    );
  }
}

export default connect(state => state, (dispatch) => bindActionCreators(actionCreators, dispatch))(Contact);
