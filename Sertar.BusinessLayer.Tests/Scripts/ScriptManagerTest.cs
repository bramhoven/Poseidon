using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Sertar.BusinessLayer.Scripts;
using Sertar.Models.Scripts;

namespace Sertar.BusinessLayer.Tests.Scripts
{
    [TestFixture]
    public class ScriptManagerTest
    {
        /// <summary>
        /// Test the successful import of a Yaml into a ScriptBase object.
        /// </summary>
        [Test]
        public void LoadFromYaml_SuccessfulImport()
        {
            var yaml = @"
            name: Test Script
            steps:
                - name: First step name
                  commands: 
                    - First step command
                - name: Second step name
                  commands:
                    - Second step first command 
                    - Second step second command
            ";
            var script = ScriptManager.LoadFromYaml(yaml);

            Assert.IsNotNull(script, "Script object is null");
            Assert.AreEqual(script.Name, "Test Script");
            Assert.AreEqual(script.Steps.Count, 2);

            Assert.AreEqual(script.Steps[0].Name, "First step name");
            Assert.AreEqual(script.Steps[0].Commands.Count, 1);
            Assert.AreEqual(script.Steps[0].Commands[0], "First step command");

            Assert.AreEqual(script.Steps[1].Name, "Second step name");
            Assert.AreEqual(script.Steps[1].Commands.Count, 2);
            Assert.AreEqual(script.Steps[1].Commands[0], "Second step first command");
            Assert.AreEqual(script.Steps[1].Commands[1], "Second step second command");
        }
    }
}
