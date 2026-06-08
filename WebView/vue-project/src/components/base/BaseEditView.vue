<script setup lang="ts">

const text = defineModel<string | number | null>()

defineProps<{
    title: string,
    hint: string,
    type?: string,
    errorText: string
}>()

</script>

<template>
  <div>
    <p>{{ title }}</p>
    <input 
        v-model="text" 
        :placeholder="hint"
        :type="type"
         />
    <p class="errorTxt" v-show="errorText.length > 0">{{errorText}}</p>

  </div>

</template>

<style scoped>

p {
    padding-top: 5px;
    font-size: 1rem;
    font-weight: bold;
}

input {
    
    width: calc(100% - 10px);
    height: 40px;
    font-size: 1rem;
    margin-top: 5px;
}

.errorTxt {
    font-size: 0.8rem;
    font-weight: 400;
    color: red;
}

</style>
