using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThanksCardClient.Models;
using ThanksCardClient.Services;

namespace ThanksCardClient.ViewModels
{
    public class LogonViewModel : BindableBase
    {
        private IRegionManager regionManager;

        #region UserProperty
        private User _User;
        public User User
        {
            get { return _User; }
            set { SetProperty(ref _User, value); }
        }
        #endregion

        #region ErrorMessage
        private string _ErrorMessage;
        public string ErrorMessage
        {
            get { return _ErrorMessage; }
            set { SetProperty(ref _ErrorMessage, value); }
        }
        #endregion

        public LogonViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;

            // 開発中のみアカウントを admin/admin でセットしておく。
            this.User = new User();
            this.User.Name = "admin";
            this.User.Password = "admin";
        }

        #region LogonCommand
        private DelegateCommand _LogonCommand;
        public DelegateCommand LogonCommand =>
            _LogonCommand ?? (_LogonCommand = new DelegateCommand(ExecuteLogonCommandAsync));

        async void ExecuteLogonCommandAsync()
        {
            User authorizedUser = await this.User.LogonAsync();

            // authorizedUser が null でなければログオンに成功している。
            if (authorizedUser != null)
            {
                SessionService.Instance.IsAuthorized = true;
                SessionService.Instance.AuthorizedUser = authorizedUser;
                this.ErrorMessage = "";
                this.regionManager.RequestNavigate("HeaderRegion", nameof(Views.HomePage));
                this.regionManager.RequestNavigate("ContentRegion", nameof(Views.ThanksCardList));
                //this.regionManager.RequestNavigate("FooterRegion", nameof(Views.ThanksCardList));
                //this.regionManager.RequestNavigate("ContentRegion", nameof(Views.HomePage));
            }
            else
            {
                this.ErrorMessage = "ログオンに失敗しました。";
            }
        }
        #endregion

        #region SignUpCommand
        private DelegateCommand _SignUpCommand;
        public DelegateCommand SignUpCommand =>
            _SignUpCommand ?? (_SignUpCommand = new DelegateCommand(ExecuteCommandName));

        void ExecuteCommandName()
        {
            this.regionManager.Regions["HeaderRegion"].RemoveAll();
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.SignUp));
            this.regionManager.Regions["FooterRegion"].RemoveAll();
        }
        #endregion
    }
}
