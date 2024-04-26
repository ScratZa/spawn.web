import {
    PublicClientApplication,
    EventType,
    EventMessage,
    AuthenticationResult,
} from "@azure/msal-browser";
import { msalConfig } from "./msalconfig";

const msalInstance = new PublicClientApplication(msalConfig);

msalInstance.initialize();

const activeAccount = msalInstance.getActiveAccount();

if (!activeAccount) {
    const accounts = msalInstance.getAllAccounts();
    if (accounts.length > 0) {
        msalInstance.setActiveAccount(accounts[0]);
    }
}

msalInstance.addEventCallback((message: EventMessage) => {
    if (message.eventType === EventType.LOGIN_SUCCESS) {
        const payload = message.payload as AuthenticationResult;
        msalInstance.setActiveAccount(payload.account);
    }
})

msalInstance.enableAccountStorageEvents();

export default msalInstance;