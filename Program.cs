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
                    // Verifica se já não tem outro updater rodando
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
                        Console.WriteLine("[App] Updater já está em execução.");
                    }
                }
                else
                {
                    Console.WriteLine("[App] Updater não encontrado!");
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