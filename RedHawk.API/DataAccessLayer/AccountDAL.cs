using System;
using System.Collections.Generic;
using RedHawk.Model.AccountModel;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace RedHawk.Service.DataAccessLayer
{
    public class AccountDAL
    {
        static readonly string sqlConnectionString =
            ConfigurationManager.AppSettings["SQLServer"];

        public IEnumerable<User> GetAllUsers()
        {
            try
            {
                List<User> userslst = new List<User>();
                using (SqlConnection sqlConnection = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("assp_GetUsersTableDetails", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        User user = new User
                        {
                            UserId = Convert.ToInt32(sqlDataReader["usertable_id"]),
                            Firstname = sqlDataReader["first_name"].ToString(),
                            Middlename = sqlDataReader["middle_name"].ToString(),
                            Lastname = sqlDataReader["last_name"].ToString(),
                            Email = sqlDataReader["email"].ToString(),
                            Username = sqlDataReader["user_name"].ToString(),
                            Password = sqlDataReader["password"].ToString()
                        };

                        userslst.Add(user);
                    }
                    sqlConnection.Close();
                }
                return userslst;
            }
            catch
            {
                throw;
            }
        }
        public IEnumerable<LoginModel> ValidateUser(LoginModel login)
        {
            List<LoginModel> loginList = new List<LoginModel>();

            try
            {
                using (SqlConnection con = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("assp_UserCredentailsVerification", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.AddWithValue("@username", login.UserName);
                    cmd.Parameters.AddWithValue("@password", login.Password);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        LoginModel loginObj = new LoginModel
                        {
                            UserName = rdr["user_name"].ToString(),
                            Password = rdr["password"].ToString(),
                            RememberMe = false
                        };

                        loginList.Add(loginObj);
                    }
                    con.Close();
                }
            }
            catch
            {
                throw;
            }
            return loginList;
        }
        public int AddUser(User user)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("assp_AddUsers", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.AddWithValue("@Firstname", user.Firstname);
                    cmd.Parameters.AddWithValue("@Middlename", user.Middlename);
                    cmd.Parameters.AddWithValue("@Lastname", user.Lastname);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@Password", user.Password);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }

        public int UpdateUser(User user)
        {
            int result = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("assp_UpdateUsers", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.AddWithValue("@UserTable_Id", user.UserId);
                    cmd.Parameters.AddWithValue("@Firstname", user.Firstname);
                    cmd.Parameters.AddWithValue("@Middlename", user.Middlename);
                    cmd.Parameters.AddWithValue("@Lastname", user.Lastname);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@Password", user.Password);

                    con.Open();
                    result = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch
            {
                throw;
            }
            return result;

        }

        public User GetUserData(int id)
        {
            try
            {
                User user = new User();

                using (SqlConnection con = new SqlConnection(sqlConnectionString))
                {
                    string sqlQuery = "SELECT * FROM UsersTable WHERE usertable_id= " + id;
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        user.UserId = Convert.ToInt32(rdr["usertable_id"]);
                        user.Firstname = rdr["first_name"].ToString();
                        user.Middlename = rdr["middle_name"].ToString();
                        user.Lastname = rdr["last_name"].ToString();
                        user.Email = rdr["email"].ToString();
                        user.Username = rdr["user_name"].ToString();
                        user.Password = rdr["password"].ToString();

                    }
                }
                return user;
            }
            catch
            {
                throw;
            }
        }

        public int DeleteUser(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("assp_DeleteUsers", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.AddWithValue("@UserTable_Id", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }

    }
}