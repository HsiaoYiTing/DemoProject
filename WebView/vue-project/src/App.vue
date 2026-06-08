<script setup lang="ts">
import { ref } from 'vue';
import LoginPage from './components/LoginPage.vue';
import RegisterPage from './components/RegisterPage.vue';
import MemberPage from './components/MemberPage.vue';

const message = 'You did it!';
const value = ref('Welcome !')

// function changeDescription() {
//   value.value = concat('Welcome ');
// }

// 偏好這個種寫法，因為它更簡潔
// const concat = (str: string) => {
//   const result = str + Math.random();
//   console.log('concat called with:', result);
//   return result;
// }


</script>

<template>

  <main>

    <!-- <LoginPage/> -->
    <!-- <RegisterPage/> -->
    <!-- <MemberPage /> -->
    <RouterView />
  </main>

</template>

<style scoped>

main {
  min-height: 100vh;
  display: flex;
  justify-content: center; /* 水平置中 */
  align-items: center;     /* 垂直置中 */
}

</style>