using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using G4S.SaturnPOP.EncryptDecrypt;
using Saturn.Common.POP;
namespace DL
{
    public class POPSecurityRepository
    {
        private string _ConnectionString = string.Empty;
        private string G4SSATSQL = string.Empty;
        public POPSecurityRepository(string ClientCode)
        {
            _ConnectionString = ConfigurationManager.ConnectionStrings["CY_CONSTRING"].ConnectionString;
            var enService = new G4SEncryptDecrypt(ConfigurationManager.AppSettings["Saltkey"]);
            _ConnectionString = enService.Decrypt(_ConnectionString);
        }
        private static bool ValidateUserObject(SecUser user)
        {
            return !string.IsNullOrEmpty(user.EncryptDecryptSalt) || string.IsNullOrEmpty(user.ClientCode) ||
                   string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Password);
        }
        private static SecUser DecryptUserObject(SecUser secUser)
        {
            var g4sEncryptDecrypt = new G4SEncryptDecrypt(secUser.EncryptDecryptSalt);
            secUser.ClientCode = g4sEncryptDecrypt.Decrypt(secUser.ClientCode);
            secUser.UserName = g4sEncryptDecrypt.Decrypt(secUser.UserName);
            secUser.Password = g4sEncryptDecrypt.Decrypt(secUser.Password);
            return secUser;
        }
        public string ValidateUser(SecUser secUser)
        {
            using (var con = new SqlConnection(_ConnectionString))
            {
                using (var cmd = new SqlCommand("usp_SecUserSelect", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(DL.Properties.Resources.UserName, secUser.UserName);
                    cmd.Parameters.AddWithValue(DL.Properties.Resources.UserPassword , secUser.Password);
                    cmd.Parameters.AddWithValue(DL.Properties.Resources.ClientCode, secUser.ClientCode);
                    con.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            return dr.Read() ? (string)dr["EncryptDecryptSaltKey"] : string.Empty;
                        }
                        
                        dr.Close();
                    }
                }
                return string.Empty;
            }

            
        }
    }
}
