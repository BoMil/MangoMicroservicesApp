# React + Vite

This template provides a minimal setup to get React working in Vite with HMR and some ESLint rules.

Currently, two official plugins are available:

- [@vitejs/plugin-react](https://github.com/vitejs/vite-plugin-react/blob/main/packages/plugin-react) uses [Babel](https://babeljs.io/) (or [oxc](https://oxc.rs) when used in [rolldown-vite](https://vite.dev/guide/rolldown)) for Fast Refresh
- [@vitejs/plugin-react-swc](https://github.com/vitejs/vite-plugin-react/blob/main/packages/plugin-react-swc) uses [SWC](https://swc.rs/) for Fast Refresh

## React Compiler

The React Compiler is not enabled on this template because of its impact on dev & build performances. To add it, see [this documentation](https://react.dev/learn/react-compiler/installation).

## Expanding the ESLint configuration

If you are developing a production application, we recommend using TypeScript with type-aware lint rules enabled. Check out the [TS template](https://github.com/vitejs/vite/tree/main/packages/create-vite/template-react-ts) for information on how to integrate TypeScript and [`typescript-eslint`](https://typescript-eslint.io) in your project.

## Basic structure
<pre> 

MangoWeb/
├── .env.development
├── .env.staging
├── .env.production
└── src/
    ├── config/
    │   ├── constants/          ← API url-ovi, magic numbers
    │   ├── router/             ← definicija ruta
    │   └── environment/        ← čita env varijable
    ├── core/
    │   ├── features/
    │   │   ├── home/
    │   │   │   ├── components/ ← komponente specifične za home
    │   │   │   ├── hooks/      ← logika specifična za home
    │   │   │   ├── models/     ← tipovi podataka
    │   │   │   └── HomePage.jsx
    │   │   ├── auth/
    │   │   │   ├── components/
    │   │   │   ├── hooks/
    │   │   │   ├── models/
    │   │   │   ├── LoginPage.jsx
    │   │   │   └── RegisterPage.jsx
    │   │   ├── products/
    │   │   │   ├── components/
    │   │   │   ├── hooks/
    │   │   │   ├── models/
    │   │   │   └── ProductsPage.jsx
    │   │   ├── cart/
    │   │   │   ├── components/
    │   │   │   ├── hooks/
    │   │   │   ├── models/
    │   │   │   └── CartPage.jsx
    │   │   └── orders/
    │   │       ├── components/
    │   │       ├── hooks/
    │   │       ├── models/
    │   │       └── OrdersPage.jsx
    │   ├── services/           ← svi API pozivi (jedan fajl po mikroservisu)
    │   │   ├── productService.js
    │   │   ├── authService.js
    │   │   ├── orderService.js
    │   │   └── couponService.js
    │   ├── shared/             ← deli se između feature-a
    │   │   ├── components/
    │   │   │   ├── layout/     ← Navbar, Footer, Layout wrapper
    │   │   │   ├── buttons/
    │   │   │   └── inputs/
    │   │   ├── hooks/          ← useAuth, useCart — globalni hookovi
    │   │   └── models/         ← zajednički tipovi
    │   └── utils/
    │       ├── api/
    │       │   ├── apiClient.js     ← Axios instanca
    │       │   └── interceptors.js  ← JWT inject, error handling
    │       ├── helpers/
    │       └── validators/
    ├── styles/
    │   ├── base/               ← reset, tipografija
    │   ├── themes/             ← varijable: boje, spacing, breakpoints
    │   └── main.scss
    ├── assets/
    ├── App.jsx
    └── main.jsx

</pre>
