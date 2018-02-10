import request, {onSuccess} from '../lib/request';

let http = 'http://127.0.0.1:9999/api/';
let httpUser = http + 'User/';
let httpDept = http + 'Dept/';
let httpOrder = http + 'Order/';

export const actions = {
  CHANGE_USER_TYPE: 'CHANGE_USER_TYPE',
  QUERY_USER: 'QUERY_USER',
  SHOW_UPDATE: 'SHOW_UPDATE',
  SHOW_DELETE: 'SHOW_DELETE',
  SHOW_ORDER: 'SHOW_ORDER',
  SHOW_ADD: 'SHOW_ADD',
  CLEAR_LOGIN: 'CLEAR_LOGIN',
  SAVE_USER: 'SAVE_USER',
  ADD_ONE: 'ADD_ONE',
  ORDER_CONFIRM: 'ORDER',
  ORDER_CANCEL: 'ORDER_CANCEL',
  UPDATE_PWD: 'UPDATE_PWD',
  QUERY_ALL_USERS: 'QUERY_ALL_USERS',
  GET_ORDER_TODAY: 'GET_ORDER_TODAY',
  SAVE_DEL_USER: 'SAVE_DEL_USER',
  ADD_USER: 'ADD_USER',
  DEL_USER: 'DEL_USER',
  TODAY_STAR: 'TODAY_STAR',
  QUERY_STAR: 'QUERY_STAR',
  QUERY_DEPT: 'QUERY_DEPT',
  QUERY_IS_HAVE_STAR: 'QUERY_IS_HAVE_STAR',
};

export const actionCreators = {
  queryUser: (params) =>
    request.get(httpUser + 'GetLogin', params)(actions.QUERY_USER),
  orderConfirm: (params) =>
    request.post(httpOrder + 'PostAddOrder', params)(actions.ORDER_CONFIRM),
  orderCancel: (params) =>
    request.delete(httpOrder + 'DeleteOrder', params)(actions.ORDER_CANCEL),
  updatePwd: (params) =>
    request.put(httpUser + 'PutModifyPassword', params)(actions.UPDATE_PWD),
  queryAllUser: (params) =>
    request.get(httpUser + 'GetAllUser', params)(actions.QUERY_ALL_USERS),
  queryOrderToday: (params) =>
    request.get(httpOrder + 'GetOrderPeople', params)(actions.GET_ORDER_TODAY),
  addUser: (params) =>
    request.post(httpUser + 'PostAddUser', params)(actions.ADD_USER),
  deleteUser: (params) =>
    request.delete(httpUser + 'DeleteUser', params)(actions.DEL_USER),
  todayStar: (params) =>
    request.put(httpOrder + 'PutProduceSweep', params)(actions.TODAY_STAR),
  queryStar: (params) =>
    request.get(httpOrder + 'GetCleanName', params)(actions.QUERY_STAR),
  queryDept: (params) =>
    request.get(httpDept + 'GetAllDept', params)(actions.QUERY_DEPT),
  queryIsHaveStar: (params) =>
    request.get(httpOrder + 'GetWetherProduce', params)(actions.QUERY_IS_HAVE_STAR),
  changeUserType: (type) => ({type: actions.CHANGE_USER_TYPE, payload: type}),
  showUpdate: (type, id) => ({type: actions.SHOW_UPDATE, payload: type, id}),
  showDelete: (type) => ({type: actions.SHOW_DELETE, payload: type}),
  showOrder: (type) => ({type: actions.SHOW_ORDER, payload: type}),
  showAdd: (type) => ({type: actions.SHOW_ADD, payload: type}),
  clearLogin: (type) => ({type: actions.CLEAR_LOGIN, payload: type}),
  saveUser: (type) => ({type: actions.SAVE_USER, payload: type}),
  addOne: (type) => ({type: actions.ADD_ONE, payload: type}),
  saveDelUser: (type) => ({type: actions.SAVE_DEL_USER, payload: type}),
};

export const handlers = {
  [onSuccess(actions.QUERY_USER)]: (state, action) => {
    //console.log(action);
    return {...state, login: action.payload.Status};
  },
  [onSuccess(actions.ORDER_CONFIRM)]: (state, action) => {
    //console.log(action);
    return {...state};
  },
  [onSuccess(actions.ORDER_CANCEL)]: (state, action) => {
    //console.log(action.payload);
    return {...state};
  },
  [onSuccess(actions.UPDATE_PWD)]: (state, action) => {
    //console.log(action.payload);
    return {...state};
  },
  [onSuccess(actions.QUERY_IS_HAVE_STAR)]: (state, action) => {
    //console.log(action.payload);
    return {...state};
  },
  [onSuccess(actions.QUERY_ALL_USERS)]: (state, action) => {
    //console.log(action.payload);
    let n = [];
    for (let i = 1, len = action.payload.Result.TotalPage; i <= len; i++) {
      n.push(i);
    }
    return {
      ...state,
      userInfo: {
        ...state.userInfo,
        list: action.payload.Result.ObjectList.slice(),
        totalPage: n,
        currentPage: action.payload.Result.CurrentPage
      }
    };
  },
  [onSuccess(actions.GET_ORDER_TODAY)]: (state, action) => {
    //console.log(action.payload);
    return {
      ...state,
      orderToday: {
        totalRecord: action.payload.Result.TotalRecord,
        orderPeople: action.payload.Result.ObjectList,
        currentPage: action.payload.Result.CurrentPage,
        totalPage: action.payload.Result.TotalPage
      }
    };
  },
  [onSuccess(actions.ADD_USER)]: (state, action) => {
    //console.log(action);
    return {...state};
  },
  [onSuccess(actions.DEL_USER)]: (state, action) => {
    // console.log(action.payload);
    return {...state};
  },
  [onSuccess(actions.TODAY_STAR)]: (state, action) => {
    //console.log(action.payload);
    return {...state};
  },
  [onSuccess(actions.QUERY_STAR)]: (state, action) => {
    //console.log(action.payload.Result);
    if (action.payload.Result.length > 0) {
      return {
        ...state, star: [
          ...action.payload.Result
        ]
      };
    }
    else {
      return {...state};
    }
  },
  [onSuccess(actions.QUERY_DEPT)]: (state, action) => {
    //console.log(action.payload);
    if (action.payload.Result.length > 0) {
      return {...state, select: action.payload.Result};
    }
    else {
      return {...state};
    }
  },
  [actions.CHANGE_USER_TYPE]: (state, action) => {
    return {...state, userType: action.payload, login: ''};
  },
  [actions.SHOW_UPDATE]: (state, action) => {
    return {...state, update: action.payload, id: action.id};
  },
  [actions.SHOW_DELETE]: (state, action) => {
    return {...state, delete: action.payload};
  },
  [actions.SHOW_ORDER]: (state, action) => {
    return {...state, order: action.payload};
  },
  [actions.SHOW_ADD]: (state, action) => {
    return {...state, addUserBox: action.payload};
  },
  [actions.CLEAR_LOGIN]: (state, action) => {
    return {...state, login: ''};
  },
  [actions.SAVE_USER]: (state, action) => {
    return {...state, user: action.payload.Result};
  },
  [actions.ADD_ONE]: (state, action) => {
    return {...state, add: action.payload};
  },
  [actions.SAVE_DEL_USER]: (state, action) => {
    return {
      ...state, userInfo: {
        ...state.userInfo,
        delUser: action.payload
      }
    };
  },
};
