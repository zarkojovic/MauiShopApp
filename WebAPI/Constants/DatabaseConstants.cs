namespace WebAPI.Constants;

public class DatabaseConstants
{
    public const string GroceryConnectionStringKey = "Grocery";
    public static class Roles
    {
        public static class Admin
        {
            public const short Id = 1;
            public const string Name = "Admin";
        }
        public static class Customer
        {
            public const short Id = 2;
            public const string Name = "Customer";
        }
    }
}