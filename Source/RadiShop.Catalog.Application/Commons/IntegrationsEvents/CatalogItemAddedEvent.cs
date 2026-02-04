using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace RadiShop.Catalog.Application.Commons.IntegrationsEvents;

public sealed record CatalogItemAddedEvent(
    [property: JsonProperty("version")]int Version,
    [property: JsonProperty("eventType")]string EventType,
    [property: JsonProperty("timestamp")]DateTime Timestamp,
    [property: JsonProperty("data")]CatalogItemAddedData Data
    );

public sealed record CatalogItemAddedData(
    [property: JsonProperty("name")]string Name,
    [property: JsonProperty("description")]string Description,
    [property: JsonProperty("category")]string Category,
    [property: JsonProperty("brand")]string Brand,
    [property: JsonProperty("slug")]string Slug,
    [property: JsonProperty("detailUrl")]string DetailUrl
    );