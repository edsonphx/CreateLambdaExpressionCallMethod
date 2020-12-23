public LambdaExpression CreateLambdaExpression<T>(string methodName, object param = null)
{
    var typeOfInstance = typeof(T);
    var parameter = Expression.Parameter(typeOfInstance, "x");
    var methodInfo = typeOfInstance.GetMethod(methodName);
    if (param is null)
    {
        var methodCallExpression = Expression.Call(parameter, methodInfo);
        var lambda = Expression.Lambda(methodCallExpression, parameter);
        return lambda;
    }
    else
    {
        var parameterToFunction = Expression.Constant(param);
        var methodCallExpression = Expression.Call(parameter, methodInfo, parameterToFunction);
        var lambda = Expression.Lambda(methodCallExpression, parameter);
        return lambda;
    }
}
