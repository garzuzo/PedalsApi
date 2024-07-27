namespace PedalsApi.Domain.Pedal;

using System.Text.Json.Serialization;
using Domain.Category;
using PedalsApi.Domain.Media;

public class Pedal
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Media>? Medias { get; set; }
    public Double Price { get; set; }
    [JsonIgnore]
    public Category? Category { get; set; }
    public Guid CategoryId { get; set; }

}
