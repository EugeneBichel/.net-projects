OAuth 2.0 is an open protocol to allow secure authorization in a simple and standard method from web, mobile and desktop applications

OAuth 2.0 is not about authentication.
It is about authorization.

OAuth 2.0 defines 4 main difference actors:
- User (Resource Owner) an entity capable of granting access to a protected resource
- Client - an application making protected resource requests on behalf of the resource owner and with its authorization.
- Resource Server - the server hosting the protected resources
- Authorization Server - the server issuing access tokens to the client after successfully authenticating the resource owner and obtaining authorization.

There are 2 types of clients:
1. Confidential clients - clients capable of maintaining of their crendentials
2. Public clients - clients incapable of maintaining the confidentiality of their credentials

Authorization Server
 Endpoints on the Authorization Server
   - Authorization endpoint - used by the client to obtain authorization from the resource owner via user-agent redirection
   - Token endpoint - used by the client to exchange an authorization grant for an access token, typically with client authentication.
   
Client
 Endpoint on the Client
 - Redirection endpoint - used by the autherization server to return responses containing authorization credentials to the client via the resource owner user-agent

 
IdentityServer v3
 - implemets OAuth 2.0 and OpenID connect
 - highly optimized to solve the typical security problems of today's mobile, native and web applications
 - part of the .NET Foundation
 - open-source https://identityserver.github.io/


install-package microsoft.owin.host.systemweb
isntall-package identityserver3
