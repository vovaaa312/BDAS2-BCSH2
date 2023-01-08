using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.View;
using VetClinic.Model;

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
