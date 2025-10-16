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

            // Se existir o Updater, inicia ele e encerra o app atual
            if (File.Exists(updaterPath))
            {
                try
                {
                    var psi = new ProcessStartInfo
                    {
                        FileName = updaterPath,
                        WorkingDirectory = appDir,
                        UseShellExecute = true,
                        Arguments = $"--check-update \"{Process.GetCurrentProcess().ProcessName}.exe\""
                    };

                    Process.Start(psi);
                    return; // encerra o app principal enquanto o updater roda
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Falha ao iniciar o updater: {ex.Message}");
                }
            }

            // Se não tiver updater, apenas abre o app
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}
