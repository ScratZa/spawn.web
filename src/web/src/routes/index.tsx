import { useRoutes } from 'react-router-dom';
import msalInstance from '@/lib/authentication/auth';
import { Landing } from '@/features/misc';
// import { useAuth } from '@/lib/auth';

import { protectedRoutes } from './protected';
import { publicRoutes } from './public';

export const AppRoutes = () => {
  //const auth = useAuth();
  const msal = msalInstance;
  const commonRoutes = [{ path: '/', element: <Landing /> }];

  const routes = msal.getActiveAccount() ? protectedRoutes : publicRoutes;
  
  const element = useRoutes([...commonRoutes, ...routes]);
  return <>{element}</>;
};
