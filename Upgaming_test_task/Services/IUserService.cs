using Upgaming_test_task.ViewModels;

namespace Upgaming_test_task.NewFolder
{
    public interface IUserService
    {
        Task<List<ResultModel>> UploadUserData(List<UserViewModel> users);
        Task<List<UserViewModel>> GetAllUsers();
        Task<List<ResultModel>> UploadUserScores(List<UserScoreViewModel> users);
        Task<UserRatingViewModel> GetUserInfo(int user_id);


    }
}
