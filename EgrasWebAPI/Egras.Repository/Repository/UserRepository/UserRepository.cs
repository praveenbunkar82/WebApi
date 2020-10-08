using Dapper;
using Egras.Entities;
using Egras.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using static System.Data.CommandType;

namespace Egras.Repository
{
    public class UserRepository : BaseRepository, IUserRepository//IRepository<User>//
    {
        //bool IUserRepository.AddUser(User user)
        //{
        //    try
        //    {
        //        DynamicParameters parameters = new DynamicParameters();
        //        parameters.Add("@UserName", user.UserName);
        //        parameters.Add("@UserMobile", user.UserMobile);
        //        parameters.Add("@UserEmail", user.UserEmail);
        //        parameters.Add("@FaceBookUrl", user.FaceBookUrl);
        //        parameters.Add("@LinkedInUrl", user.LinkedInUrl);
        //        parameters.Add("@TwitterUrl", user.TwitterUrl);
        //        parameters.Add("@PersonalWebUrl", user.PersonalWebUrl);

        //        //SqlMapper.Execute(con, "AddUser", param: parameters, commandType: StoredProcedure);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //bool IUserRepository.DeleteUser(int userId)
        //{
        //    DynamicParameters parameters = new DynamicParameters();
        //    parameters.Add("@UserId", userId);
        //    SqlMapper.Execute(con, "DeleteUser", param: parameters, commandType: StoredProcedure);
        //    return true;
        //}

        //public IList<User> GetAllUser() => SqlMapper.Query<User>(con, "GetAllUsers", commandType: StoredProcedure).ToList();

        //User IUserRepository.GetUserById(int userId)
        //{
        //    try
        //    {
        //        DynamicParameters parameters = new DynamicParameters();
        //        parameters.Add("@CustomerID", userId);
        //        return SqlMapper.Query<User>((SqlConnection)con, "GetUserById", parameters, commandType: StoredProcedure).FirstOrDefault();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //bool IUserRepository.UpdateUser(User user)
        //{
        //    try
        //    {
        //        DynamicParameters parameters = new DynamicParameters();
        //        parameters.Add("@UserId", user.UserId);
        //        parameters.Add("@UserName", user.UserName);
        //        parameters.Add("@UserMobile", user.UserMobile);
        //        parameters.Add("@UserEmail", user.UserEmail);
        //        parameters.Add("@FaceBookUrl", user.FaceBookUrl);
        //        parameters.Add("@LinkedInUrl", user.LinkedInUrl);
        //        parameters.Add("@TwitterUrl", user.TwitterUrl);
        //        parameters.Add("@PersonalWebUrl", user.PersonalWebUrl);

        //        SqlMapper.Execute(con, "UpdateUser", param: parameters, commandType: StoredProcedure);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public void InsertMultipleUsers()
        //{
        //    object myObj = new[] {
        //        new { name = "B Narayan", email = "bnarayan.sharma@outlook.com" },
        //        new { name = "Manish Sharma", email = "manish.sharma**@outlook.com" },
        //        new { name = "Rohit Kumar", email = "rohit.kumar**@outlook.com" }};

        //    con.Execute(@"insert Users(UserName, UserEmail) values (@name, @email)", myObj);
        //}

        public async Task<int> Add(User user)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@LoginID", user.LoginID);
                parameters.Add("@Dept", user.DeptCode);
                parameters.Add("@FirstName", user.FirstName);
                parameters.Add("@LastName", user.LastName);
                parameters.Add("@Gender", user.Gender);
                parameters.Add("@DOB", user.DOB);
                parameters.Add("@MaritalStatus", user.MaritalStatus);
                parameters.Add("@Address", user.Address);
                parameters.Add("@City", user.City);
                parameters.Add("@State", user.State);
                parameters.Add("@Country", user.Country);
                parameters.Add("@MobilePhone", user.MobilePhone);
                parameters.Add("@PinCode", user.PinCode);
                parameters.Add("@Email", user.Email);
                parameters.Add("@Password", user.Password);
                parameters.Add("@VerificationCode", user.VerificationCode);
                parameters.Add("@AttemptNumber", user.AttemptNumber);
                parameters.Add("@Identity", user.Identity);
                parameters.Add("@UserType", 0, direction: ParameterDirection.Output);
                parameters.Add("@QuestionId", user.QuestionId);
                parameters.Add("@Question", user.Question);

                var val = await SqlMapper.ExecuteAsync(con, "EgUserRegistration", param: parameters, commandType: StoredProcedure);
                user.UserType = parameters.Get<int>("UserType");
                return val;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Delete(int userId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@UserId", userId);
            var val = await SqlMapper.ExecuteAsync(con, "DeleteUser", param: parameters, commandType: StoredProcedure);
            return val;
        }

        public async Task<IEnumerable<User>> Get()
        {
            var userList = await SqlMapper.QueryAsync<User>(con, "GetAllUsers", commandType: StoredProcedure);
            return userList;
        }
        public async Task<IEnumerable<User>> Get(int id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserId", id);
                var item = await SqlMapper.QueryAsync<User>((SqlConnection)con, "EgGetUserEditDetail", parameters, commandType: StoredProcedure);
                return item;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public Task<IEnumerable<User>> GetItem(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update(User user)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserId", user.UserId);
                parameters.Add("@LoginID", user.LoginID);
                parameters.Add("@Dept", user.DeptCode);
                parameters.Add("@FirstName", user.FirstName);
                parameters.Add("@LastName", user.LastName);
                parameters.Add("@Gender", user.Gender);
                parameters.Add("@DOB", user.DOB);
                parameters.Add("@MaritalStatus", user.MaritalStatus);
                parameters.Add("@Address", user.Address);
                parameters.Add("@City", user.City);
                parameters.Add("@State", user.State);
                parameters.Add("@Country", user.Country);
                parameters.Add("@MobilePhone", user.MobilePhone);
                parameters.Add("@PinCode", user.PinCode);
                parameters.Add("@Email", user.Email);
                parameters.Add("@Password", user.Password);
                parameters.Add("@VerificationCode", user.VerificationCode);
                parameters.Add("@AttemptNumber", user.AttemptNumber);
                parameters.Add("@Identity", user.Identity);
                parameters.Add("@UserType", user.UserType);
                parameters.Add("@QuestionId", user.QuestionId);
                parameters.Add("@Question", user.Question);

                var ret = await SqlMapper.ExecuteAsync(con, "UpdateUser", param: parameters, commandType: StoredProcedure);
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int> GetUserId(string loginid)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@LoginID", loginid);
                //var item = await SqlMapper.QueryAsync<User>((SqlConnection)con, "EgGetLoginUserID", parameters, commandType: StoredProcedure);
                var item = await SqlMapper.ExecuteScalarAsync(con, "EgGetLoginUserID", param: parameters, commandType: StoredProcedure);
                return Convert.ToInt16(item);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Authenticate> Authenticate(Authenticate objAuthenticate)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@LoginId", objAuthenticate.Username);//to
                parameters.Add("@ErrorCode", objAuthenticate.ErrorCode, direction: ParameterDirection.Output);//null
                parameters.Add("@Rnd", objAuthenticate.Rnd);//1158624681
                parameters.Add("@Password", objAuthenticate.Password);//763adab0cb124468adb1a0b1d697e69c
                parameters.Add("@UserID", objAuthenticate.UserID, direction: ParameterDirection.Output);//0
                parameters.Add("@UserType", objAuthenticate.UserType, direction: ParameterDirection.Output);//0
                parameters.Add("@IPAddress", objAuthenticate.IPAddress);//::1
                parameters.Add("@Userflag", objAuthenticate.Userflag, direction: ParameterDirection.Output);//null
                parameters.Add("@SHAPassword", objAuthenticate.SHAPassword);//32fce102dfffda4ef5e764c6f7ab2bc0c2935296f41e9ff9bb92b68aa4fa1846

                //var item = await SqlMapper.QueryAsync<User>((SqlConnection)con, "EgGetUserEditDetail", parameters, commandType: StoredProcedure);

                var user = await SqlMapper.ExecuteScalarAsync<User>(con, "UserLoginInfo", param: parameters, commandType: StoredProcedure);

                objAuthenticate.ErrorCode = parameters.Get<string>("ErrorCode");
                objAuthenticate.UserID = parameters.Get<Int64>("UserID");
                objAuthenticate.UserType = parameters.Get<int>("UserType");
                objAuthenticate.Userflag = parameters.Get<string>("Userflag");
                return objAuthenticate;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
