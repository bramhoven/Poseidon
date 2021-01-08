using System;
using System.Collections.Generic;
using System.Linq;
using Poseidon.Models.Cloud;
using Poseidon.Models.Security;
using Poseidon.Models.Servers;

namespace Poseidon.DataLayer.Cloud
{
    public class MockCloudDal : ICloudDal
    {
        #region Fields

        private static CloudProviderType _cloudProviderType;
        private static CloudProvider _cloudProvider;

        public static ICollection<Server> MockedServerDatabase = new List<Server>();

        #endregion

        #region Constructors

        public MockCloudDal(CloudProviderType cloudProviderType)
        {
            _cloudProviderType = cloudProviderType;
        }

        #endregion

        #region Methods

        public void ConfigureProvider(ICloudProviderDal cloudProviderDal)
        {
            _cloudProvider = cloudProviderDal.GetCloudProviderByType(_cloudProviderType);
        }

        public Server CreateServer(string name, string size, string image, string region, string sshKeyId)
        {
            var server = new Server
            {
                CloudId = Guid.NewGuid().ToString(),
                Id = Guid.NewGuid(),
                Name = name,
                CloudProvider = _cloudProvider
            };

            MockedServerDatabase.Add(server);

            return server;
        }

        public bool DeleteServer(string cloudId)
        {
            var server = MockedServerDatabase.FirstOrDefault(s => s.CloudId == cloudId);
            if (server != null)
                MockedServerDatabase.Remove(server);

            return true;
        }

        public ICollection<InstanceImageBase> GetAvailableImages()
        {
            return new List<InstanceImageBase>
            {
                new MockInstanceImage
                {
                    Id = "1",
                    Name = "Image 1",
                    Slug = "image-1",
                    Description = "Image 1",
                    Os = "Test OS",
                    Regions = new List<string>
                    {
                        "AMS",
                        "LON"
                    }
                },
                new MockInstanceImage
                {
                    Id = "2",
                    Name = "Image 2",
                    Slug = "image-2",
                    Description = "Image 2",
                    Os = "Test OS",
                    Regions = new List<string>
                    {
                        "NYC",
                        "SGP"
                    }
                },
                new MockInstanceImage
                {
                    Id = "3",
                    Name = "Image 3",
                    Slug = "image-3",
                    Description = "Image 3",
                    Os = "Test OS",
                    Regions = new List<string>
                    {
                        "AMS",
                        "LON",
                        "NYC",
                        "SGP",
                        "GRA"
                    }
                }
            };
        }

        public ICollection<InstanceSizeBase> GetAvailableSizes()
        {
            return new List<InstanceSizeBase>
            {
                new MockInstanceSize
                {
                    Id = "1",
                    Name = "Size 1",
                    Slug = "size-1",
                    Cpu = 1,
                    Gpu = 0,
                    Ram = 1,
                    Regions = new List<string>
                    {
                        "AMS",
                        "LON",
                        "NYC",
                        "SGP",
                        "GRA"
                    },
                    Storage = 20,
                    Transfer = 1
                },
                new MockInstanceSize
                {
                    Id = "2",
                    Name = "Size 2",
                    Slug = "size-2",
                    Cpu = 2,
                    Gpu = 0,
                    Ram = 4,
                    Regions = new List<string>
                    {
                        "AMS",
                        "LON",
                        "NYC",
                        "SGP",
                        "GRA"
                    },
                    Storage = 40,
                    Transfer = 2
                },
                new MockInstanceSize
                {
                    Id = "3",
                    Name = "Size 3",
                    Slug = "size-3",
                    Cpu = 4,
                    Gpu = 0,
                    Ram = 12,
                    Regions = new List<string>
                    {
                        "AMS",
                        "LON",
                        "NYC",
                        "SGP",
                        "GRA"
                    },
                    Storage = 100,
                    Transfer = 5
                }
            };
        }

        public ICollection<Region> getRegions()
        {
            return new List<Region>
            {
                new Region("AMS"),
                new Region("LON"),
                new Region("NYC"),
                new Region("SGP"),
                new Region("GRA")
            };
        }

        public Server GetServer(string cloudId)
        {
            var server = MockedServerDatabase.FirstOrDefault(s => s.Id.ToString() == cloudId);
            return server;
        }

        public ICollection<PublicSshKey> GetSshKeys()
        {
            return new List<PublicSshKey>
            {
                new PublicSshKey
                {
                    Id = "1",
                    Name = "Test key #1",
                    PublicKey = "ssh-rsa test-key-01",
                    Fingerprint = ""
                },
                new PublicSshKey
                {
                    Id = "2",
                    Name = "Test key #2",
                    PublicKey = "ssh-rsa test-key-02",
                    Fingerprint = ""
                }
            };
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