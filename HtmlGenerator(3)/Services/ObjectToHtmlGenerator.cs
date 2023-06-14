using Domain;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ObjectToHtmlGenerator
    {
        private string text;
        public string Text { get => text; }

        public ObjectToHtmlGenerator()
        {
            text= string.Empty;
        }

        public async Task<string> Generate(string json)
        {
            ResponseEntity responseObject = JsonConvert.DeserializeObject<ResponseEntity>(json);
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <title>Document</title>\r\n</head>\r\n<body>\n");

            ObjectToHtmlTab(responseObject, stringBuilder);

            stringBuilder.AppendLine("</body>\r\n</html>");

            return text= stringBuilder.ToString();
        }

        private void ObjectToHtmlTab(ResponseEntity responseObject, StringBuilder stringBuilder) {
            stringBuilder.AppendLine("<table border=\"1\">");

            stringBuilder.AppendLine("<tr>\n<td>Creation date</td>\n<td>Title</td>\n<td>Author</td>\n<td>Answer</td>\n<td>Link</td></tr>" );



            if (responseObject.items == null)
                return;

            foreach (var x in responseObject.items)
            {
                stringBuilder.AppendLine("<tr>");

                stringBuilder.AppendLine($"<td>{x.creation_date}</td>");
                stringBuilder.AppendLine($"<td>{x.title}</td>");
                stringBuilder.AppendLine($"<td>{x.owner.display_name}</td>");
                stringBuilder.AppendLine($"<td>{x.is_answered}</td>");
                stringBuilder.AppendLine($"<td>{x.link}</td>");

                stringBuilder.AppendLine("</tr>");
            }

            stringBuilder.AppendLine("</table>");
        }


    }
}
