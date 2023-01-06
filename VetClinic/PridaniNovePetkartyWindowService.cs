using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
