using EMK.BankApp.Web.Data.Context;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Linq;

namespace EMK.BankApp.Web.TagHelpers
{
    [HtmlTargetElement("getAccountCount")]
    public class GetAccountCount : TagHelper
    {
        public int ApplicationUserID { get; set; }
        private readonly BankContext _context;

        public GetAccountCount(BankContext context)
        {
            _context = context;            
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var accountCount = _context.Accounts.Count(x => x.ApplicationUserID == ApplicationUserID);
            var html = $"<span class='badge bg-danger'>{accountCount}</span>";
            output.Content.SetHtmlContent(html);
        }
    }
}
