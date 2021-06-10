using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using ThanksCardClient.Models;

namespace ThanksCardClient.ViewModels
{
    public class BranchMstViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager regionManager;

        #region BranchesProperty
        private List<Branch> _Branches;
        public List<Branch> Branches
        {
            get { return _Branches; }
            set { SetProperty(ref _Branches, value); }
        }
        #endregion

        public BranchMstViewModel(IRegionManager regionManager)
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
            this.UpdateBranches();
        }

        private async void UpdateBranches()
        {
            Branch brn = new Branch();
            this.Branches = await brn.GetBranchesAsync();
        }

        #region BranchCreateCommand
        private DelegateCommand _BranchCreateCommand;
        public DelegateCommand BranchCreateCommand =>
            _BranchCreateCommand ?? (_BranchCreateCommand = new DelegateCommand(ExecuteBranchCreateCommand));

        void ExecuteBranchCreateCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.BranchCreate));
        }
        #endregion

        #region BranchEditCommand
        private DelegateCommand<Branch> _BranchEditCommand;
        public DelegateCommand<Branch> BranchEditCommand =>
            _BranchEditCommand ?? (_BranchEditCommand = new DelegateCommand<Branch>(ExecuteBranchEditCommand));

        void ExecuteBranchEditCommand(Branch SelectedBranch)
        {
            // 対象のBranchをパラメーターとして画面遷移先に渡す。
            var parameters = new NavigationParameters();
            parameters.Add("SelectedBranch", SelectedBranch);

            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.BranchEdit), parameters);
        }
        #endregion

        #region BranchDeleteCommand
        private DelegateCommand<Branch> _BranchDeleteCommand;
        public DelegateCommand<Branch> BranchDeleteCommand =>
            _BranchDeleteCommand ?? (_BranchDeleteCommand = new DelegateCommand<Branch>(ExecuteBranchDeleteCommand));

        async void ExecuteBranchDeleteCommand(Branch SelectedBranch)
        {
            Branch deletedBranch = await SelectedBranch.DeleteBranchAsync(SelectedBranch.Id);

            // 一覧 Departments を更新する。
            this.UpdateBranches();
        }
        #endregion
    }
}
