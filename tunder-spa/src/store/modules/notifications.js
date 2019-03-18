import { ADD_ERROR, ADD_SUCCESS, REMOVE_NOTIFICATION } from '@/store/mutation-types.js';

const NOTIFICATION_TYPES = {
  error: 'error',
  success: 'success'
};

const state = {
  notifications: [],
  notificationCount: 0
};

const mutations = {
  [REMOVE_NOTIFICATION](state, id) {
    state.notifications = state.notifications.filter(n => n.id !== id);
  },
  [ADD_SUCCESS](state, payload) {
    const { msg } = payload;

    state.notifications.push({
      id: state.notificationCount++,
      msg,
      type: NOTIFICATION_TYPES.success
    })
  },
  [ADD_ERROR](state, payload) {
    const { msg } = payload;

    state.notifications.push({
      id: state.notificationCount++,
      msg,
      type: NOTIFICATION_TYPES.error
    })
  },
  
};

const getters = {};

const actions = {};

export default {
  state,
  mutations,
  actions,
  getters,
  NOTIFICATION_TYPES
};
