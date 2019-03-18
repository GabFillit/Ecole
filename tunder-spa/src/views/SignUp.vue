<template>
  <div class="view__container login__container">
    <i class="logo fab fa-algolia fa-4x"></i>
    <div class="box is-half login__form">
      <form  @submit="onSubmit">
        <div class="field">
          <input  v-model="form.userName" 
                  @blur="validUsernameDispo"
                  v-validate="'required|min:6'" 
                  class="input" 
                  name="userName"
                  type="text" 
                  :class="{ 'is-danger': this.form.userNameDisponible === false, 'is-success': this.form.userNameDisponible === true }"
                  placeholder="Username">
           <p id="userNameIsDisponible" class="is-success" v-if="this.form.userNameDisponible === true">Disponible!</p>
           <p id="userNameIsDisponible" class="is-danger" v-else-if="this.form.userNameDisponible === false">Non Disponible!</p>
        </div>

        <div class="field">
          <p class="control has-icons-left has-icons-right">
            <input v-model="form.email" 
                   v-validate="'required|email'" 
                   class="input" 
                   type="text" 
                   name="email"
                   placeholder="Email"
                   :class="{ 'is-danger': errors.has('email'), 'is-success': fields.email && fields.email.valid }">
            <span  class="icon is-small is-left">
              <i class="fas fa-envelope"></i>
            </span>
            <span v-if="fields.email && fields.email.valid" class="icon is-small is-right is-success">
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
        <div class="field">
          <p class="control has-icons-left has-icons-right">
            <input v-model="form.confirmPassword" 
                   v-validate="'required|min:6'" 
                   class="input" 
                   name="confirmPassword"
                   type="password" 
                   placeholder="Confirm password">
            <span class="icon is-small is-left">
              <i class="fas fa-lock"></i>
            </span>
          </p>
        </div>

        <div class="field">
          <div class="select">
            <select  v-model="form.sex">
              <option selected disabled value="">Pick sex</option>
              <option value="0">Male</option>
              <option value="1">Female</option>
              <option value="2">Other</option>
            </select>
          </div>
        </div>

        <div class="field">
          <input type="date" class="input" name="birthDay" v-model="form.birthDay" v-validate="'required'"/>
        </div>

        <div class="forgot-password__container">
        </div>
        <div class="field is-grouped signup__btn-group">
          <button :class="{ 'is-loading': form.submitting }" :disabled="inError"  class="button is-primary">Sign Up</button>
        </div>
      </form>
    </div>

  </div>
</template>

<script>
  export default {
    name: 'SignUp',
    data() {
      return {
        form: {
          userName: '',
          email: '',
          password: '',
          confirmPassword: '',
          birthDay: '',
          sex: 0,
          submitting: false,
          userNameDisponible: null
        }
      };
    },
    computed: {
      inError() {
        return Object.keys(this.fields).some(key => this.fields[key].invalid);
      }
    },
    methods: {
      validUsernameDispo() {
        this.form.userNameDisponible = this.form.userName.length >= 6;
      },
      onSubmit() {

      }
    }
  }
</script>

<style lang="scss">

.signup__btn-group {
  margin-top: 40px;
}

.login__container {
  min-height: 250px;

  .select, select {
    width: 100%;
  }
}

</style>