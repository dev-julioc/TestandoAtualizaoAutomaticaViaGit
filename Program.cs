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

            // Se N�O recebeu --no-updater, chama o updater
            if (!args.Contains("--no-updater"))
            {
                string appDir = AppDomain.CurrentDomain.BaseDirectory;
                string updaterPath = Path.Combine(appDir, "UpdaterUI.exe");

                if (File.Exists(updaterPath))
                {
                    try
                    {
                        var psi = new ProcessStartInfo
                        {
                            FileName = updaterPath,
                            Arguments = "--update-only", // sinaliza que veio do app principal
                            UseShellExecute = true,
                            WorkingDirectory = appDir
                        };
                        Process.Start(psi); // dispara o updater e N�O espera
                    }
                    catch { }
                }
            }

            // Abre o app principal
            Application.Run(new Form1());
        }
    }
}
