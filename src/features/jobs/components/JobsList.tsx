import { Spinner, TableCaption, TableRow } from '@/components/Elements';
import {Table, TableHeader, TableHead, TableFooter, TableCell, TableBody} from '@/components/Elements/Table';
import { formatDate } from '@/utils/format';

import { useJobs } from '../api/getJobs';
import { Job } from '../types';

//import { DeleteDiscussion } from './DeleteDiscussion';

export const JobsList = () => {
  const jobsQuery = useJobs();

  if (jobsQuery.isLoading) {
    return (
      <div className="w-full h-48 flex justify-center items-center">
        <Spinner size="lg" />
      </div>
    );
  }

  if (!jobsQuery.data) return (      <div className="w-full h-48 flex justify-center items-center">
  <Spinner size="lg" />
</div>);

  return (
        <Table>
            <TableCaption>List of Existing Jobs</TableCaption>
            <TableHeader>
                <TableRow>
                <TableHead >Job Id</TableHead>
                <TableHead >Summary</TableHead>
                <TableHead >Created At</TableHead>
                </TableRow>
            </TableHeader>

            <TableBody>
        {jobsQuery.data.map((job) => (
          <TableRow key={job.id}>
            <TableCell className="font-medium">{job.id}</TableCell>
            <TableCell>{job.summary}</TableCell>
            <TableCell>{formatDate(job.createdAt)}</TableCell>
          </TableRow>
        ))}
      </TableBody>
      <TableFooter>
        <TableRow>
          <TableCell colSpan={3}>Count</TableCell>
          <TableCell className="text-right">{jobsQuery.data.length}</TableCell>
        </TableRow>
      </TableFooter>
    </Table>
  );
};
