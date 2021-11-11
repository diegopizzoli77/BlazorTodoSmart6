using Client.CommonService.Interface;
using Client.MVVM.CommonInterface;
using Client.MVVM.CommonInterface.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Client.MVVM.CommonInterface.Enum.IViewModelEnum;

namespace Client.MVVM.Common
{
    public class BaseCRUDViewModel<T> : BaseViewModel<T>, ICRUDViewModel<T> where T : class,new()
    {


        #region Private Variables

        protected StateView actualStateView = StateView.Read;
        protected bool isSaving = false;

        #endregion

        #region ctor

        public BaseCRUDViewModel(IBaseService<T> bService) : base(bService)
        {

        }

        #endregion

        #region Properties

        public StateView ActualStateView
        {
            get { return actualStateView; }
            set
            {
                if (value != actualStateView)
                {
                    actualStateView = value;
                    OnPropertyChanged("ActualStateView");
                }
            }
        }
        public bool IsSaving
        {
            get => isSaving;
            set
            {
                if (value != isSaving)
                {
                    isSaving = value;
                    OnPropertyChanged("IsSaving");
                }
            }
        }


        #endregion


        public virtual async Task<T> Add()
        {
            ChangeViewState(StateView.Create);
            CurrentItem = await Task.Run(() => new T());
            await BindModelToViewModel();
            return CurrentItem;
        }

        public virtual bool Cancel()
        {
            ChangeViewState(StateView.Read);
            return true;
        }

        public void ChangeViewState(StateView newViewState)
        {
            ActualStateView = newViewState;
        }

        public virtual bool Edit()
        {
            ChangeViewState(StateView.Edit);
            return true;
        }

        public Task<bool> FinalDelete(T item)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> LogicalDelete(T item)
        {
            bool res = await baseService.LogicalDelete(item);
            ChangeViewState(StateView.Read);

            return res;
        }

        public async virtual Task<bool> Save(T item)
        {
            bool res = true;
            IsSaving = true;
            try
            {
                await BindViewModelToModel(item);

                if (ActualStateView == StateView.Create)
                {
                    CurrentItem = await baseService.Insert(item);
                    await BindModelToViewModel();
                }

                if (ActualStateView == StateView.Edit)
                {
                    res = await baseService.Update(item);
                }

                ChangeViewState(StateView.Read);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                IsSaving = false;
            }

            return res;
        }

        public async Task<T> SelectById(int id_dto)
        {
            try
            {
                IsLoading = true;

                ChangeViewState(StateView.Read);

                var res = await baseService.SelectById(id_dto);

                return res;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}
