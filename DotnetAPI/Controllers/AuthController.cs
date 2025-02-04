using System.Data;
using System.Security.Cryptography;
using System.Text;
using DotnetAPI.Dtos;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace DotnetAPI.Controllers
{
    public class AuthController : Controller
    {
        private readonly DataContextDapper _dapper;
        private readonly IConfiguration _config;

        public AuthController(IConfiguration config)
        {
            _config = config;
            _dapper = new DataContextDapper(config);
        }

        [HttpPost("Register")]
        public IActionResult Register(UserForRegistraionDto userForRegistraion)
        {
            if (userForRegistraion.Password == userForRegistraion.PasswordConfirm)
            {
                string sqlUserExistCheck = "SELECT Email FROM TutorialAppSchema.Auth WHERE Email = '" + userForRegistraion.Email + "; ";
                IEnumerable<string> existingUsers = _dapper.LoadData<string>(sqlUserExistCheck);
                if (existingUsers.Count() == 0)
                {
                    byte[] PasswordSalt = new byte[128 / 8];
                    using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
                    {
                        rng.GetNonZeroBytes(PasswordSalt);
                    }

                    string passwordSaltPlusString = _config.GetSection("AppSettings:PasswordKey").Value + Convert.ToBase64String(PasswordSalt);

                    byte[] PasswordHash = KeyDerivation.Pbkdf2(
                        password: userForRegistraion.Password,
                        salt: Encoding.ASCII.GetBytes(passwordSaltPlusString),
                        prf: KeyDerivationPrf.HMACSHA256,
                        iterationCount: 1000000,
                        numBytesRequested: 256 / 8
                    );

                    string SqlAddAuth = $@"INSERT INTO TutorialAppSchema.Auth([Email],[PasswordHash],[PasswordSalt]) VALUES ('{userForRegistraion.Email}',{PasswordHash},{PasswordSalt})";

                    List<SqlParameter> sqlParameters = new List<SqlParameter>();

                    SqlParameter passwordSaltParameter = new SqlParameter("@PasswordSalt", SqlDbType.VarBinary);
                    passwordSaltParameter.Value = PasswordSalt;

                    SqlParameter passwordHashParameter = new SqlParameter("@PasswordHash", SqlDbType.VarBinary);
                    passwordHashParameter.Value = PasswordHash;

                    sqlParameters.Add(passwordSaltParameter);
                    sqlParameters.Add(passwordHashParameter);

                    if (_dapper.ExecuteSqlWithParameters(SqlAddAuth, sqlParameters))
                    {

                        return Ok();
                    }
                    throw new Exception("Registration failed!");

                }
                throw new Exception("User already exists!");
            }
            throw new Exception("Passwords do not match!");
        }
        [HttpPost("Login")]
        public IActionResult Login(UserForLoginDto userForLogin)
        {
            return Ok();
        }
    }
}