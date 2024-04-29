import { ContentLayout } from "@/components/Layout";
import { JobsList } from "../components/JobsList";

export const Definitions = () => {
    console.log("Jobs")
    return (
        <ContentLayout title="Jobs">
        <JobsList/>
        </ContentLayout>

    );
}