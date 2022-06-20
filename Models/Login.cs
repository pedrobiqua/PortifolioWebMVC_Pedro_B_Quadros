namespace WebMVC.Models
{
    public class Login
    {
        public int Id { get; set; }
        public String? LoginUser { get; set; }
        public String? Password { get; set; }

        public bool ValidPassord(String? password)
        {
            if (password != null)
            {
                return Password == password;
            }
            return false;
        }
    }
}