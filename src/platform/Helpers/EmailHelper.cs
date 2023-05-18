using System.Text;
using XmCloudSXAStarter.Models;

namespace XmCloudSXAStarter.Helpers
{
    public static class EmailHelper
    {
        public static string GenerateEmailContent(EventModel eventModel)
        {
            var htmlString = new StringBuilder("<h1>Item Details</h1>");
            htmlString.Append("<p><b>Event Called:</b> ");
            htmlString.Append($"{eventModel.EventName}</p>");
            htmlString.Append("<p><b>Item Name:</b> ");
            htmlString.Append($"{eventModel.Item.Name}</p>");
            htmlString.Append("<p><b>Item Version:</b> ");
            htmlString.Append($"{eventModel.Item.Version}</p>");
            htmlString.Append("<p><b>Item Id:</b> ");
            htmlString.Append($"{eventModel.Item.Id}</p>");
            htmlString.Append("<p><b>Language:</b> ");
            htmlString.Append($"{eventModel.Item.Language}</p>");
            htmlString.Append("<p><b>Template Id:</b> ");
            htmlString.Append($"{eventModel.Item.TemplateId}</p>");
            if (eventModel.Changes != null)
            {
                var count = 0;
                htmlString.Append("<p><b>Field Changes:</b> ");
                foreach (var change in eventModel.Changes.FieldChanges)
                {
                    if(count == eventModel.Changes.FieldChanges.Length - 1)
                    {
                        htmlString.Append($"{change.Value}");
                    }
                    else
                    {
                        htmlString.Append($"{change.Value}, ");
                    }
                    count++;
                }
                htmlString.Append("</p>");
            }
            return htmlString.ToString();
        }
    }
}