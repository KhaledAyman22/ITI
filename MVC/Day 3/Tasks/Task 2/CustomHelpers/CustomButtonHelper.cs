using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task_2.CustomHelpers
{
    public static class CustomButtonHelper
    {
        public static MvcHtmlString CustomButton(this HtmlHelper htmlHelper, string buttonText, Dictionary<string, string> attributes = null)
        {
            TagBuilder buttonTag = new TagBuilder("button");
            buttonTag.InnerHtml = buttonText;

            if(attributes != null)
            foreach (var item in attributes)
            {
                buttonTag.Attributes.Add(item.Key, item.Value);
            }

            return MvcHtmlString.Create(buttonTag.ToString());
        }
    }
}