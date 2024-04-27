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

            var uniqueUsernames = await userRepository.GetUniqueUsernames(users.Select(u => u.UserName.ToLower()).ToList());

            var usersToAdd = users.Where(u => !uniqueUsernames.Contains(u.UserName.ToLower())).Select(u => new User
            {
                Name = u.Name,
                Surname = u.Surname,
                UserName = u.UserName
            }).ToList();

            await userRepository.AddUsers(usersToAdd);

            foreach (var user in users)
            {
                if (uniqueUsernames.Contains(user.UserName.ToLower()))
                {
                    response.Add(new ResultStatusViewModel { Message = $"UserName-{user.UserName} already exists", Added = false, Status = "Not Added" });
                }
                else
                {
                    response.Add(new ResultStatusViewModel { Message = $"Successfully added user with username-{user.UserName}", Added = true, Status = "Added" });
                }
            }

            return response;
        }

        public async Task<List<ResultStatusViewModel>> UploadUserScores(List<UserScoreViewModel> scores)
        {
            List<ResultStatusViewModel> response = new List<ResultStatusViewModel>();

            var uniqueUsers = await userRepository.CheckUsersExist(scores.Select(k => k.UserId).ToList());

            var userScores = scores.Where(u => uniqueUsers.Contains(u.UserId)).Select(u => new UserScore
            {
                Date = u.Date,
                UserId = u.UserId,
                Score = u.Score
            }).ToList();
            await userRepository.AddUserScores(userScores);

            foreach (var userScore in scores)
            {
                if (!uniqueUsers.Contains(userScore.UserId))
                {
                    response.Add(new ResultStatusViewModel { Message = $"user with that UserId not exist - {userScore.UserId}", Added = false, Status = "Not Added" });
                }
                else
                {
                    response.Add(new ResultStatusViewModel { Message = $"successfully added Score with id-{userScore.UserId} and date {userScore.Date}", Added = true, Status = "Added" });

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
            if (userInfo != null)
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
