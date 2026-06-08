<script setup lang="ts">
import { ref } from 'vue';
import { useRouter } from 'vue-router'

import BaseEditView from './base/BaseEditView.vue';
import BaseTitleView from './base/BaseTitleView.vue';

const router = useRouter()

const title = '會員登入'
const account = ref('')
const password = ref('')
const accountError = ref('')
const passwordError= ref('')

const submitAction = () => {

  accountError.value = account.value.length == 0 ? "帳號不能為空" : ""
  passwordError.value = password.value.length == 0 ? "密碼不能為空" : ""
    
  if (accountError.value.length > 0 || passwordError.value.length > 0) {
    return
  }

  console.log('Account = ' + account.value)
  console.log('Password = ' + password.value)

  if (password.value == "111") {
    router.replace('/member')
  }
}

</script>

<template >
  <div class="container">

    <div class="title_div">
      <img src="../assets/logo.svg" alt="logo" style="width: 50px; height: 50px;"/>
      <BaseTitleView :text="title" />
    </div>
    
    <BaseEditView 
      v-model="account" 
      title="帳號" hint="請輸入帳號" type="text" :error-text="accountError" />
    
    <BaseEditView 
      v-model="password"
      title="密碼" hint="請輸入密碼" type="password" :error-text="passwordError" />

    <button class="login_button" @click="submitAction">登入</button>

    <div class="bottom_div">
      <RouterLink to="/register" class="link_text">註冊會員</RouterLink> 
      <p class="link_text">忘記密碼</p>
    </div>
  </div>
</template>

<style scoped>

.link_text{
  text-decoration: underline;
}

.title_div {
  display: flex;
  justify-content: center;
  align-items: center;
  gap: 20px;
}

.bottom_div {
  
  margin-top: 30px;
  display: flex;
  justify-content: center;
  gap: 20px;
}

.container {
    
  width: 400px;
  background-color: whitesmoke;
  border-radius: 10px;
  padding: 20px;
}

.login_button {

  width: calc(100% - 10px);
  height: 40px;
  font-size: 1rem;
  background-color: black;
  color: white;

  border-width: 0px;
  margin-top: 20px;
}

</style>
