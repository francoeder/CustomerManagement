namespace CustomerManagement.Api.Constants
{
    public static class ApiRoutes
    {
        public static class Global
        {
            public const string BaseRoute = "api/v{version:apiVersion}/";
        }

        public static class Customer
        {
            public const string DefaultRoute = "customers/";
            public const string RouteById = "customers/{id:guid}";
        }
    }
}
