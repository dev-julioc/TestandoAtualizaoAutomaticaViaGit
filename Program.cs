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
            ApplicationConfiguration.Initialize();

            if (!args.Contains("--no-updater"))
            {
                string appDir = AppDomain.CurrentDomain.BaseDirectory;
                string updaterPath = Path.Combine(appDir, "UpdaterInitialization.exe");

                if (File.Exists(updaterPath))
                {
                    try
                    {
                        var psi = new ProcessStartInfo
                        {
                            FileName = updaterPath,
                            Arguments = "",
                            UseShellExecute = true,
                            WorkingDirectory = appDir
                        };
                        Process.Start(psi);
                        return;
                    }
                    catch { }
                }
            }

            // Abre o app principal
            Application.Run(new Form1());
        }
    }
}
