namespace RadiShop.Catalog.Shared;

public class AppSettings
{
    public const string ConfigurationSectionName = "AppSettings";
    public required ConnectionStringsSettings ConnectionStrings { get; set; }
    public required ApiGatewaySettings ApiGateway { get; set; }
}

public sealed record ConnectionStringsSettings(string PostgreSQL);

public sealed record ApiGatewaySettings(string BaseUrl);