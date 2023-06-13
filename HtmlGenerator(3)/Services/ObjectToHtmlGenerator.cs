using Newtonsoft.Json;
using Services.Common;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
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
            object ResponseEntity = JsonConvert.DeserializeObject(json);
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <title>Document</title>\r\n</head>\r\n<body>\n");

            //тут будет мега метод для генерации. с рефлексией и рекурсией и прочими фишками. метод(объект,стрингбилдер)

            stringBuilder.AppendLine("</body>\r\n</html>");

            return text= stringBuilder.ToString();
        }




    }
}
