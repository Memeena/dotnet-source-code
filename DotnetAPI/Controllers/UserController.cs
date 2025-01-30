using Microsoft.AspNetCore.Mvc;

namespace DotnetAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        DataContextDapper _dapper;
        public UserController(IConfiguration config)
        {
            _dapper = new DataContextDapper(config);
        }
        [HttpGet("TestConnection")]
        public DateTime TestConnection()
        {
            return _dapper.LoadDataSingle<DateTime>("SELECT GETDATE()");
        }
        [HttpGet("test/{testValue}")]
        // public IActionResult Test()
        public string[] Test(string testValue)
        {
            string[] responseArray = new string[] {
                "test1","test2",testValue,
            };

            return responseArray;
        }

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
            string sql = @"SELECT UserID,FirstName,LastName,Email,Gender,Active FROM TutorialAppSchema.Users";
            IEnumerable<User> users = _dapper.LoadData<User>(sql);
            return users;
        }
        [HttpGet("GetSingleUser/{userId}")]
        public User GetSingleUser(int userId)
        {
            string sql = @"SELECT UserID,FirstName,LastName,Email,Gender,Active FROM TutorialAppSchema.Users WHERE UserId = " + userId.ToString();
            User user = _dapper.LoadDataSingle<User>(sql);
            return user;
        }

        [HttpPut("EditUSer")]
        public IActionResult EditUser(User user)
        {
            string sql = @$"UPDATE TutorialAppSchema.Users 
                            SET [FirstName] = '{user.FirstName}',
                             [LastName] = '{user.LastName}',
                             [Email] = '{user.Email}',
                             [Gender] = '{user.Gender}',
                             [Active] = '{user.Active}'
                            WHERE UserId = {user.UserId}";

            if (_dapper.ExecuteSql(sql))
            {
                return Ok();
            }
            throw new Exception("Failed to update user!");

        }

        [HttpPost("AddUser")]
        public IActionResult AddUser(UserToAddDto user)
        {
            string sql = @$"INSERT INTO TutorialAppSchema.Users(
            [FirstName],
            [LastName],
            [Email],
            [Gender],
            [Active]) VALUES (
            '{user.FirstName}',
        '{user.LastName}',
    '{user.Email}',
'{user.Gender}',
'{user.Active}');";

            Console.WriteLine(sql);
            if (_dapper.ExecuteSql(sql))
            {
                return Ok();
            }
            throw new Exception("Failed to insert user!");

        }

        [HttpDelete("DeleteUser/{userId}")]

        public IActionResult DeleteUser(int userId)
        {
            string sql = $@"DELETE FROM TutorialAppSchema.Users 
            WHERE UserId = {userId.ToString()} ;";
            if (_dapper.ExecuteSql(sql))
            {
                return Ok();
            }
            throw new Exception("Failed to delete!");

        }

    }
}

