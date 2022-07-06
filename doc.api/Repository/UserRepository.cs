using Dapper;
using doc.api.Context;
using doc.api.Domain;
using doc.api.Interface;
using System.Data;

namespace doc.api.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext _dbContext;

        public UserRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetById(Guid id)
        {
            string query = "Select * from tbl_user where Id=@Id and Status=true";
            using (var connection = _dbContext.CreateConnection())
            {
                var user = await connection.QuerySingleOrDefaultAsync<User>(query, new { id });
                return user;
            }
        }

        public async Task<int> Create(User user)
        {
            string query = "Insert into tbl_user (Id,Username,Mail,Password,Fullname,Role,CreateDate,UpdateDate,Status) values (@Id,@Username,@Mail,@Password,@Fullname,@Role,@CreateDate,@UpdateDate,@Status)";


            var parameters = new DynamicParameters();
            parameters.Add("Id", user.Id, DbType.Guid);
            parameters.Add("Username", user.Username, DbType.String);
            parameters.Add("Mail", user.Mail, DbType.String);
            parameters.Add("Password", user.Password, DbType.String);
            parameters.Add("Fullname", user.Fullname, DbType.String);
            parameters.Add("Role", user.Role, DbType.Byte);
            parameters.Add("CreateDate", user.CreateDate, DbType.DateTime);
            parameters.Add("UpdateDate", user.UpdateDate, DbType.DateTime);
            parameters.Add("Status", user.Status, DbType.Boolean);
            using (var connection = _dbContext.CreateConnection())
            {
                var result = await connection.ExecuteAsync(query, parameters);
                return result;
            }
        }

        public async Task<User> GetByMailAndPassword(string mail, string password)
        {
            string query = "Select * from tbl_user where Mail=@Mail and Password=@Password and Status = 1";
            using (var connection = _dbContext.CreateConnection())
            {
                var user = await connection.QuerySingleOrDefaultAsync<User>(query, new { mail, password });
                return user;
            }
        }
    }
}
