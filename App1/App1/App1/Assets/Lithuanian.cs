using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Assets
{
    public class Lithuanian : Language
    {
        public override string LoginString { get => "Prisijungti"; set => throw new NotImplementedException(); }
        public override string DontHaveAccountRegisterString { get => "Neturite paskyros? Registruokites"; set => throw new NotImplementedException(); }
        public override string Atleast3CharsString { get => "Bent 3 simboliai"; set => throw new NotImplementedException(); }
        public override string FirstNameString { get => "Jusu vardas"; set => throw new NotImplementedException(); }
        public override string UsernameString { get => "Paskyros vardas"; set => throw new NotImplementedException(); }
        public override string EmailString { get => "e-pašto adresas"; set => throw new NotImplementedException(); }
        public override string EnterEmailString { get => "Įveskite savo e-pašto adresą"; set => throw new NotImplementedException(); }
        public override string PasswordString { get => "Slaptažodis"; set => throw new NotImplementedException(); }
        public override string PasswordConfirmString { get => "Slaptažodzio patvirtinimas"; set => throw new NotImplementedException(); }
        public override string Registerstring { get => "Registruotis"; set => throw new NotImplementedException(); }
        public override string RegisterErrorString { get => "Registracija nepavyko, patikrinkite savo įvestus duomenis"; set => throw new NotImplementedException(); }
        public override string CompetitionsString { get => "Varžybos"; set => throw new NotImplementedException(); }
        public override string NewCompetitionString { get => "Naujos varžybos"; set => throw new NotImplementedException(); }
        public override string SettingsString { get => "Nustatymai"; set => throw new NotImplementedException(); }
        public override string ProfileString { get => "Paskyra"; set => throw new NotImplementedException(); }
        public override string ConfirmString { get => "Patvirtinti"; set => throw new NotImplementedException(); }
    }
}
