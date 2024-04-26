import * as React from 'react';
import { ErrorBoundary } from 'react-error-boundary';
import { HelmetProvider } from 'react-helmet-async';
import { QueryClientProvider } from 'react-query';
import { ReactQueryDevtools } from 'react-query/devtools';
import { BrowserRouter as Router, useNavigate } from 'react-router-dom';
import { Notifications } from '@/components/Notifications/Notifications';
//import { AuthLoader } from '@/lib/auth';
import { queryClient } from '@/lib/react-query';
import { Spinner } from '@/components/Elements';
import msalInstance from '@/lib/authentication/auth';
import { useEffect } from 'react';
import { MsalAuthenticationTemplate, MsalProvider } from "@azure/msal-react";
import { InteractionType } from '@azure/msal-browser';

const onErrorFallback = () => {
    return (
        <div
        className="text-red-500 flex flex-col justify-center items-center" role="alert">
            <h2 className='text-lg font-semibold'>Something went wrong</h2>
            <button className='mt-4' onClick={() => window.location.assign(window.location.origin)}>Reload</button>
        </div>
    );
}

type AppProviderProps = {
    children: React.ReactNode;
}

export const AppProvider = ({ children }: AppProviderProps) => {
    //const { inProgress, instance, accounts } = useMsal();
    //const isAuthenticated = useIsAuthenticated();

    useEffect(() => {
        msalInstance.handleRedirectPromise().then((response) => {
            if (response && response.account) {
                // User is authenticated, you can proceed to  app
                //navigate("/Dashboard", { replace: true });
            }
        });
        // Check if the user is already signed in
        const account = msalInstance.getActiveAccount();
        if (account) {
            // User is already signed in, you can proceed to  app
            //navigate("/jobs", { replace: true });
        } else {
            // If the user is not signed in, initiate the login process
            msalInstance.initialize();
        }
    });

    return (
        <React.Suspense fallback={<div className='flex items-center justify-center w-screen h-screen'><Spinner/></div>}>
         <ErrorBoundary FallbackComponent={onErrorFallback}>
             <HelmetProvider>
                 <QueryClientProvider client={queryClient}>
                 {process.env.NODE_ENV !== 'test' && <ReactQueryDevtools initialIsOpen={false} />}
                    <Notifications />
                         <Router>
                            <MsalProvider instance={msalInstance}>
                            <MsalAuthenticationTemplate interactionType={InteractionType.Redirect}>

                             {children}
                             </MsalAuthenticationTemplate>
                            </MsalProvider>
                         </Router>
                 </QueryClientProvider>
             </HelmetProvider>
         </ErrorBoundary>
        </React.Suspense>
    );
};

