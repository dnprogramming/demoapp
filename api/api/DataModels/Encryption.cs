namespace api.DataModels;
public class Encryption
{
  [BsonId]
  [BsonRepresentation(BsonType.ObjectId)]
  public string? Id { get; set; }

  [BsonRepresentation(BsonType.String)]
  public string Ident { get; set; } = null!;

  [BsonRepresentation(BsonType.String)]
  public string Pass { get; set; } = null!;
}
