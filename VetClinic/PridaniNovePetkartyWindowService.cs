using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VetClinic.Model;
using VetClinic.View;

namespace VetClinic
{
    public class PridaniNovePetkartyWindowService : IWindowService
    {

        public void CreateWindow()
        {
            if (ListOfWindows.GetPridaniNovePetkartyWindow() != null) { 
                return;
            }
            PridaniNovePetkartyWindow pw = new PridaniNovePetkartyWindow();
            pw.Show();
            ListOfWindows.AddWindow(pw);
        }

        public void AddPetcard() {
            // TODO add new Paceint card

            var window = ListOfWindows.GetPridaniNovePetkartyWindow();

            string jmeno_mazlicka = window.jmenoMazlickaTextBox.Text;
            string druh_zvire = window.druhZvire.SelectedValue.ToString();
            string jmeno_majitele = window.jmenoMajiteleTextBox.Text;
            string prijmeni_majitele = window.primeniMajiteleTextBox.Text;
            string tel_cislo = window.telCisloTextBox.Text;
            string email = window.emailTextBox.Text;
            string mesto = window.mestoTextBox.Text;
            int cislo_ulice = Int32.Parse(window.cisloUliceTextBox.Text);
            int psc = Int32.Parse(window.pscTextBox.Text);
            string stat = window.statTextBox.Text;
            string nazev_oddeleni = window.nazevOddeleniComboBox.SelectedValue.ToString();
            DateTime ? nastup = null;
            DateTime? propusteni = null;

            if (window.datumNarozeniDatePicker.SelectedDate.HasValue) nastup = window.datumNarozeniDatePicker.SelectedDate.Value;
            if (window.datumPropusteniDatePicker.SelectedDate.HasValue) propusteni = window.datumPropusteniDatePicker.SelectedDate.Value;
        }

        private static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        public void CloseWindow()
        {
            var window = ListOfWindows.GetPridaniNovePetkartyWindow();

            if (window == null)
            {
                return;
            }
            window.Close();
            ListOfWindows.RemoveWindow(window);
        }
    }
}
