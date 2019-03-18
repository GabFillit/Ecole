<template>
  <div class="columns">
    <Notification :key="i" 
                  v-for="(notif, i) in notifications" 
                  class="column is-8"
                  :notif="notif" />
  </div>
</template>

<script>

import Notification from '@/components/layout/Notification.vue';
import { mapState } from 'vuex';

export default {
  name: 'Footer',
  components: {
    Notification
  },
  computed: {
    ...mapState({
      notifications: state => state.notifications
    })
  },

}

</script>

<style scoped>

</style>