<script setup lang="ts">
import { ref } from 'vue';
import { useRouter } from 'vue-router'
import { addUser } from '@/api/UserApi'

import BaseEditView from './base/BaseEditView.vue';
import BaseTitleView from './base/BaseTitleView.vue';


const router = useRouter()

const title = '註冊會員'
const account = ref('')
const accountError = ref('')
const name = ref('')
const nameError = ref('')
const age = ref<number | null>(null)
const salary = ref<number | null>(null)
const birthday = ref('')

const message = ref('')

const submitAction = () => {

  accountError.value = account.value.length == 0 ? "帳號不能為空" : ""
  nameError.value = name.value.length == 0 ? "姓名不能為空" : ""
    
  if (accountError.value.length > 0 || nameError.value.length > 0) {
    return
  }

  addUserApi()
}

const goBack = () => {

  router.back();
}

async function addUserApi() {

  // const response = await axios.post('http://localhost:5231/api/users/add',
  // {
  //     account: account.value,
  //     name: name.value,
  //     age: age.value,
  //     salary: salary.value,
  //     enabled: true,
  //     birthday: birthday.value || ""
  // })

  const response = await addUser(account.value, name.value, age.value, salary.value, birthday.value)

  console.log(response)
    
  message.value = response.message

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
      v-model="name"
      title="姓名" hint="請輸入姓名" type="text" :error-text="nameError" />

    <BaseEditView 
      v-model="age"
      title="年齡" hint="請輸入年齡" type="number" error-text="" />

    <BaseEditView 
      v-model="salary"
      title="薪水" hint="請輸入薪水" type="number" error-text="" />

    <BaseEditView 
      v-model="birthday"
      title="生日" hint="請選擇生日日期" type="date" error-text="" />


    <button class="login_button" @click="submitAction">送出</button>

    <p class="message_text" v-show="message.length > 0">{{ message }}</p>

    <div class="bottom_div">
      <a @click="goBack" class="link_text">返回</a> 
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
