using Syncfusion.EJ.ReportViewer;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;

namespace Presentation.Web.WebApi
{
    public class RdlcController : ApiController, IReportController
    {
        //Gets action for getting resources from the report.
        [ActionName("GetResource")]
        [AcceptVerbs("GET")]
        public object GetResource(string key, string resourcetype, bool isPrint)
        {
            return ReportHelper.GetResource(key, resourcetype, isPrint);
        }

        //Calls method when initializing the report option before starting to process the report.
        public void OnInitReportOptions(ReportViewerOptions reportOption)
        {
            reportOption.ReportModel.ReportPath = string.Format(@"{0}bin\Rdlc\{1}", HttpContext.Current.Request.PhysicalApplicationPath, reportOption.ReportModel.ReportPath);
        }

        // Calls method when report is loaded.
        public void OnReportLoaded(ReportViewerOptions reportOption)
        {
            //Updates report options here.
        }

        //Posts action for processing the rdl/rdlc report.
        public object PostReportAction(Dictionary<string, object> jsonResult)
        {
            return ReportHelper.ProcessReport(jsonResult, this);
        }
    }
}