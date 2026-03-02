import { Routes, Route } from 'react-router-dom'
import Layout from '../../core/shared/components/layout/Layout'
import HomePage from '../../core/features/home/HomePage'
import ProductsPage from '../../core/features/products/ProductsPage'
import LoginPage from '../../core/features/auth/LoginPage'
import RegisterPage from '../../core/features/auth/RegisterPage'
import CartPage from '../../core/features/cart/CartPage'
import OrdersPage from '../../core/features/orders/OrdersPage'

const AppRouter = () => {
  return (
    <Routes>
      <Route element={<Layout />}>
        <Route path="/" element={<HomePage />} />
        <Route path="/products" element={<ProductsPage />} />
        <Route path="/products/:id" element={<ProductsPage />} />
        <Route path="/cart" element={<CartPage />} />
        <Route path="/login" element={<LoginPage />} />
        <Route path="/register" element={<RegisterPage />} />
        <Route path="/orders" element={<OrdersPage />} />
      </Route>
    </Routes>
  )
}

export default AppRouter
