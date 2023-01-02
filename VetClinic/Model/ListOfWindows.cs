using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VetClinic.View;

namespace VetClinic.Model
{
    public static class ListOfWindows
    {
        static ObservableCollection<Window> windows = new ObservableCollection<Window>();

        public static void AddWindow(Window window) {
            windows.Add(window);
        }

        public static void RemoveWindow(Window window)
        {
            windows.Remove(window);
        }

        public static Boolean ContainsWindow(Window window) {
            return windows.Contains(window);
        }

        public static ObservableCollection<Window> GetWindows()
        {
            return windows;
        }

        public static RegistrationWindow getRegWindow() {
            RegistrationWindow iw = null;
            foreach (Window window in windows) {
                if (window.GetType() == new RegistrationWindow().GetType()) {
                    iw = (RegistrationWindow)window;
                }
            }
            return iw;
        }
    }
}
