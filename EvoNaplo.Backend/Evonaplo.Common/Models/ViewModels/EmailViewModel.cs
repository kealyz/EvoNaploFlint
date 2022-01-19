using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoNaplo.Common.Models.ViewModels
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
