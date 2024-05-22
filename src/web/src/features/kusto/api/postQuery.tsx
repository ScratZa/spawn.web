import { MutationConfig } from "@/lib/react-query";
import axios from "axios";
import { useMutation, useQueryClient } from "react-query";
import {z} from 'zod';

export const QueryValidationRequestSchema = z.object({
    query: z.string(),
    database: z.string(),
    cluster: z.string()
});

export type QueryValidationRequest = z.infer<typeof QueryValidationRequestSchema>;


export const validateQuery = ({ data }: { data: QueryValidationRequest }): Promise<boolean> => {
    return axios.post('/validate', data );
}

type UseValidationOptions = {
    mutationConfig?: MutationConfig<typeof validateQuery>;
}

export const useQueryValidation = ({ mutationConfig }: UseValidationOptions = {}) => {
    const queryClient = useQueryClient();

    const { onSuccess, ...restConfig } = mutationConfig || {};

    return useMutation({
        onSuccess: (...args) => {
          queryClient.invalidateQueries({
            //queryKey: getCommentsQueryOptions(discussionId).queryKey,
          });
          onSuccess?.(...args);
        },
        ...restConfig,
        mutationFn: validateQuery,
      });
};