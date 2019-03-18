import { mount, createLocalVue } from '@vue/test-utils'
import { expect } from 'chai'
import SignUp from '@/views/SignUp.vue';
import VeeValidate from 'vee-validate'


function GetWrapper() {
   const localVue = createLocalVue()

    localVue.use(VeeValidate, {
      inject: true
    });

    return mount(SignUp, {
      localVue
    });

}

describe('@/views/SignUp.vue', () => {

  let wrapper;

  describe('When username is Disponible', () => {

    beforeEach(() => {
      wrapper = GetWrapper(); 
      wrapper.setData({ form: { userNameDisponible: true } });
    })

    it('Should display that the userName is disponible', () => {
      const html = wrapper.find('#userNameIsDisponible').html();
      expect(html).to.have.string('Disponible!');
    });

    it('Should have is-success class!', () => {
      const html = wrapper.find('#userNameIsDisponible').html();
      expect(html).to.have.string('is-success');
    });
  });

  describe('When username is NOT Disponible', () => {

    beforeEach(() => {
      wrapper = GetWrapper(); 
      wrapper.setData({ form: { userNameDisponible: false } });
    });

    it('Should display that the userName is NOT disponible', () => {
      const html = wrapper.find('#userNameIsDisponible').html();
      expect(html).to.have.string('Non Disponible!');
    });

    it('Should have is-danger class!', () => {
      const html = wrapper.find('#userNameIsDisponible').html();
      expect(html).to.have.string('is-danger');
    });
  });
});
