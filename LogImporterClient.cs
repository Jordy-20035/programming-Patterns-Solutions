namespace Patterns.Ex00
{
    public class LogImporterClient : IFtpCredentialsProvider
    {
        public void DoMethod()
        {
            var source = "ftp://log.txt";

            var importer = new LogImporter(
                CreateLogReader(source)
            );

            importer.ImportLogs(source);
        }

        private ILogReader CreateLogReader(string source)
        {
            if (source.StartsWith("ftp://"))
            {
                return new FtpLogReader(
                    new ExternalLibs.FtpClient(),
                    this // передаем текущий объект как провайдер учетных данных
                );
            }
            else
            {
                return new FileLogReader();
            }
        }

        // Реализация интерфейса IFtpCredentialsProvider
        public string GetLogin() => "user";      
        public string GetPassword() => "pass";   // Или получать их из конфигурации
    }
}
