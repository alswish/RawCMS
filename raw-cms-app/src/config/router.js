import { i18nHelper } from '../config/i18n.js';
import { loginService } from '../modules/core/services/login.service.js';
import { Login } from '../modules/core/views/login/login.js';
import { optionalChain } from '../utils/object.utils.js';

const _router = new VueRouter({
  mode: 'history',
  routes: [
    {
      path: '/login',
      name: 'login',
      component: async (res, rej) => await Login(res, rej),
      meta: {
        requiresAuth: false,
      },
    },
    {
      path: '/',
      name: 'home',
      component: async (res, rej) => {
        const cmp = await import('/modules/core/views/home.js');
        await cmp.default(res, rej);
      },
    },
    {
      path: '/entities',
      component: async (res, rej) => {
        const cmp = await import('/modules/core/views/entities/entities.js');
        await cmp.default(res, rej);
      },
      children: [
        {
          path: '/',
          name: 'entities',
          component: async (res, rej) => {
            const cmp = await import(
              '/modules/core/views/entities-list-view/entities-list-view.js'
            );
            await cmp.default(res, rej);
          },
        },
        {
          path: ':id',
          name: 'entity-details',
          component: async (res, rej) => {
            const cmp = await import('/modules/core/components/entity-details/entity-details.js');
            await cmp.default(res, rej);
          },
        },
      ],
    },
    {
      path: '/users',
      component: async (res, rej) => {
        const cmp = await import('/modules/core/views/users/users.js');
        await cmp.default(res, rej);
      },
      children: [
        {
          path: '/',
          name: 'users',
          component: async (res, rej) => {
            const cmp = await import('/modules/core/components/users-list/users-list.js');
            await cmp.default(res, rej);
          },
        },
        {
          path: ':id',
          name: 'user-details',
          component: async (res, rej) => {
            const cmp = await import('/modules/core/components/user-details/user-details.js');
            await cmp.default(res, rej);
          },
        },
      ],
    },
  ],
});

// Automatically load i18n messages
_router.beforeEach(async (to, from, next) => {
  await i18nHelper.load('en', '/modules/core/assets/i18n/i18n.en.json');
  next();
});

// Check if user is authenticated
_router.beforeEach((to, from, next) => {
  if (to.matched.some(r => !optionalChain(() => r.meta.requiresAuth, { fallbackValue: true }))) {
    next();
    return;
  }

  if (loginService.isLoggedIn) {
    next();
    return;
  }

  next({
    path: '/login',
    params: { nextUrl: to.fullPath },
  });
});

export const router = _router;
