import msalInstance from "@/lib/authentication/auth";
import { jobsServer } from "@/lib/authentication/msalconfig";
const storagePrefix = 'spawn_';


const storage = {
  
  getToken: async () => {
    const currentAccount = msalInstance.getActiveAccount();
    
    const accessTokenRequest = {
      scopes: jobsServer.scopes,
      account: currentAccount,
    };
    
    const accessTokenResponse = await msalInstance.acquireTokenSilent(accessTokenRequest);


    return accessTokenResponse.accessToken;
  },
  setToken: (token: string) => {
    window.localStorage.setItem(`${storagePrefix}token`, JSON.stringify(token));
  },
  clearToken: () => {
    window.localStorage.removeItem(`${storagePrefix}token`);
  },
};

export default storage;
