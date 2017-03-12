using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using GameSharpApi.ViewModels;

namespace GameSharpWeb.Builders
{
    public static class HtmlTableBuilder
    {
        public static HtmlString RenderGamesTable(this IHtmlHelper helper, IList<GameViewModel> games)
        {
            var table = new TagBuilder("table");
            var thead = new TagBuilder("thead");
            var tbody = new TagBuilder("tbody");

            table.AddCssClass("table");
            thead.InnerHtml.AppendHtml(new HtmlString(@"
                <tr>
                    <th>ID</th>
                    <th>Name</th>
                    <th>Publisher</th>
                    <th>Publish Date</th>
                </tr>"));
            
            StringBuilder builder = new StringBuilder();
            foreach (var game in games)
            {
                builder = builder.Append($"<tr><td><a href=\"/{game.ID}\">{game.ID}</a></td><td>{game.Name}</td><td>{game.Publisher}</td><td>{game.PublishDate}</td></tr>");
            }
            tbody.InnerHtml.AppendHtml(new HtmlString(builder.ToString()));
            table.InnerHtml.AppendHtml(thead).AppendHtml(tbody);

            using (var writer = new StringWriter())
            {
                table.WriteTo(writer, HtmlEncoder.Default);
                return new HtmlString(writer.ToString());
            }
        }
    }
}
