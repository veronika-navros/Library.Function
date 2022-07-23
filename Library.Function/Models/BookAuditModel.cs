using System;
using Newtonsoft.Json;

namespace Library.Function.Models;

public class BookAuditModel
{
    [JsonProperty(PropertyName = "id")]
    public Guid Id { get; set; }
    public DateTime TimeStamp { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
}