using System;
using System.Collections.Generic;
using System.Linq;
using FaunaDB.Client;
using FaunaDB.Types;
using Poseidon.Helpers.Settings;
using Poseidon.Models.HealthChecks;
using static FaunaDB.Query.Language;

namespace Poseidon.DataLayer.HealthChecks
{
    public class FaunaHealthCheckDal : IHealthCheckDal
    {
        #region Fields

        private static readonly string Endpoint = SettingsHelper.FaunaDbEndpoint;
        private static readonly string Secret = SettingsHelper.FaunaDbKey;
        private readonly FaunaClient _client;

        #endregion

        #region Constructors

        public FaunaHealthCheckDal()
        {
            _client = new FaunaClient(endpoint: Endpoint, secret: Secret);
        }

        #endregion

        #region Methods

        public bool AddHealthCheck(HealthCheck healthCheck)
        {
            throw new NotImplementedException();
        }

        public ICollection<HealthCheck> GetHealthChecks()
        {
            var faunaResult = _client.Query(
                Map(
                    Paginate(Match("AllHealthChecks")),
                    Lambda("healthcheckRef",
                        Let(
                                "healthcheck",
                                Get(Var("healthcheckRef"))
                            )
                            .In(
                                Obj(
                                    "id", Select(Path("ref", "id"), Var("healthcheck")),
                                    "serverId", Select(Path("data", "serverId"), Var("healthcheck")),
                                    "responseTime", Select(Path("data", "responseTime"), Var("healthcheck")),
                                    "dataItems", Map(
                                        Paginate(Match(Index("HealthCheckDataItems"), Var("healthcheckRef"))),
                                        Lambda("dataItemRef",
                                            Let(
                                                    "dataItem",
                                                    Get(Var("dataItemRef"))
                                                )
                                                .In(
                                                    Obj(
                                                        "name", Select(Path("data", "name"), Var("dataItem")),
                                                        "data", Select(Path("data", "data"), Var("dataItem"))
                                                    )
                                                )
                                        )
                                    )
                                )
                            )
                    )
                )
            ).Result;

            var faunaValues = faunaResult.At("data").To<Value[]>().Value;
            var healthChecks = new List<HealthCheck>();
            foreach (var value in faunaValues)
            {
                var healthCheck = value.To<HealthCheck>().Value;
                var dataItems = value.At("dataItems").At("data").To<HealthCheckDataItem[]>().Value;
                healthCheck.HealthCheckDataItems = dataItems.ToList();
                healthChecks.Add(healthCheck);
            }

            return healthChecks.ToList();
        }

        #endregion
    }
}