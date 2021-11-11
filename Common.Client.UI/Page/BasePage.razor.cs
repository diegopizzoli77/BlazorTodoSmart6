using Common.Client.UI.Component;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Client.UI.Page
{
    public partial class BasePage : BaseNavigationPageComponent
    {
        [Parameter]
        public bool IsBackActive { get; set; }

        [Parameter]
        public string PageTitle { get; set; }

        [Parameter]
        public RenderFragment PageContent { get; set; }
    }
}
