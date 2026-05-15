using BloodLink.Database;
using BloodLink.Forms;

namespace BloodLink
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            try
            {
                DatabaseHelper.Initialize();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Startup error:\n\n{ex.Message}\n\n{ex.StackTrace}", "Error");
                return;
            }

            Application.Run(new LoginForm());
        }
    }
}