using Newtonsoft.Json;

namespace XmCloudSXAStarter.Models
{
    public class EventModel
    {
        [JsonProperty("EventName")]
        public string EventName { get; set; }
        [JsonProperty("Item")]
        public ItemModel Item { get; set; }
        [JsonProperty("Changes")]
        public ChangeModel Changes { get; set; }

    }
    public class ItemModel
    {
        [JsonProperty("Language")]
        public string Language { get; set; }
        [JsonProperty("Version")]
        public int Version { get; set; }
        [JsonProperty("Id")]
        public string Id { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("ParentId")]
        public string ParentId { get; set; }
        [JsonProperty("TemplateId")]
        public string TemplateId { get; set; }
    }
    public class ChangeModel
    {
        [JsonProperty("FieldChanges")]
        public FieldChangesModel[] FieldChanges { get; set; }
    }
    public class FieldChangesModel
    {
        [JsonProperty("Value")]
        public string Value { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
    }
}