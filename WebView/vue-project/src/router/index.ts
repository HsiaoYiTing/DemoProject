import { createRouter, createWebHashHistory } from 'vue-router'
import LoginPage from '@/components/LoginPage.vue'
import MemberPage from '@/components/MemberPage.vue'
import RegisterPage from '@/components/RegisterPage.vue'

const routes = [
  { path: '/', component: LoginPage },
  { path: '/member', component: MemberPage },
  { path: '/register', component: RegisterPage },
]

const router = createRouter({
  history: createWebHashHistory(),
  routes,
})

export default router