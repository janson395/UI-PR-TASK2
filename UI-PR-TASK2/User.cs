using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UI_PR_TASK2
{
    public class User : INotifyPropertyChanged
    {

        #region PropertyChangedEventHandler
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanget([CallerMemberName] string? name = null)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
        #region Private fields
        private string _name;
        private string _lastname;
        private string _email;
        private string _github;
        #endregion
        #region Public property
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanget("Name");
            }
        }

        public string LastName
        {
            get { return _lastname; }
            set
            {
                _lastname = value;
                OnPropertyChanget("LastName");
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanget("Email");
            }
        }
        public string Github
        {
            get { return _github; }
            set
            {
                _github = value;
                OnPropertyChanget("Github");
            }
        }

        #endregion

        public User(string name, string email, string github)
        {
            _name = name;
            _email = email;
            _github = github;
        }

        public override int GetHashCode()
        {
            return (_name + _email + _github + _lastname).GetHashCode();
        }
    }
}
