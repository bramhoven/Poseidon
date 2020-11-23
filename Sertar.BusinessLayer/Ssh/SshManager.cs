using System;
using System.IO;
using System.Text;
using Renci.SshNet;
using Sertar.BusinessLayer.Ssh.Providers;
using Sertar.Exceptions;
using Sertar.Models.Servers;
using Sertar.Models.Ssh;

namespace Sertar.BusinessLayer.Ssh
{
    public class SshManager : IDisposable
    {
        #region Fields

        /// <summary>
        ///     The ssh key provider.
        /// </summary>
        private readonly ISshKeyProvider _sshKeyProvider;

        /// <summary>
        ///     The ssh client.
        /// </summary>
        private SshClient _client;

        #endregion

        #region Constructors

        /// <summary>
        ///     Intializes a new instance of <see cref="SshManager" />
        /// </summary>
        /// <param name="sshKeyProvider"></param>
        public SshManager(ISshKeyProvider sshKeyProvider)
        {
            _sshKeyProvider = sshKeyProvider;
        }

        #endregion

        #region Methods

        public void Dispose()
        {
            _client.Disconnect();
            _client.Dispose();
        }

        /// <summary>
        ///     Connect the manager to a server.
        /// </summary>
        /// <param name="server">The server to connect to.</param>
        /// <param name="sshKey">The ssh key to authenticate with</param>
        public void Connect(Server server, SshKey sshKey)
        {
            var stream = new MemoryStream(Encoding.ASCII.GetBytes(sshKey.PrivateKey));
            var authenticationMethod = new PrivateKeyAuthenticationMethod(server.RootUser, new PrivateKeyFile(stream));
            var connectionInfo = new ConnectionInfo(server.MainIpAddress, server.RootUser, authenticationMethod);

            _client = new SshClient(connectionInfo);
        }


        /// <summary>
        ///     Executes a command on the ssh server.
        /// </summary>
        /// <param name="command">The command to execute</param>
        /// <returns></returns>
        public string ExecuteCommand(string command)
        {
            if (!_client.IsConnected)
                throw new NotConnectedException();

            var result = _client.RunCommand(command);
            return result.Result;
        }

        #endregion
    }
}