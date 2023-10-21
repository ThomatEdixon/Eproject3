import Home from "../page/home"
import Product from "../page/product"
import ProductDetail from "../page/productDetail"
import Register from "../page/register"

const publicRoutes = [
    {
        path: "/",
        component: <Home />
    },
    {
        path: "/register",
        component: <Register />
    },
    {
        path: "/product",
        component: <Product />
    },
    {
        path: "/product-detail",
        component: <ProductDetail />
    }
]

export default publicRoutes