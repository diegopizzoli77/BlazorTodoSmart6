using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;

namespace BlazorTodoSmart6.Client.Pages
{
    public partial class ActivityPageList
    {

        private string filterDate = string.Empty;
        private DateTime? myfilterDate;
        private int myFilterMode =0;

        protected override void OnInitialized()
        {
            var uri = NavManager.ToAbsoluteUri(NavManager.Uri);

            var queryStrings = QueryHelpers.ParseQuery(uri.Query);
            if (queryStrings.TryGetValue("filterDate", out var outDate))
            {
                filterDate = outDate;
                if (!string.IsNullOrEmpty(filterDate))
                {
                    CultureInfo provider = CultureInfo.InvariantCulture;
                    // It throws Argument null exception  
                    myfilterDate = DateTime.ParseExact(filterDate, "yyyy/MM/dd HH:mm:ss", provider);
                }
            }

            if (queryStrings.TryGetValue("filterMode", out var filterm))
            {
                myFilterMode = Convert.ToInt32(filterm);
            }
            

            base.OnInitialized();
        }
    }
}
