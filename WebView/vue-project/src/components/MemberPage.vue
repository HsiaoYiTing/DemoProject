<script setup lang="ts">
import { ref } from 'vue';
import { useRouter } from 'vue-router'
import type { User } from '@/models/User';
import { getUserById, getAllUsers } from '@/api/UserApi'

import BaseEditView from './base/BaseEditView.vue';
import BaseTitleView from './base/BaseTitleView.vue';


const router = useRouter()

const users = ref<User[]>([])

const title = '查詢會員'
const user_id = ref('')
const idError = ref('')
const apiError = ref('')


// GetUserById
const getUserByIdAction = () => {

  users.value = []
  apiError.value = ""

  idError.value = user_id.value.length == 0 ? "id不能為空" : ""
    
  if (idError.value.length > 0) {
    return
  }

  getUserByIdApi(user_id.value)
}

async function getUserByIdApi(id: string) {

  const apiRes = await getUserById(id)
  if (apiRes.data != null) {
    var user = apiRes.data
    if (user != null) {
      if (Array.isArray(user)) {
        users.value.push(...user)
      } else {
        users.value.push(user)
      }
    }
  } else {
    apiError.value = apiRes.message
  }
}

// GetAllUser
const getAllUserAction = () => {

  apiError.value = ""
  getAllUsersApi()
}

async function getAllUsersApi() {

  let apiRes = await getAllUsers()
  if (apiRes.data != null) {
    users.value = apiRes.data
  } else {
    apiError.value = apiRes.message
  }

  console.log(apiRes)
}

const logoutAction = () => {

  router.replace("/");
}


</script>

<template >
  <div class="container">

    <div class="title_div">
      <img src="../assets/logo.svg" alt="logo" style="width: 50px; height: 50px;"/>
      <BaseTitleView :text="title" />
    </div>
    
    <BaseEditView 
      v-model="user_id" 
      title="" hint="請輸入會員ID" type="text" :error-text="idError" />

    <button @click="getUserByIdAction">送出</button>
    <button @click="getAllUserAction">查詢全部</button>

    <p class="message_text" v-show="apiError.length > 0">{{ apiError }}</p>

    <table>
        <thead>
        <tr class="title_tr">
            <th>ID</th>
            <th>姓名</th>
            <th>帳號</th>
            <th>年齡</th>
            <th>薪水</th>
            <th>生日</th>
        </tr>
        </thead>

        <tbody>
        <tr v-for="user in users" :key="user.id">
            <td>{{ user.id }}</td>
            <td>{{ user.name }}</td>
            <td>{{ user.account }}</td>
            <td>{{ user.age }}</td>
            <td>{{ user.salary }}</td>
            <td>{{ user.birthday }}</td>
        </tr>
        </tbody>
    </table>

   <div class="bottom_div">
      <a @click="logoutAction" class="link_text">登出</a> 
    </div>

  </div>
</template>

<style scoped>

table {
    width: calc(100% - 10px);
    margin-top: 20px;

    border-collapse: collapse;
}

th, td {
  border: 1px solid #ccc;
  padding: 5px;
  text-align: center;
}

.link_text {
  justify-content: center;
  margin-top: 10px;
  text-align: center;
  text-decoration: underline;
}

.title_tr {
    background-color: gray;
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

button {

  width: calc(100% - 10px);
  height: 40px;
  font-size: 1rem;
  background-color: black;
  color: white;

  border-width: 0px;
  margin-top: 20px;
}

</style>
