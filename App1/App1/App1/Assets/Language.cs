using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Assets
{
    public abstract class Language
    {
        public abstract string LoginString { get; set; }
        public abstract string RegisterErrorString { get; set; }
        public abstract string DontHaveAccountRegisterString { get; set; }
        public abstract string Atleast3CharsString { get; set; }
        public abstract string FirstNameString { get; set; }
        public abstract string UsernameString { get; set; }
        public abstract string EmailString { get; set; }
        public abstract string EnterEmailString { get; set; }
        public abstract string PasswordString { get; set; }
        public abstract string PasswordConfirmString { get; set; }
        public abstract string Registerstring { get; set; }
        public abstract string CompetitionsString { get; set; }
        public abstract string NewCompetitionString { get; set; }
        public abstract string SettingsString { get; set; }
        public abstract string ProfileString { get; set; }
        public abstract string ConfirmString { get; set; }

        
    }
}
