using Client.CommonService.Navigation;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Client.UI.Component
{
    public class BaseNavigationPageComponent : ComponentBase
    {
        [Inject]
        protected NavigationManager _navManager { get; set; }
        [Inject]
        protected PageHistoryState _pageState { get; set; }

        public BaseNavigationPageComponent(NavigationManager navManager, PageHistoryState pageState)
        {
            _navManager = navManager;
            _pageState = pageState;
        }
        public BaseNavigationPageComponent()
        {
        }
        protected override void OnInitialized()
        {
            base.OnInitialized();
            _pageState.AddPageToHistory(_navManager.Uri);
        }

        protected virtual void OnGoBackHandle()
        {
            _navManager.NavigateTo(_pageState.GetGoBackPage());
        }
    }
}
