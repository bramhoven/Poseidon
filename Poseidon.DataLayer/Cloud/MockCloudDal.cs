using System;
using System.Collections.Generic;
using System.Linq;
using Poseidon.DataLayer.Mappers;
using Poseidon.Models.Cloud;
using Poseidon.Models.Cloud.Ovh;
using Poseidon.Models.Servers;

namespace Poseidon.DataLayer.Cloud
{
    public class MockCloudDal : ICloudDal
    {
        #region Fields

        public static ICollection<Server> MockedServerDatabase = new List<Server>();

        #endregion

        #region Methods

        public Server CreateServer(string name, string size, string image, string region)
        {
            var server = new Server
            {
                CloudId = Guid.NewGuid().ToString(),
                Id = Guid.NewGuid(),
                Name = name
            };

            MockedServerDatabase.Add(server);

            return server;
        }

        public ICollection<InstanceImageBase> GetAvailableImages()
        {
            return new List<InstanceImageBase>()
            {

            };
        }

        public ICollection<InstanceSizeBase> GetAvailableSizes()
        {
            return new List<InstanceSizeBase>()
            {

            };
        }

        public Server GetServer(string serverId)
        {
            var server = MockedServerDatabase.First(s => s.Id.ToString() == serverId);

            return server;
        }

        public Server UpdateServer(Server server)
        {
            var updatedServer = MockedServerDatabase.First(s => s.Id == server.Id);

            if (updatedServer != null)
                updatedServer.Name = server.Name;

            return server;
        }

        #endregion
    }
}