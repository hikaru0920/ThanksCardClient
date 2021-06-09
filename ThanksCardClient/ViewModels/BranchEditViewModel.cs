using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using ThanksCardClient.Models;

namespace ThanksCardClient.ViewModels
{
    public class BranchEditViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager regionManager;

        #region BranchProperty
        private Branch _Branch;
        public Branch Branch
        {
            get { return _Branch; }
            set { SetProperty(ref _Branch, value); }
        }
        #endregion

        #region BranchesProperty
        private List<Branch> _Branches;
        public List<Branch> Branches
        {
            get { return _Branches; }
            set { SetProperty(ref _Branches, value); }
        }
        #endregion

        #region ErrorMessageProperty
        private string _ErrorMessage;
        public string ErrorMessage
        {
            get { return _ErrorMessage; }
            set { SetProperty(ref _ErrorMessage, value); }
        }
        #endregion

        public BranchEditViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;

        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            // 画面遷移元から送られる SelectedTag パラメーターを取得。
            this.Branch = navigationContext.Parameters.GetValue<Branch>("SelectedBranch");

            this.UpdateBranches();
        }

        private async void UpdateBranches()
        {
            Branch brn = new Branch();
            this.Branches = await brn.GetBranchesAsync();
        }

        #region SubmitCommand
        private DelegateCommand _SubmitCommand;
        public DelegateCommand SubmitCommand =>
            _SubmitCommand ?? (_SubmitCommand = new DelegateCommand(ExecuteSubmitCommand));

        async void ExecuteSubmitCommand()
        {
            Branch updatedBranch = await this.Branch.PutBranchAsync(this.Branch);

            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.BranchMst));
        }
        #endregion

    }
}
