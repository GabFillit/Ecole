export const SCOPE = 'session';
import { SET_TOKEN, LOGIN, ADD_ERROR } from '@/store/mutation-types.js';

import sessionApi from '@/code/services/SessionService.js';

const state = {
  token: null,
  isAuth: false
};

const actions = {
  [LOGIN] (state, payload) {

    sessionApi.loginUser(
      payload,
      (token) => state.commit(SET_TOKEN, token),
      () => state.commit(ADD_ERROR, { msg: "rip"}, { root: true })
    );
  }
};

const getters = {};

const mutations = {
  [SET_TOKEN](state, newToken) {
    state.token = newToken;
    state.isAuth = true;
  }
};

export default {
  namespaced: true,
  state,
  getters,
  actions,
  mutations
};
