import {LogLevel} from '@azure/msal-browser';

export const msalConfig = {
    auth: {
        clientId: "51e2208d-d281-4834-9a04-9bbc3d5164ca",
        authority:"https://login.microsoftonline.com/f07430ff-1823-4dc3-aa0e-b8427a604a67",
        redirectUri: 'http://localhost:5173', //eg: ${window.location.origin}/Dashboard
        postLogoutRedirectUri: "/",
        navigateToLoginRequestUrl: false,
    },
    cache: {
        cacheLocation: "sessionStorage", // "sessionStorage" or"localStorage"
        storeAuthStateInCookie: false,
    },
    system: {
        loggerOptions: {
            loggerCallback: (level, message, containsPii) => {
                if (containsPii) {
                    return;
                }
                switch (level) {
                    case LogLevel.Error:
                        console.error(message);
                        return;
                    case LogLevel.Info:
                        console.info(message);
                        return;
                    case LogLevel.Verbose:
                        console.debug(message);
                        return;
                    case LogLevel.Warning:
                        console.warn(message);
                        return;
                    default:
                        return;
                }
            },
        },
        allowNativeBroker: false,
    },
}

/**
 * Scopes you add here will be prompted for user consent during sign-in.
 * By default, MSAL.js will add OIDC scopes (openid, profile, email) to any login request.
 */
export const loginRequest = {
    scopes: ["Files.Read"],
};


/**
 * An optional silentRequest object can be used to achieve silent SSO
 * between applications by providing a "login_hint" property.
 */
// export const silentRequest = {
//     scopes: ["openid", "profile"],
//     loginHint: "example@domain.net",
// };