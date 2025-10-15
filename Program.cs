using System.Diagnostics;

namespace TestandoAtualizaoAutomaticaViaGit
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                string appDir = AppContext.BaseDirectory;
                string updaterPath = Path.Combine(appDir, "UpdaterInitialization.exe");

                if (File.Exists(updaterPath))
                {
                    // Verifica se j� n�o tem outro updater rodando
                    bool isUpdaterRunning = Process.GetProcessesByName(
                        Path.GetFileNameWithoutExtension(updaterPath)
                    ).Any();

                    if (!isUpdaterRunning)
                    {
                        Console.WriteLine("[App] Iniciando Updater...");
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = updaterPath,
                            WorkingDirectory = appDir,
                            UseShellExecute = true
                        });
                    }
                    else
                    {
                        Console.WriteLine("[App] Updater j� est� em execu��o.");
                    }
                }
                else
                {
                    Console.WriteLine("[App] Updater n�o encontrado!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[App] Falha ao iniciar o Updater: {ex.Message}");
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}