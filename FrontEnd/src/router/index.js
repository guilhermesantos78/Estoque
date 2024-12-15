import { createRouter, createWebHistory } from "vue-router";

import HomeView from "../views/Home.vue";

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: "/",
      name: "home",
      component: HomeView,
    },
    {
      path: "/CrudUsuarios",
      name: "CrudUsuarios",
      component: () => import("../views/CrudsAdmin/CrudUsuarios.vue"),
    },
    {
      path: "/CrudProdutos",
      name: "CrudProdutos",
      component: () => import("../views/CrudsAdmin/CrudProdutos.vue"),
    },
    {
      path: "/CrudFornecedores",
      name: "CrudFornecedores",
      component: () => import("../views/CrudsAdmin/CrudFornecedores.vue"),
    },
    {
      path: "/Initialpage",
      name: "Initialpage",
      component: () => import("../views/CrudsAdmin/Initialpage.vue"),
    },
    {
      path: "/InitialPageClientes",
      name: "InitialPageClientes",
      component: () => import("../views/CrudsCliente/InitialPageClientes.vue"),
    },
    {
      path: "/GestaoCompraClientes",
      name: "GestaoCompraClientes",
      component: () => import("../views/CrudsCliente/GestaoCompraClientes.vue"),
      props: true,
    },
    {
      path: "/FormDeleteUsuario",
      name: "FormDeleteUsuario",
      component: () => import("@/components/Usuario/FormDeleteUsuario.vue"),
    },
    {
      path: "/FormGetUsuario",
      name: "FormGetUsuario",
      component: () => import("@/components/Usuario/FormGetUsuario.vue"),
    },
    {
      path: "/FormPostUsuario",
      name: "FormPostUsuario",
      component: () => import("@/components/Usuario/FormPostUsuario.vue"),
    },
    {
      path: "/FormCadastroUsuario",
      name: "FormCadastroUsuario",
      component: () => import("@/components/Usuario/FormCadastroUsuario.vue"),
    },
    {
      path: "/FormLoginUsuario",
      name: "FormLoginUsuario",
      component: () => import("@/components/Usuario/FormLoginUsuario.vue"),
    },
    {
      path: "/FormUpdateUsuario",
      name: "FormUpdateUsuario",
      component: () => import("@/components/Usuario/FormUpdateUsuario.vue"),
    },
    {
      path: "/FormDeleteProduto",
      name: "FormDeleteProduto",
      component: () => import("@/components/Produto/FormDeleteProduto.vue"),
    },
    {
      path: "/FormGetProduto",
      name: "FormGetProduto",
      component: () => import("@/components/Produto/FormGetProduto.vue"),
    },
    {
      path: "/FormPostProduto",
      name: "FormPostProduto",
      component: () => import("@/components/Produto/FormPostProduto.vue"),
    },
    {
      path: "/FormUpdateProduto",
      name: "FormUpdateProduto",
      component: () => import("@/components/Produto/FormUpdateProduto.vue"),
    },
    {
      path: "/FormDeleteFornecedor",
      name: "FormDeleteFornecedor",
      component: () =>
        import("@/components/Fornecedor/FormDeleteFornecedor.vue"),
    },
    {
      path: "/FormGetFornecedor",
      name: "FormGetFornecedor",
      component: () => import("@/components/Fornecedor/FormGetFornecedor.vue"),
    },
    {
      path: "/FormPostFornecedor",
      name: "FormPostFornecedor",
      component: () => import("@/components/Fornecedor/FormPostFornecedor.vue"),
    },
    {
      path: "/FormUpdateFornecedor",
      name: "FormUpdateFornecedor",
      component: () =>
        import("@/components/Fornecedor/FormUpdateFornecedor.vue"),
    },
    {
      path: "/UserPage",
      name: "UserPage",
      component: () => import("../views/UserPage.vue"),
    },
    {
      path: "/UserPageClientes",
      name: "UserPageClientes",
      component: () => import("../views/CrudsCliente/UserPageClientes.vue"),
    },
  ],
});

export default router;
