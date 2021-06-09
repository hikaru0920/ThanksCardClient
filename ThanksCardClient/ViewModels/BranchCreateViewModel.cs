using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using ThanksCardClient.Models;

namespace ThanksCardClient.ViewModels
{
    public class BranchCreateViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager regionManager;

        #region UserProperty
        private User _User;
        public User User
        {
            get { return _User; }
            set { SetProperty(ref _User, value); }
        }
        #endregion

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

        public BranchCreateViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.UpdateBranches();
        }

        private async void UpdateBranches()
        {
            Branch bra = new Branch();
            this.Branches = await bra.GetBranchesAsync();

            this.Branch = new Branch();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        #region SubmitCommand
        private DelegateCommand _SubmitCommand;
        public DelegateCommand SubmitCommand =>
            _SubmitCommand ?? (_SubmitCommand = new DelegateCommand(ExecuteSubmitCommand));

        async void ExecuteSubmitCommand()
        {
            Branch createBranch = await Branch.PostBranchAsync(this.Branch);

            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.BranchMst));
        }
        #endregion

    }
}
