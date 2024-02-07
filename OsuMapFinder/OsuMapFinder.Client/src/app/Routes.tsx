import { RouteObject } from "react-router-dom";
import Auth from "./pages/Auth/Auth";
import App from "./App";

const routes: RouteObject[] = [
    {
        path: '/login',
        element: <Auth/>
    },
    {
        path: '/',
        element: <App/>
    }
]

export default routes;