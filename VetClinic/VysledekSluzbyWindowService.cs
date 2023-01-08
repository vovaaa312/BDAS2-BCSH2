using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.Model;
using VetClinic.View;

namespace VetClinic
{
    public class VysledekSluzbyWindowService : IWindowService
    {
        public void CreateWindow()
        {
            if (ListOfWindows.GetVysledekSluzbyWindow() != null)
            {
                return;
            }
            VysledekSluzbyWindow window = new VysledekSluzbyWindow();
            window.Show();
            ListOfWindows.AddWindow(window);
        }

        public void AddVysledek() { 
            
        }

        public void CloseWindow()
        {
            var window = ListOfWindows.GetVysledekSluzbyWindow();

            if (window == null)
            {
                return;
            }
            window.Close();
            ListOfWindows.RemoveWindow(window);
        }

        
    }
}
