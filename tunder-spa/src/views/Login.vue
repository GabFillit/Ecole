<template>
  <div class="view__container login__container">
    <i class="logo fab fa-algolia fa-4x"></i>
    <div class="box is-half login__form">
      <form  @submit.prevent="onSubmit">
        <div class="field">
          <p class="control has-icons-left has-icons-right">
            <input v-model="form.email" 
                   v-validate="'required|email'" 
                   class="input" 
                   type="text" 
                   name="email"
                   placeholder="Email"
                   :class="{ 'is-danger': errors.has('email'), 'is-success': fields.email && fields.email.valid }">
            <span class="icon is-small is-left">
              <i class="fas fa-envelope"></i>
            </span>
            <span class="icon is-small is-right">
              <i class="fas fa-check"></i>
            </span>
          </p>
        </div>
        <div class="field">
          <p class="control has-icons-left has-icons-right">
            <input v-model="form.password" 
                   v-validate="'required|min:6'" 
                   class="input" 
                   name="password"
                   type="password" 
                   placeholder="Password">
            <span class="icon is-small is-left">
              <i class="fas fa-lock"></i>
            </span>
          </p>
        </div>
        <div class="forgot-password__container">
          <router-link class="link" to="/ForgotPassword">Forgot password?</router-link>
        </div>
        <div class="field is-grouped login__btn-group">
          <button :class="{ 'is-loading': form.submitting }" :disabled="inError"  class="button is-primary">Login</button>
        </div>
      </form>
    </div>
    <div class="box is-half">
      <p>Ready for some action ? <router-link class="link" to="/signup">Register!</router-link></p>
    </div>
    
  </div>
</template>

<script>

import { SESSION } from '@/store/scope-types.js';
import { LOGIN } from '@/store/mutation-types.js';

export default {
  name: 'Login',
  data() {
    return {
      form: {
        email: '',
        password: '',
        submitting: false
      }
  }},
  computed: {
    inError() {
      return Object.keys(this.fields).some(key => this.fields[key].invalid);
    }
  },
  methods: {
    onSubmit() {
      const { email, password } = this.form;

      this.$store.dispatch(`${SESSION}/${LOGIN}`, { 
        email, password 
      });
    }
  }
}

</script>

<style lang="scss">

  .field.is-grouped.login__btn-group {
    justify-content: flex-end;
  }

  .forgot-password__container {
    text-align: right;
    .link {
      font-size: 0.75rem;
    }
  }

  .login__container {
    display: flex;
    align-items: center;
    justify-content: center;
    flex-direction: column;

    .logo {
      font-size: 5em;
      margin-bottom: 10px;
    }

    .box {
      padding: 1rem;
    }

    .button {
      width: 100%;
    }

    .is-half {
      width: 50%;
      max-width: 350px;
      display: flex;
      align-items: center;
      justify-content: center;

      &.login__form {
        min-height: 250px;
      }
      @media screen and (max-width: 1024px) {
        width: 88%;
      }

      form {
        width: 86%;
        @media screen and (max-width: 1024px) {
          width: 94%;
        }
      }
    }
}

</style>