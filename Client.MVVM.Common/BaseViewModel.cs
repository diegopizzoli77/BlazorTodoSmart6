using Client.CommonService.Interface;
using Client.MVVM.Common.Binding;
using Client.MVVM.CommonInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Client.MVVM.Common
{
    public class BaseViewModel<T> : IViewModelBase<T> where T:class
    {
        protected bool isLoading = false;
        protected bool isFirstLoad = false;
        protected T currentItem = null;
        protected IBaseService<T> baseService;



        public BaseViewModel(IBaseService<T> bService)
        {
            baseService = bService;
        }

        public bool IsLoading
        {
            get => isLoading;
            set
            {
                if (value != isLoading)
                {
                    isLoading = value;
                    OnPropertyChanged("IsLoading");
                }
            }
        }
        public bool IsFirstLoad 
        {
            get => isFirstLoad;
            set
            {
                if (value != isFirstLoad)
                {
                    isFirstLoad = value;
                    OnPropertyChanged("IsFirstLoad");
                }
            }
        }
        public T CurrentItem {
            get { return currentItem; }

            set
            {
                if (value != currentItem)
                {
                    currentItem = value;
                    OnPropertyChanged("CurrentItem");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual async Task CopyModelToViewModel<TS, TT>(TS source, TT target) where TS : class where TT : BaseViewModel<T>
        {
            IsLoading = true;
            try
            {
                await ObjectBinding<TS, TT>.ParallelCopy(source, target);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                IsLoading = false;
            }


        }

        protected virtual async Task CopyViewModelToModel<TS, TT>(TT source, TS target) where TS : class where TT : BaseViewModel<T>
        {
            await ObjectBinding<TT, TS>.ParallelCopy(source, target);
        }

        public virtual async Task<T> BindViewModelToModel(T model)
        {
            await CopyViewModelToModel(this, model);
            return model;
        }

        public virtual async Task BindModelToViewModel()
        {
            await CopyModelToViewModel(CurrentItem, this);
        }
    }
}
