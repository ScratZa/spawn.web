import { Suspense } from 'react';
 import { Outlet } from 'react-router-dom';

import { Spinner } from '@/components/Elements';
import { MainLayout } from '@/components/Layout';
import { lazyImport } from '@/utils/lazyImport';

// const { DiscussionsRoutes } = lazyImport(
//   () => import('@/features/discussions'),
//   'DiscussionsRoutes'
// );
// const { Dashboard } = lazyImport(() => import('@/features/misc'), 'Dashboard');
// const { Profile } = lazyImport(() => import('@/features/users'), 'Profile');
// const { Users } = lazyImport(() => import('@/features/users'), 'Users');
const { Definitions } =  lazyImport(() => import('@/features/jobs'), 'Definitions');
const App = () => {
  return (
    <MainLayout>
      <Suspense
        fallback={
          <div className="h-full w-full flex items-center justify-center">
            <Spinner size="xl" />
          </div>
        }
      >
        <Outlet />
      </Suspense>
    </MainLayout>
  );
};

export const protectedRoutes = [
  {
    path: '/app',
    element: <App />,
    children: [
      { path: '/app/jobs', element: <Definitions /> }
    ],
  },
];
