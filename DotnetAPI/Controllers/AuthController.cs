using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using DotnetAPI.Dtos;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;

namespace DotnetAPI.Controllers
{
    public class AuthController : ControllerBase
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
                string sqlUserExistCheck = "SELECT Email FROM TutorialAppSchema.Auth WHERE Email = '" + userForRegistraion.Email + "'";

                Console.WriteLine(sqlUserExistCheck);

                IEnumerable<string> existingUsers = _dapper.LoadData<string>(sqlUserExistCheck);

                if (existingUsers.Count() == 0)
                {
                    byte[] passwordSalt = new byte[128 / 8];
                    using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
                    {
                        rng.GetNonZeroBytes(passwordSalt);
                    }
                    // Console.WriteLine(PasswordSalt);
                    byte[] passwordHash = GetPasswordHash(userForRegistraion.Password, passwordSalt);
                    // Console.WriteLine("0x" + BitConverter.ToString(PasswordHash).Replace("-", ""));


                    string SqlAddAuth = @"INSERT INTO TutorialAppSchema.Auth
                    ([Email],[PasswordHash],[PasswordSalt]) 
                    VALUES('" + userForRegistraion.Email + "', @passwordHash, @passwordSalt)";

                    Console.WriteLine(SqlAddAuth);
                    List<SqlParameter> sqlParameters = new List<SqlParameter>();

                    SqlParameter passwordSaltParameter = new SqlParameter("@passwordSalt", SqlDbType.VarBinary);
                    passwordSaltParameter.Value = passwordSalt;

                    SqlParameter passwordHashParameter = new SqlParameter("@passwordHash", SqlDbType.VarBinary);
                    passwordHashParameter.Value = passwordHash;
                    // Console.WriteLine(passwordSaltParameter);

                    sqlParameters.Add(passwordSaltParameter);
                    sqlParameters.Add(passwordHashParameter);

                    if (_dapper.ExecuteSqlWithParameters(SqlAddAuth, sqlParameters))
                    {
                        string sqlAddUser = @$"INSERT INTO TutorialAppSchema.Users(
                                      [FirstName],
                                      [LastName],
                                      [Email],
                                      [Gender],
                                      [Active]) VALUES (
                                    '{userForRegistraion.FirstName}',
                                    '{userForRegistraion.LastName}',
                                    '{userForRegistraion.Email}',
                                    '{userForRegistraion.Gender}',
                                    1);";
                        if (_dapper.ExecuteSql(sqlAddUser))
                        {
                            return Ok();
                        }
                        throw new Exception("Failed to add User!");
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
            Console.WriteLine(userForLogin.Email);
            string sqlForHashAndSalt = $@"SELECT PasswordHash,PasswordSalt FROM TutorialAppSchema.Auth WHERE Email = '{userForLogin.Email}' ";

            Console.WriteLine(sqlForHashAndSalt);
            UserForLoginConfirmationDto userForConfirmation = _dapper.LoadDataSingle<UserForLoginConfirmationDto>(sqlForHashAndSalt);

            byte[] PasswordHash = GetPasswordHash(userForLogin.Password, userForConfirmation.PasswordSalt);

            for (int index = 0; index < PasswordHash.Length; index++)
            {
                if (PasswordHash[index] != userForConfirmation.PasswordHash[index])
                {
                    return StatusCode(401, "Incorrect Password!");
                }
            }

            string userIdSql = "SELECT UserId FROM TutorialAppSchema.Users WHERE Email = '" + userForLogin.Email + "'";

            int userId = _dapper.LoadDataSingle<int>(userIdSql);

            return Ok(new Dictionary<string, string>
            {
                {"token",CreateToken(userId)}
            });
        }

        private byte[] GetPasswordHash(string password, byte[] passwordSalt)
        {
            string passwordSaltPlusString = _config.GetSection("AppSettings:PasswordKey").Value + Convert.ToBase64String(passwordSalt);
            return KeyDerivation.Pbkdf2(
                            password: password,
                            salt: Encoding.ASCII.GetBytes(passwordSaltPlusString),
                            prf: KeyDerivationPrf.HMACSHA256,
                            iterationCount: 1000000,
                            numBytesRequested: 256 / 8
                        );
        }

        private string CreateToken(int userId)
        {
            Claim[] claims = new Claim[] {
                new("userId",userId.ToString())
            };

            string? tokenKeyString = _config.GetSection("AppSettings:TokenKey").Value;

            SymmetricSecurityKey tokenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKeyString != null ? tokenKeyString : ""));

            SigningCredentials credentials = new SigningCredentials(tokenKey, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = credentials,
                Expires = DateTime.Now.AddDays(1)

            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            SecurityToken token = tokenHandler.CreateToken(descriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}