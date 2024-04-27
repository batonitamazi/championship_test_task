using Upgaming_test_task.Models;
using Upgaming_test_task.Repositories;
using Upgaming_test_task.ViewModels;

namespace Upgaming_test_task.NewFolder
{
    public class UserService : IUserService
    {
        public readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<List<ResultStatusViewModel>> UploadUserData(List<UserViewModel> users)
        {
            List<ResultStatusViewModel> response = new List<ResultStatusViewModel>();

            foreach (var user in users)
            {
                if (await userRepository.IsUsernameUnique(user.UserName))
                {
                    var userModel = new User
                    {
                        Name = user.Name,
                        Surname = user.Surname,
                        UserName = user.UserName,
                    };
                    await userRepository.AddUser(userModel);
                    response.Add(new ResultStatusViewModel { Error = $"Successfully added user with username-{user.UserName}", Added = true, Status = "Added" });

                }
                else
                {
                    response.Add(new ResultStatusViewModel { Error = $"UserName-{user.UserName} already exists", Added = false, Status = "Not Added" });
                }
            }
            return response;
        }

        public async Task<List<ResultStatusViewModel>> UploadUserScores(List<UserScoreViewModel> scores)
        {
            List<ResultStatusViewModel> response = new List<ResultStatusViewModel>();

            foreach (var score in scores)
            {
                if(!await userRepository.CheckUserExist(score.UserId))
                {
                    response.Add(new ResultStatusViewModel { Error = $"user with that UserId not exist - {score.UserId}", Added = false, Status = "Not Added" });
                }
                else
                {
                    UserScore userScore = new UserScore
                    {
                        UserId = score.UserId,
                        Date = score.Date,
                        Score = score.Score,
                    };
                    await userRepository.AddUserScore(userScore);
                    response.Add(new ResultStatusViewModel { Error = $"successfully added user Score with id-{score.UserId} and date {score.Date}", Added = true, Status = "Added" });
                }
            }
            return response;
        }
        public async Task<List<UserViewModel>> GetAllUsers()
        {
            List<User> users = await userRepository.GetAllUsers();
            List<UserViewModel> result = users.Select(k => new UserViewModel { Name = k.Name, UserName = k.UserName, Surname = k.Surname, }).ToList();
            return result;
        }

        public async Task<UserRatingViewModel> GetUserInfo(int user_id)
        {
            List<UserRating> usersInfo = await userRepository.GetUsersInfo();

            var userInfo = usersInfo.FirstOrDefault(k => k.UserId == user_id);
            if(userInfo != null)
                return new UserRatingViewModel { Rating = CalculateUserRating(userInfo, usersInfo), UserName = userInfo.UserName, Score = userInfo.Score };
            return new UserRatingViewModel { };
        }

        private int CalculateUserRating(UserRating userRating, List<UserRating> allUserRatings)
        {
            int userScore = userRating.Score;

            int higherUserScoresCount = allUserRatings.Count(u => u.Score > userScore);

            int rating = higherUserScoresCount + 1;

            return rating;
        }
    }
}
