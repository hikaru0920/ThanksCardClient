using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using ThanksCardClient.Models;

namespace ThanksCardClient.ViewModels
{
    public class ThanksCardListViewModel : BindableBase, INavigationAware
    {
        private IRegionManager regionManager;

        #region ThanksCardsProperty
        private List<ThanksCard> _ThanksCards;
        public List<ThanksCard> ThanksCards
        {
            get { return _ThanksCards; }
            set { SetProperty(ref _ThanksCards, value); }
        }
        #endregion

        public ThanksCardListViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }


        public async void OnNavigatedTo(NavigationContext navigationContext)
        {
            ThanksCard thanksCard = new ThanksCard();
            this.ThanksCards = await thanksCard.GetThanksCardsAsync();

        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

       /* #region DeleteThanksCardCommand
        private DelegateCommand<ThanksCard> _DeleteThanksCardCommand;
        public DelegateCommand<ThanksCard> DeleteThanksCardCommand =>
            _DeleteThanksCardCommand ?? (_DeleteThanksCardCommand = new DelegateCommand<ThanksCard>(ExecuteDeleteThanksCardCommand));

        async void ExecuteDeleteThanksCardCommand(Department SelectThanksCard)
        {
            ThanksCard deleteThanksCard = await SelectThanksCard.DeleteThanksCardAsync(SelectThanksCard.Id);
        }
      #endregion */
    }
}