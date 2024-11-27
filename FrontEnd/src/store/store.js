import { createStore } from 'vuex';

export const store = createStore({
  state() {
    return {
      usuario: null, // Aqui será armazenado o usuário
    };
  },
  mutations: {
    setUsuario(state, usuario) {
      state.usuario = usuario; // Mutação para definir o usuário no estado global
    },
    clearUsuario(state) {
      state.usuario = null; // Mutação para limpar o usuário
    },
  },
  actions: {
    setUsuario({ commit }, usuario) {
      commit('setUsuario', usuario); // Ação para chamar a mutação
    },
    clearUsuario({ commit }) {
      commit('clearUsuario'); // Ação para chamar a mutação que limpa o usuário
    },
  },
  getters: {
    getUsuario(state) {
      return state.usuario; // Getter para acessar o usuário no estado
    },
  },
});
