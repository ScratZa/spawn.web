import { useQuery } from 'react-query';

import { axios } from '@/lib/axios';
import { ExtractFnReturnType, QueryConfig } from '@/lib/react-query';

import { Job } from '../types';

export const getJobs = (): Promise<Job[]> => {
  return axios.get('/Jobs');
};

type QueryFnType = typeof getJobs;

type UseJobsOptions = {
  config?: QueryConfig<QueryFnType>;
};

export const useJobs = ({ config }: UseJobsOptions = {}) => {
  return useQuery<ExtractFnReturnType<QueryFnType>>({
    ...config,
    queryKey: ['Jobs'],
    queryFn: () => getJobs(),
  });
};