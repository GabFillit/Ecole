import { expect } from 'chai'
import { mount } from '@vue/test-utils'
import Notification from '@/components/layout/Notification.vue';
import NotificationStore  from '@/store/modules/notifications.js';

describe('@/components/layout/Notification.vue', () => {

  describe('It display danger on error notification', () => {

    const { NOTIFICATION_TYPES } = NotificationStore;

    const wrapper = mount(Notification,  {
      propsData: {
        notif: {
          id: 1,
          msg: 'yolo danger',
          type: NOTIFICATION_TYPES.error
        }
      }
    });

    expect(wrapper.classes('is-danger')).to.be(true);
  });
});
