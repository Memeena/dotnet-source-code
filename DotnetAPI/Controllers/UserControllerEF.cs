using AutoMapper;
using DotnetAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace DotnetAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserControllerEF : ControllerBase
    {
        DataContextEF _entityFramework;
        IUserRepository _userRepository;
        IMapper _mapper;

        public UserControllerEF(IConfiguration config, IUserRepository userRepository)
        {
            _entityFramework = new DataContextEF(config);
            _userRepository = userRepository;
            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserToAddDto, User>();
            }));
        }
        // public DateTime TestConnection()
        // {
        //     return _dapper.LoadDataSingle<DateTime>("SELECT GETDATE()");
        // }
        // [HttpGet("test/{testValue}")]
        // // public IActionResult Test()
        // public string[] Test(string testValue)
        // {
        //     string[] responseArray = new string[] {
        //         "test1","test2",testValue,
        //     };

        //     return responseArray;
        // }

        // public string[] Test(string testValue)
        // {
        //     string[] responseArray = new string[] {
        //         "test1","test2",testValue,
        //     };

        //     return responseArray;
        // }
        [HttpGet("GetUsers")]
        public IEnumerable<User> GetUsers()
        {

            IEnumerable<User> users = _userRepository.GetUsers();
            return users;
        }

        [HttpGet("GetSingleUser/{userId}")]
        public User GetSingleUser(int userId)
        {
            return _userRepository.GetSingleUser(userId);
        }

        [HttpPut("EditUSer")]
        public IActionResult EditUser(User user)
        {
            User? userdb = _entityFramework.Users.Where(u => u.UserId == user.UserId).FirstOrDefault<User>();
            if (userdb != null)
            {
                userdb.FirstName = user.FirstName;
                userdb.LastName = user.LastName;
                userdb.Email = user.Email;
                userdb.Gender = user.Gender;
                userdb.Active = user.Active;
                if (_userRepository.SaveChanges())
                {
                    return Ok();
                }
                // throw new Exception("Failed to update the suser!")

            }
            throw new Exception("Failed to update the user");

        }

        [HttpPost("AddUser")]
        public IActionResult AddUser(UserToAddDto user)
        {
            User userdb = _mapper.Map<User>(user);
            // userdb.FirstName = user.FirstName;
            // userdb.LastName = user.LastName;
            // userdb.Email = user.Email;
            // userdb.Gender = user.Gender;
            // userdb.Active = user.Active;
            _userRepository.AddEntity<User>(userdb);
            if (_userRepository.SaveChanges()) return Ok();
            throw new Exception("Failed to insert user!");

        }

        [HttpDelete("DeleteUser/{userId}")]

        public IActionResult DeleteUser(int userId)
        {
            User? userdb = _entityFramework.Users.Where(u => u.UserId == userId).FirstOrDefault();

            if (userdb != null)
            {
                _userRepository.RemoveEntity<User>(userdb);

                if (_userRepository.SaveChanges())
                {
                    return Ok();
                }
            }
            throw new Exception("Failed to delete!");

        }

    }
}

