import { Route, Routes } from "react-router-dom";
import { Create } from "./Create";

export const KustoRoutes = () => {
    return (
        <Routes>
            <Route path="" element={<Create />} />
        </Routes>
    );
}