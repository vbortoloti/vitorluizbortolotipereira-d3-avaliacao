using login_system.Interfaces;
using login_system.Models;
using System.Data.SqlClient;

namespace login_system.Repositories
{
    internal class UserRepository : IUser
    {
        private readonly string stringConexao = "Server=labsoft.pcs.usp.br; Initial Catalog=db_27; User id=usuario_27; pwd=41183548885;";
        public LogRepository log = new LogRepository();
        public User GetUser(string email, string password)
        {
            User user;


            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                con.Open();

                SqlDataReader rdr;

                string querySelect = "SELECT * FROM Users WHERE Email=@Email;";

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);


                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        user = new()
                        {
                            Id = rdr[0].ToString(),
                            Name = rdr[1].ToString(),
                            Email = rdr[2].ToString(),
                            Password = rdr[3].ToString(),
                        };
                    }
                    else
                    {
                        throw new Exception("\nEmail incorreto");
                    }

                    if (user.Password != password)
                    {
                        throw new Exception("\nSenha incorreta");
                    }


                }
            }

            log.RegisterAccess(user, "logou");

            return user;
        }
    }


        
}
