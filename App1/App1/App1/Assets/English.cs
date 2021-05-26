using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Assets
{
    public class English : Language
    {
        public override string LoginString { get => "Login"; set => throw new NotImplementedException(); }
        public override string DontHaveAccountRegisterString { get => "DON'T HAVE AN ACCOUNT? REGISTER"; set => throw new NotImplementedException(); }
        public override string Atleast3CharsString { get => "Atleast 3 characters"; set => throw new NotImplementedException(); }
        public override string FirstNameString { get => "First name"; set => throw new NotImplementedException(); }
        public override string UsernameString { get => "User name"; set => throw new NotImplementedException(); }
        public override string EmailString { get => "E-mail address"; set => throw new NotImplementedException(); }
        public override string EnterEmailString { get => "Enter e-mail address"; set => throw new NotImplementedException(); }
        public override string PasswordString { get => "Password"; set => throw new NotImplementedException(); }
        public override string PasswordConfirmString { get => "Password confirmation"; set => throw new NotImplementedException(); }
        public override string Registerstring { get => "Register"; set => throw new NotImplementedException(); }
        public override string RegisterErrorString { get => "Something went wrong, make sure your inputs meet the criteria"; set => throw new NotImplementedException(); }
        public override string CompetitionsString { get => "Competitions"; set => throw new NotImplementedException(); }
        public override string NewCompetitionString { get => "New competition"; set => throw new NotImplementedException(); }
        public override string SettingsString { get => "Settings"; set => throw new NotImplementedException(); }
        public override string ProfileString { get => "Profile"; set => throw new NotImplementedException(); }
        public override string ConfirmString { get => "Confirm"; set => throw new NotImplementedException(); }
    }
}
