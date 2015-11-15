using Application.MainModule.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Presentation.Web.Helpers
{
    public static class FormHelpers
    {
        public static MvcHtmlString DropDownListForDdSlick(this HtmlHelper htmlHelper, string id, IEnumerable<DdSlickItem> selectListItems)
        {
            var selectListHtml = "";

            foreach (var item in selectListItems)
            {
                // do this or some better way of tag building
                selectListHtml += string.Format(
                    "<option value='{0}' data-imagesrc='{1}'>{2}</option>", item.Value, item.ImageSrc, item.Text);
            }
            // do this or some better way of tag building
            var html = string.Format("<select class='form-control input-sm select-select2' id='{0}'>{1}</select>", id, selectListHtml);

            return new MvcHtmlString(html);
        }
    }
}
