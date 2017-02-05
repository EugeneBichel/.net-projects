## ValueProvider is a good option to add more details for your view model. For example implement and register HttpValueProvider, which add to your view model, which is input parameter for your action method, base property with http headers from http request.

# OWIN (www.owin.org)
OWIN defines a standard interface between .NET web servers and web applications.

OWIN is just a specifiction. This is abstraction.

Usually:
.NET + Web = IIS

OWIN specifiction allows to build web appliction in server-agnostic, but still in a standard way.

```c#
using AppFunc = Func<IDictionary<string, object>, Task>;

var f = new AppFunc(environment => {
	return Task.FromResult(null);
});
```

## The Parts of OWIN
### Actions
- Host
- Server
- Middleware
- Application


Host is a some process. It can be anything from simple console application to windows service, or IIS, etc.
	Host containes a server.
	Server is responsible to handle incoming requests and sending back responses. (IIS: host and server are the same thing)
		Server contains AppFunc. It is pipeline.
			Pipeline contains middlewares: middleware 1, middleware 2, etc., + Application.
			We can compare middleware with HTTP Modules in IIS. The idea is very similar.
			Application handles requests and creates responses (like HTTP handler in IIS).
	
