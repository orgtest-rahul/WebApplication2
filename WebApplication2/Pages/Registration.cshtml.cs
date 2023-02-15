using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Runtime.Intrinsics.Arm;
using System.Xml.Linq;

namespace WebApplication2.Pages
{
    public class RegistrationModel : PageModel
    {
        public void OnGet()
        {
            ViewData["Message"] = "New User Registration";
        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Input.Email.Length == 0 || Input.Name == null || Input.Password.Length == 0 || Input.ConfirmPassword.Length == 0)
                {
                    ViewData["ErrorMessage"] = "All the fields are required for Registration";
                }
                else
                {
                    if (Input.Password == Input.ConfirmPassword)
                    {
                        // Save the data in the database
                        // Redirect to the login page

                        try
                        {
                            {
                               // GetUser();


                                //string connectionString = "Data Source=DESKTOP-5F3V7L1;Initial Catalog=WebApplication2;Integrated Security=True";
                                //SqlConnection connection = new SqlConnection(connectionString);
                                //connection.Open();
                                //string query = "insert into Users values ('" + Input.Name + "','" + Input.Email + "','" + Input.Password + "')";
                                //SqlCommand command = new SqlCommand(query, connection);
                                //command.ExecuteNonQuery();
                                //connection.Close();
                                ViewData["Message"] = Input.Password + "Registration Successful";

                            }
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                        finally
                        {


                        }
                      

                        
                     }
                    else
                    {
                        ViewData["ErrorMessage"] = "Password and Confirm Password should match";
                    }
                }

            }

        }
        
        public void  GetUser()
        {
            if (ModelState.IsValid)
            {
                if (Input.Email.Length == 0 || Input.Password.Length == 0)
                {
                    ViewData["ErrorMessage"] = "All the fields are required for Login";
                }
                else
                {
                    // Check the data in the database
                    
                    try
                    {
                        string connectionString = "Data Source=DESKTOP-5F3V7L1;Initial Catalog=WebApplication2;Integrated Security=True";
                        SqlConnection connection = new SqlConnection(connectionString);
                        connection.Open();
                        string query = "select * from Users where Email='" + Input.Email + "' and Password='" + Input.Password + "'";
                        SqlCommand command = new SqlCommand(query, connection);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            ViewData["Message"] = "Login Successful";
                        }
                        else
                        {
                            ViewData["ErrorMessage"] = "Invalid Email or Password";
                        }
                        connection.Close();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }

        //public string EncryptStringAES(string word)
        //{
        //    byte[] encrypted;
        //    byte[] IV;
        //    byte[] Key;
        //    using (Aes aes = Aes.Create())
        //    {
        //        Key = aes.Key;
        //        IV = aes.IV;
        //        ICryptoTransform encryptor = aes.CreateEncryptor(Key, IV);
        //        using (MemoryStream msEncrypt = new MemoryStream())
        //        {
        //            using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
        //            {
        //                using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
        //                {
        //                    swEncrypt.Write(word);
        //                }
        //                encrypted = msEncrypt.ToArray();
        //            }
        //        }
        //    }
        //    return Convert.ToBase64String(encrypted);
        //}

        // Encrypt the word



        public string Encryptedword(string word)
        {
            string encryptedword = "";
            for (int i = 0; i < word.Length; i++)
            {
                encryptedword += (char)(word[i] + 1);
            }
            return encryptedword;

            //string encryptedword = "";
            //for (int i = 0; i < word.Length; i++)
            //{
            //    if (word[i] == 'a' || word[i] == 'A')
            //    {
            //        encryptedword += "1";
            //    }
            //    else if (word[i] == 'e' || word[i] == 'E')
            //    {
            //        encryptedword += "2";
            //    }
            //    else if (word[i] == 'i' || word[i] == 'I')
            //    {
            //        encryptedword += "3";
            //    }
            //    else if (word[i] == 'o' || word[i] == 'O')
            //    {
            //        encryptedword += "4";
            //    }
            //    else if (word[i] == 'u' || word[i] == 'U')
            //    {
            //        encryptedword += "5";
            //    }
            //    else
            //    {
            //        encryptedword += word[i];
            //    }
            //}
            //return encryptedword;
        }

        [BindProperty]
        public InputModel? Input { get; set; }

        public class InputModel
        {
            public string? Name { get; set; }

            [Required]
            [EmailAddress]
            public string? Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string? Password { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string? ConfirmPassword { get; set; }

            [Required]
            public string? WordToResetPassword { get; set; }

        }

   


    }
}
