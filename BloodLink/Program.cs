using BloodLink.Core.Models;
using BloodLink.Forms;
using BloodLink.Core.Database;
using BloodLink.Core.Interfaces;
using BloodLink.Core.Models;
namespace BloodLink
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());
        }
    }
}