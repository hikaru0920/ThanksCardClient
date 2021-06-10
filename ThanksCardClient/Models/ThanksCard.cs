using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanksCardClient.Services;

namespace ThanksCardClient.Models
{
    public class ThanksCard : BindableBase
    {
        #region IdProperty
        private long _Id;
        public long Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }
        }
        #endregion

        #region TitleProperty
        private string _Title;
        public string Title
        {
            get { return _Title; }
            set { SetProperty(ref _Title, value); }
        }
        #endregion

        #region BodyProperty
        private string _Body;
        public string Body
        {
            get { return _Body; }
            set { SetProperty(ref _Body, value); }
        }
        #endregion

        #region FromIdProperty
        private long _FromId;
        public long FromId
        {
            get { return _FromId; }
            set { SetProperty(ref _FromId, value); }
        }
        #endregion

        #region FromProperty
        private User _From;
        public User From
        {
            get { return _From; }
            set { SetProperty(ref _From, value); }
        }
        #endregion

        #region ToIdProperty
        private long _ToId;
        public long ToId
        {
            get { return _ToId; }
            set { SetProperty(ref _ToId, value); }
        }
        #endregion

        #region ToProperty
        private User _To;
        public User To
        {
            get { return _To; }
            set { SetProperty(ref _To, value); }
        }
        #endregion

        #region CreatedDateTimeProperty
        private DateTime _CreatedDateTime;
        public DateTime CreatedDateTime
        {
            get { return _CreatedDateTime; }
            set { SetProperty(ref _CreatedDateTime, value); }
        }
        #endregion

        #region ThanksCardTagsProperty
        private List<ThanksCardTag> _ThanksCardTags;
        public List<ThanksCardTag> ThanksCardTags
        {
            get { return _ThanksCardTags; }
            set { SetProperty(ref _ThanksCardTags, value); }
        }
        #endregion


        public ThanksCard()
        {
            this.CreatedDateTime = DateTime.Now; 
        }

        public async Task<List<ThanksCard>> GetThanksCardsAsync()
        {
            IRestService rest = new RestService();
            List<ThanksCard> thanksCards = await rest.GetThanksCardsAsync();
            return thanksCards;
        }

        public async Task<ThanksCard> PostThanksCardAsync(ThanksCard thanksCard)
        {
            IRestService rest = new RestService();
            ThanksCard createdThanksCard = await rest.PostThanksCardAsync(thanksCard);
            return createdThanksCard;
        }
               
    /*     public async Task<ThanksCard> DeleteThanksCardAsync(ThanksCard thanksCard)
         {
             IRestService rest = new RestService();
             ThanksCard createdThanksCard = await rest.DeleteThanksCardAsync(Id);
             return thanksCard;
         } 
    */
    }
}
