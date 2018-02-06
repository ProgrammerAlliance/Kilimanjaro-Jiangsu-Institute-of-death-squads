import React, {Component} from 'react';
import {bindActionCreators} from 'redux';
import {connect} from 'react-redux';
import {actionCreators} from '../../actions/actions';
import {Link} from 'react-router-dom';

export class Contact extends Component {
  componentDidMount() {
    this.props.queryStar();
  }

  render() {
    let url = this.props.url;
    return (
      <div className="today-star">
        <div className="box6">
          <h2>
            今日之星：
          </h2>
          {this.props.star.map((item, index) => {
            return(
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
