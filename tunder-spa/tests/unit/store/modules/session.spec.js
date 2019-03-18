import store from '@/store/modules/session.js'
import { expect } from 'chai'
import { SET_TOKEN } from '@/store/mutation-types.js';

describe('@/store/modules/sessions', () => {
  let state;

  describe('Mutations', () => {
    const { mutations } = store;

    beforeEach(() => {
      state = store.state;
    });

    it('Set token should set token', () => {
      mutations[SET_TOKEN](state, 'madame');
      expect(state.token).to.equal('madame');
    })

    it('Set token should set isAuth', () => {
      mutations[SET_TOKEN](state, 'madame');
      expect(state.isAuth).to.equal(true);
    })
  })
});