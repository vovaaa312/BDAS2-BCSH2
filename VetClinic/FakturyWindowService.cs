using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.View;
using VetClinic.Model;
using VetClinic.ViewModel;

namespace VetClinic
{
    public class FakturyWindowService : IWindowService
    {
        public void CreateWindow()
        {
            if (ListOfWindows.GetFakturyWindow() != null) {
                return;
            }
            FakturyWindow window = new FakturyWindow(); 
            window.Show();
            ListOfWindows.AddWindow(window);
        }

        public void AddFakturu() {
            // TODO FakturaWindow add logic
            var window = ListOfWindows.GetFakturyWindow();

            string jmenoMazlicka = new MainViewModel().SJmenoMazlicka.First().Jmeno;
            string primeniMajitele = new MainViewModel().SJmenoMazlicka.First().PrimeniMajitele;
            DateTime? dateTime = null;
            string konecnaCena = window.konecnaCena.Text;
            string oddeleni = new MainViewModel().SOddeleni;

            if (window.datumVystaveniDatePicker.SelectedDate.HasValue)
            {
                dateTime = window.datumVystaveniDatePicker.SelectedDate.Value;
            }

            bool canAdd = jmenoMazlicka != null && primeniMajitele != null 
                          && dateTime != null && konecnaCena != "" && oddeleni != null;
        }



        public void CloseWindow()
        {
            var window = ListOfWindows.GetFakturyWindow();

            if (window == null)
            {
                return;
            }
            window.Close();
            ListOfWindows.RemoveWindow(window);
        }

        
    }
}
