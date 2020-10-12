using Sertar.Models.Scripts;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Sertar.BusinessLayer.Scripts
{
    public class ScriptManager
    {
        #region Methods

        #region Static Methods

        /// <summary>
        ///     Load ScriptBase class from YAML configuration.
        /// </summary>
        /// <param name="yaml">The yaml configuration as a string</param>
        public static ScriptBase LoadFromYaml(string yaml)
        {
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();
            var scriptBase = deserializer.Deserialize<ScriptBase>(yaml);
            return scriptBase;
        }

        #endregion

        #endregion
    }
}