import { Route, Routes } from 'react-router-dom';

import { WorkflowBuilder } from './WorkflowBuilder';

export const WorkflowRoutes = () => {
  return (
    <Routes>
      <Route path="" element={<WorkflowBuilder />} />
    </Routes>
  );
};
