import { Link, NavLink } from 'react-router-dom'
import styles from './Navbar.module.scss'

const Navbar = () => {
  return (
    <nav className={styles.navbar}>
      <div className={styles.container}>
        <Link to="/" className={styles.logo}>
          MangoShop
        </Link>

        <div className={styles.navLinks}>
          <NavLink
            to="/"
            end
            className={({ isActive }) =>
              isActive ? `${styles.navLink} ${styles.active}` : styles.navLink
            }
          >
            Home
          </NavLink>
          <NavLink
            to="/products"
            className={({ isActive }) =>
              isActive ? `${styles.navLink} ${styles.active}` : styles.navLink
            }
          >
            Products
          </NavLink>
          <NavLink
            to="/orders"
            className={({ isActive }) =>
              isActive ? `${styles.navLink} ${styles.active}` : styles.navLink
            }
          >
            Orders
          </NavLink>
        </div>

        <div className={styles.navActions}>
          <NavLink to="/cart" className={styles.cartBtn}>
            <svg
              xmlns="http://www.w3.org/2000/svg"
              width="22"
              height="22"
              viewBox="0 0 24 24"
              fill="none"
              stroke="currentColor"
              strokeWidth="2"
              strokeLinecap="round"
              strokeLinejoin="round"
            >
              <circle cx="9" cy="21" r="1" />
              <circle cx="20" cy="21" r="1" />
              <path d="M1 1h4l2.68 13.39a2 2 0 0 0 2 1.61h9.72a2 2 0 0 0 2-1.61L23 6H6" />
            </svg>
            <span className={styles.cartBadge}>0</span>
          </NavLink>

          <NavLink to="/login" className={styles.btnOutline}>
            Login
          </NavLink>
          <NavLink to="/register" className={styles.btnPrimary}>
            Register
          </NavLink>
        </div>
      </div>
    </nav>
  )
}

export default Navbar
