<script setup>
import {WelcomeHeader} from './components/WelcomeHeader.vue'
import { RouterLink, RouterView } from 'vue-router'
import {useUserStore} from '../stores/user'

const userData = useUserStore()
</script>

<template>
  <header>
    <img alt="Tothmih" class="logo" src="/src/assets/logo.svg" width="125" height="125" />
    <nav>
      <RouterLink to="/" v-if="!userData.user.id">Belépés</RouterLink>
      <RouterLink to="/vizsgalatok" v-if="userData.user.id">Vizsgálatok</RouterLink>
    </nav>
    <RouterView />
  </header>
  <main>
    <div >
      <WelcomeHeader msg="Koordinációs Iroda" />

      
    </div>
  </main>

  
</template>

<style scoped>
header {
  line-height: 1.5;
  max-height: 100vh;
}

.logo {
  display: block;
  margin: 0 auto 2rem;
}

nav {
  width: 100%;
  font-size: 12px;
  text-align: center;
  margin-top: 2rem;
}

nav a.router-link-exact-active {
  color: var(--color-text);
}



nav a {
  display: inline-block;
  padding: 0 1rem;
  border-left: 1px solid var(--color-border);
}

nav a:first-of-type {
  border: 0;
}


</style>
