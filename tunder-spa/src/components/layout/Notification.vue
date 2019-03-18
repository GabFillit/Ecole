<template>
  <div :class="{ 'is-danger': notif.type === 'error' }" class="notification">
    <button @click='destroyNotif(notif.id)' class="delete"></button>
    {{ notif.msg }}
  </div>
</template>

<script>
import { REMOVE_NOTIFICATION } from '@/store/mutation-types.js';
import { mapMutations } from  'vuex';

export default {
  props: {
    notif: Object
  },
  methods: {
    ...mapMutations({
      destroyNotif: REMOVE_NOTIFICATION
    })
  }
}
</script>

<style lang="scss" scoped>
  .notification {
    width: 80%;
    text-align: center;
  }
</style>