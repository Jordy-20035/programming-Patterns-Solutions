using Patterns.Ex00.ExternalLibs;

namespace Patterns.Ex00
{
    public class FtpLogReader : ILogReader
    {
        private readonly FtpClient _ftpClient;
        private readonly IFtpCredentialsProvider _credentialsProvider;

        public FtpLogReader(FtpClient ftpClient, IFtpCredentialsProvider credentialsProvider)
        {
            _ftpClient = ftpClient;
            _credentialsProvider = credentialsProvider;
        }

        public string ReadLogFile(string ftpPath)
        {
            // Удаляем префикс ftp:// из пути
            var path = ftpPath.Replace("ftp://", "");
            return _ftpClient.ReadFile(
                _credentialsProvider.GetLogin(),
                _credentialsProvider.GetPassword(),
                path
            );
        }
    }
}
