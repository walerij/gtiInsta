using System.ComponentModel.DataAnnotations;

namespace gitInsta.Models
{
    public class loginpass
    {
        [Required(ErrorMessage = "Введите логин")]
        public string login { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        public string password { get; set; }


        /*Data Source=DESKTOP-3ITI3JI\SQLEXPRESS;
          Initial Catalog=GitInsta;
          Integrated Security=True;
          Connect Timeout=15;
          Encrypt=False;
          TrustServerCertificate=False;
           ApplicationIntent=ReadWrite;
         MultiSubnetFailover=False
        */
        public loginpass()
        {
           
            login = "";
            password = "";
        }

    }
}