import {applyMiddleware, compose, createStore} from 'redux';
import {handlers} from '../actions/actions';
import {apiMiddleware} from 'redux-api-middleware';
import {createRequestTypeHandlerReducer} from '../lib/request';

const middlewares = [apiMiddleware];

/**
 * 设置初始状态
 */
const initialState = {
  url: 'http://192.168.2.69:8080/src/public/images/',
  userType: 'user',
  update: 'hide',
  delete: 'hide',
  order: 'hide',
  login: '',
  user: {},
  star: [
    {UserName: '尚未产生'}
  ],
  add: false,
  addUserBox: 'hide',
  id: 0,
  userInfo: {
    currentPage: 0,
    list: [{UserName: '', UserId: '', UserPwd: ''}],
    totalPage: [1],
    delUser: {}
  },
  orderToday: {
    totalRecord: 0,
    currentPage: 0,
    totalPage: 0,
    orderPeople: [{UserName: ''}]
  },
  select: [{DeptNo: 0, DeptName: ''}]
};

const createStoreEnhanced = compose(applyMiddleware(...middlewares))(createStore);

const createGenericTypeHandlerReducer = handlers => (state = {}, action) => {
  if (handlers && handlers.hasOwnProperty(action.type)) {
    return handlers[action.type](state, action);
  } else {
    return state;
  }
};

const genericTypeHandlerReducer = createGenericTypeHandlerReducer(handlers);
const requestTypeHandlerReducer = createRequestTypeHandlerReducer(handlers);


const reducers = [
  genericTypeHandlerReducer,
  requestTypeHandlerReducer
];

/**
 * Create store
 */
const store = createStoreEnhanced((state = initialState, action) => {
  let prevState = state, nextState = state;

  for (let i = 0; i < reducers.length; i++) {
    const reducer = reducers[i];
    nextState = reducer(prevState, action);

    // break the loop when state changed
    if (prevState !== nextState) {
      break;
    }
  }


  return nextState;
});

export default store;
