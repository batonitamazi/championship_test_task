using Upgaming_test_task.ViewModels;

namespace Upgaming_test_task.NewFolder
{
    public interface IUserService
    {
        Task<List<ResultStatusViewModel>> UploadUserData(List<UserViewModel> users);
        Task<List<UserViewModel>> GetAllUsers();
        Task<List<ResultStatusViewModel>> UploadUserScores(List<UserScoreViewModel> users);


    }
}
