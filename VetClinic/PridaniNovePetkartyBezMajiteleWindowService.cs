using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.Model;
using VetClinic.View;

namespace VetClinic
{
    public class PridaniNovePetkartyBezMajiteleWindowService : IWindowService
    {
        
        public void CreateWindow()
        {
            if (ListOfWindows.GetPridaniNovePetkartyBezMajiteleWindow() != null) { 
                return;
            }
            PridaniNovePetkartyBezMajiteleWindow pw = new PridaniNovePetkartyBezMajiteleWindow();
            pw.Show();
            ListOfWindows.AddWindow(pw);
        }

        public void AddPetcardBezMajitele() {
            // TODO add new Paceint card
        }

        public void CloseWindow()
        {
            var window = ListOfWindows.GetPridaniNovePetkartyBezMajiteleWindow();

            if (window == null)
            {
                return;
            }
            window.Close();
            ListOfWindows.RemoveWindow(window);
        }

    }
}
