There are five types of Filters in ASP.NET MVC 5:

1. **Authentication Filters**

  Authentication filter runs before any other filter or action method. Authentication confirms that you are a valid or invalid user. Action filters implement the **IAuthenticationFilter** interface. 
 
2. **Authorization Filters**

  The **AuthorizeAttribute** and **RequireHttpsAttribute** are examples of Authorization Filters. Authorization Filters are responsible for checking User Access; these implement the **IAuthorizationFilter** interface in the framework. These filters are used to implement authentication and authorization for controller actions. For example, the Authorize filter is an example of an Authorization filter.
 
3. **Action Filters**

  Action Filter is an attribute that you can apply to a controller action or an entire controller. This filter will be called before and after the action starts executing and after the action has executed.
 
  Action filters implement the **IActionFilter** interface that has two methods *OnActionExecuting* and *OnActionExecuted*. OnActionExecuting runs before the Action and gives an opportunity to cancel the Action call. These filters contain logic that is executed before and after a controller action executes, you can use an action filter, for instance, to modify the view data that a controller action returns.
 
4. **Result Filters**

  The **OutputCacheAttribute** class is an example of Result Filters. These implement the **IResultFilter** interface which like the IActionFilter has OnResultExecuting and OnResultExecuted. These filters contain logic that is executed before and after a view result is executed. Like if you want to modify a view result right before the view is rendered to the browser.
 
5. **ExceptionFilters**

  The HandleErrorAttribute class is an example of ExceptionFilters. These implement the **IExceptionFilter** interface and they execute if there are any unhandled exceptions thrown during the execution pipeline. These filters can be used as an exception filter to handle errors raised by either your controller actions or controller action results.

You can override the methods in your controller class if you want.
