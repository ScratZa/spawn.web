import { Button } from "@/components/Elements";
import { FormDrawer } from "@/components/Form";
import { Form } from "react-router-dom";
import { QueryValidationRequestSchema, useQueryValidation } from "../api/postQuery";
import { useNotifications } from '@/components/Notifications';
import { PlusIcon } from '@heroicons/react/20/solid';   

export const CreateQuery = () => {
  const { addNotification } = useNotifications();

  const validateQueryMutation = useQueryValidation({
    mutationConfig: {
        onSuccess: () =>  {
            addNotification({
              type: 'success',
              title: 'Query is Valid',
            });
        }
    }   
    });
  return (
    <FormDrawer
      isDone={validateQueryMutation.isSuccess}
      triggerButton={
        <Button size="sm" icon={<PlusIcon className="size-4" />}>
          Create
        </Button>
      }
      title="Validate Query"
      submitButton={
        <Button
          isLoading={validateQueryMutation.isLoading}
          form="validate-query"
          type="submit"
          size="sm"
          disabled={validateQueryMutation.isLoading}
        >
          Validate
        </Button>
      }
    >
      <Form
        id="validate-query"
        onSubmit={(values) => {
        validateQueryMutation.mutate({
            data: values,
          });
        }}
        schema={QueryValidationRequestSchema}
        options={{
          defaultValues: {
            query: '',
            database: '',
            cluster: '',
          },
        }}
      >
        {({ register, formState }) => (
            <>
            <Input
                label="First Name"
                error={formState.errors['firstName']}
                registration={register('firstName')}
            />
            <Input
                label="Last Name"
                error={formState.errors['lastName']}
                registration={register('lastName')}
            />
            <Input
                label="Email Address"
                type="email"
                error={formState.errors['email']}
                registration={register('email')}
            />

            <Textarea
                label="Bio"
                error={formState.errors['bio']}
                registration={register('bio')}
            />
            </>
        )}
      </Form>
    </FormDrawer>
  );
}