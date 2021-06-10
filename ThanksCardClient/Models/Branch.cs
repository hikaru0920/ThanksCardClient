using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanksCardClient.Services;

namespace ThanksCardClient.Models
{
    public class Branch : BindableBase
    {
        #region IdProperty
        private long _Id;
        public long Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }
        }
        #endregion

        #region NameProperty
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { SetProperty(ref _Name, value); }
        }
        #endregion

        #region ParentIdProperty
        private long? _ParentId;
        public long? ParentId
        {
            get { return _ParentId; }
            set { SetProperty(ref _ParentId, value); }
        }
        #endregion

        #region ParentProperty
        private Department _Parent;
        public Department Parent
        {
            get { return _Parent; }
            set { SetProperty(ref _Parent, value); }
        }
        #endregion

        public async Task<List<Branch>> GetBranchesAsync()
        {
            IRestService rest = new RestService();
            List<Branch> Branches = await rest.GetBranchesAsync();
            return Branches;
        }

        public async Task<Branch> PostBranchAsync(Branch Branch)
        {
            IRestService rest = new RestService();
            Branch createdBranch = await rest.PostBranchAsync(Branch);
            return createdBranch;
        }

        public async Task<Branch> PutBranchAsync(Branch branch)
        {
            IRestService rest = new RestService();
            Branch updatedBranch = await rest.PutBranchAsync(branch);
            return updatedBranch;
        }

        public async Task<Branch> DeleteBranchAsync(long Id)
        {
            IRestService rest = new RestService();
            Branch deletedBranch = await rest.DeleteBranchAsync(Id);
            return deletedBranch;
        }


    }
}
