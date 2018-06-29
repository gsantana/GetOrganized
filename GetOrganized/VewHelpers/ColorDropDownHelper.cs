using GetOrganized.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace GetOrganized.VewHelpers
{
    public static class ColorDropDownHelper
    {
        public static object ColorTranslator { get; private set; }

        public static string Topic(string name, List<Topic> options)
        {
            var select = new TagBuilder("select"); //(1)
            select.MergeAttribute("style", "background-color: transparent;"); //(2)
            select.MergeAttribute("name", name);
            select.GenerateId(name, "");

            var optionBuilder = new StringBuilder(); //(3)

            foreach (var option in options)
            {
                var optionTag = new TagBuilder("option");
                optionTag.MergeAttribute("value", option.Id.ToString()); //(4)
                optionTag.MergeAttribute("style", "color: white; background-color: " + option.Color.ToString());
                optionTag.InnerHtml.AppendHtml(option.Name);
                var stringWriterOp = new System.IO.StringWriter();
                optionTag.WriteTo(stringWriterOp, HtmlEncoder.Default);
                optionBuilder.Append(
                  stringWriterOp.ToString());//(6)
            }

            select.InnerHtml.AppendHtml(optionBuilder.ToString());//(7)
            var stringWriter = new System.IO.StringWriter();
            select.WriteTo(stringWriter, HtmlEncoder.Default);
            return stringWriter.ToString();
        }
    }
}
