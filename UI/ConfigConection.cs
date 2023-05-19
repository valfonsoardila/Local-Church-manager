using System.Configuration;


namespace UI
{
    public static class ConfigConnection
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
        public static string ProviderName = ConfigurationManager.ConnectionStrings["conexion"].ProviderName;
    }
}
