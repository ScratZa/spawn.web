import { Navigate, Route, Routes } from 'react-router-dom';

import { Definitions } from './Definitions';

export const DefinitionRoutes = () => {
  return (
    <Routes>
      <Route path="" element={<Definitions />} />
      <Route path=":jobId" element={<Definitions />} />
      <Route path="*" element={<Navigate to="." />} />
    </Routes>
  );
};
