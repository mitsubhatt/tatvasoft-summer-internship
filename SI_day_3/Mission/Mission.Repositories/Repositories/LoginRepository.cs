using Mission.Entities.context;
using Mission.Entities.Entities;
using Mission.Entities.Models;
using Mission.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission.Repositories.Repositories
{
    public class LoginRepository(MissionDbContext missionDbContext) : ILoginRepository
    {
        private readonly MissionDbContext _missionDbContext = missionDbContext;
        public LoginUserResponseModel login(LoginUserRequestModel model)
        {
            var existingUser = _missionDbContext.Users.Where(x=>x.EmailAddress.ToLower() == model.EmailAddress.ToLower() && !x.IsDeleted).FirstOrDefault();
            if(existingUser == null)
            {
                return new LoginUserResponseModel() { Message = "Email address Not Found" };
            }
            if (existingUser.Password.Trim() != model.Password.Trim())
            {
                return new LoginUserResponseModel() { Message = "Incorrect password" };
            }
            return new LoginUserResponseModel
            {
                Id = existingUser.Id,
                FirstName = existingUser.FirstName,
                LastName = existingUser.LastName,
                EmailAddress = existingUser.EmailAddress,
                PhoneNumber = existingUser.PhoneNumber,
                UserImage = existingUser.UserImage,
                UserType = existingUser.UserType,
                Message = "Login Successful"
            };

            //var user = _missionDbContext.Users.Where(x => x.EmailAddress == EmailAddress && x.Password == Password).FirstOrDefault();
            ////_missionDbContext.Users.Where(s => s.FirstName.StartsWith("A")).ToList();
            //if (user == null)
            //{
            //    return null;
            //}
            //return user;
        }
    }
}