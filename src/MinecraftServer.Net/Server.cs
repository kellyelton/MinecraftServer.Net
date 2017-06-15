using System;
using System.Threading.Tasks;

namespace MinecraftServer
{
    public class Server : IDisposable {
        private readonly IServerProcessWrapper _serverWrapper;

        public Server(IServerProcessWrapper serverWrapper) {
            _serverWrapper = serverWrapper;
        }

        public void Dispose() {
            _serverWrapper?.Dispose();
        }

        public Task Start() {
            return _serverWrapper.Launch();
        }

        public Task Stop() {
            return _serverWrapper.Shutdown();
        }
    }

    public interface IServerProcessWrapper : IDisposable {
        event EventHandler<RawInputEventArgs> RawInput;

        Task Launch();
        Task Shutdown();
        Task Kill();
        void Write(string rawMessage);
    }

    public class RawInputEventArgs : EventArgs
    {
        public string Message { get; set; }
    }
}
