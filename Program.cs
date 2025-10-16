using System.Diagnostics;

namespace TestandoAtualizaoAutomaticaViaGit
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string appDir = AppDomain.CurrentDomain.BaseDirectory;
            string updaterPath = Path.Combine(appDir, "UpdaterInitialization.exe");

            if (File.Exists(updaterPath))
            {
                var psi = new ProcessStartInfo
                {
                    FileName = updaterPath,
                    Arguments = "--update-only",
                    UseShellExecute = true,
                    WorkingDirectory = appDir
                };

                var updaterProcess = Process.Start(psi);
                updaterProcess?.WaitForExit(); // Espera updater finalizar

                ApplicationConfiguration.Initialize();
                Application.Run(new Form1());
                return;
            }

            // Agora abre o app principal
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}
