using Client.MVVM.CommonInterface;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Client.UI.View
{
    public partial class BaseViewComponent<TViewModel, T> where TViewModel : IViewModelBase<T> where T : class
    {
        public BaseViewComponent()
        {

        }


        [Inject]
        public TViewModel BaseViewModel { get; set; }

        [Parameter]
        public RenderFragment<TViewModel> Content { get; set; }

        async void OnPropertyChangedHandler(object sender, PropertyChangedEventArgs e)
        {
            await InvokeAsync(() =>
            {
                StateHasChanged();
            });
        }

        public void Dispose()
        {
            BaseViewModel.PropertyChanged -= OnPropertyChangedHandler;
        }
        protected override async Task OnInitializedAsync()
        {
            BaseViewModel.PropertyChanged += OnPropertyChangedHandler;

            


            await base.OnInitializedAsync();
        }

    }
}
