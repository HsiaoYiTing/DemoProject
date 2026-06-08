import './assets/main.css'
// 這裡是應用程式的入口點，負責創建 Vue 應用並掛載到 DOM 上
import { createApp } from 'vue'
// 引入 Pinia 狀態管理庫
import { createPinia } from 'pinia'
// 引入根組件 App.vue
import App from './App.vue'

import router from './router'

// 創建 Vue 應用實例
const app = createApp(App)

// 使用 Pinia 作為狀態管理解決方案
app.use(createPinia())

app.use(router)

// 將 Vue 應用掛載到具有 id 'app' 的 DOM 元素上
app.mount('#app')


// Vue Component 的生命週期核心概念: 
// mount（掛載）-> update（更新）-> unmount（卸載）