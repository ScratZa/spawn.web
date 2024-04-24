import * as React from 'react';
import { ErrorBoundary } from 'react-error-boundary';
import { HelmetProvider } from 'react-helmet-async';
import { QueryClientProvider } from 'react-query';
import { ReactQueryDevtools } from 'react-query/devtools';
import { BrowserRouter as Router } from 'react-router-dom';
import { Notifications } from '@/components/Notifications/Notifications';
import { AuthLoader } from '@/lib/auth';
import { queryClient } from '@/lib/react-query';
import { Spinner } from '@/components/Elements';

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
    return (
        <React.Suspense fallback={<div className='flex items-center justify-center w-screen h-screen'><Spinner/></div>}>
         <ErrorBoundary FallbackComponent={onErrorFallback}>
             <HelmetProvider>
                 <QueryClientProvider client={queryClient}>
                 {process.env.NODE_ENV !== 'test' && <ReactQueryDevtools initialIsOpen={false} />}
                    <Notifications />
                         <Router>
                             {children}
                         </Router>
                 </QueryClientProvider>
             </HelmetProvider>
         </ErrorBoundary>
        </React.Suspense>
    );
};

