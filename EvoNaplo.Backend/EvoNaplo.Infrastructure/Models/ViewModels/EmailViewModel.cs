namespace EvoNaplo.Infrastructure.Models.ViewModels
{
    public class EmailViewModel
    {
        public string Email { get; set; }
        public bool Exists { get; set; }

        public EmailViewModel()
        {

        }

        public EmailViewModel(string email, bool exists)
        {
            Email = email;
            Exists = exists;
        }
    }
}