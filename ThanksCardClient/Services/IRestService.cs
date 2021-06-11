using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanksCardClient.Models;

namespace ThanksCardClient.Services
{
    interface IRestService
    {
        // Logon REST API Client
        Task<User> LogonAsync(User user);

        // DepartmentUsers REST API Client
        Task<List<User>> GetDepartmentUsersAsync(long? DepartmentId);

        // BranchUsers REST API Client
        Task<List<User>> GetBranchUsersAsync(long? BranchId);

        // User REST API Client
        Task<List<User>> GetUsersAsync();
        Task<User> PostUserAsync(User user);
        Task<User> PutUserAsync(User user);
        Task<User> DeleteUserAsync(long Id);

        // Department REST API Client
        Task<List<Department>> GetDepartmentsAsync();
        Task<Department> PostDepartmentAsync(Department department);
        Task<Department> PutDepartmentAsync(Department department);
        Task<Department> DeleteDepartmentAsync(long Id);

        // Branch REST API Client
        Task<List<Branch>> GetBranchesAsync();
        Task<Branch> PostBranchAsync(Branch branch);
        Task<Branch> PutBranchAsync(Branch branch);
        Task<Branch> DeleteBranchAsync(long Id);

        // TanksCard REST API Client
        Task<List<ThanksCard>> GetThanksCardsAsync();
        Task<ThanksCard> PostThanksCardAsync(ThanksCard thanksCard);

        // Tag REST API Client
        Task<List<Tag>> GetTagsAsync();
        Task<Tag> PostTagAsync(Tag tag);
        Task<Tag> PutTagAsync(Tag tag);
        Task<Tag> DeleteTagAsync(long Id);


        // Task<ThanksCard> DeleteThanksCardAsync(long id);



    }
}
