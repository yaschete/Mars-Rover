using System.Reflection;
using System.Text;
using Autofac;
using Nasa.MarsRover.Command.Abstract.Core;
using Nasa.MarsRover.Exception.Rover;
using NUnit.Framework;

namespace Nasa.MarsRover.Test
{
    [TestFixture]
    public class AcceptanceTests
    {

        private IContainer _container;

        [SetUp]
        public void TestFixtureSetUp()
        {
            var targetAssembly = Assembly.GetAssembly(typeof(ICommandFactory));

            var builder = new ContainerBuilder();
            builder
                .RegisterAssemblyTypes(targetAssembly)
                .AsImplementedInterfaces();

            _container = builder.Build();
        }


        [Test]
        public void RoverCreateAndDrive()
        {
            var input = GetInputCommandString();
            var outPut = GetExpectedReportString();
            var commandFactory = _container.Resolve<ICommandFactory>();
            commandFactory.Execute(input);
            var actualOutput = commandFactory.GetCombinedRoverReport();

            Assert.AreEqual(outPut, actualOutput);
        }

        [Test]
        public void RoverOutOfPlateau()
        {
            var input = GetInputCommandStringForOutOfPlateau();
            var commandFactory = _container.Resolve<ICommandFactory>();
            Assert.Throws<RoverOutOfPlateuException>(() => commandFactory.Execute(input));
        }





        #region Private Methods
        private static string GetInputCommandString()
        {
            var commandStringBuilder = new StringBuilder();
            commandStringBuilder.AppendLine("5 5");
            commandStringBuilder.AppendLine("1 2 N");
            commandStringBuilder.AppendLine("LMLMLMLMM");
            commandStringBuilder.AppendLine("3 3 E");
            commandStringBuilder.Append("MMRMMRMRRM");
            return commandStringBuilder.ToString();
        }

        private static string GetInputCommandStringForOutOfPlateau()
        {
            var commandStringBuilder = new StringBuilder();
            commandStringBuilder.AppendLine("5 5");
            commandStringBuilder.AppendLine("1 2 N");
            commandStringBuilder.AppendLine("LMMMMMMMMMMM");
            commandStringBuilder.AppendLine("1 3 N");
            commandStringBuilder.Append("LMRMMMMMMMMMMMMMMM");
            return commandStringBuilder.ToString();
        }
        private static string GetExpectedReportString()
        {
            var commandStringBuilder = new StringBuilder();
            commandStringBuilder.AppendLine("1 3 N");
            commandStringBuilder.Append("5 1 E");
            return commandStringBuilder.ToString();
        }

        private static string GetExpectedReportStringForCrashScenario()
        {
            var commandStringBuilder = new StringBuilder();
            commandStringBuilder.AppendLine("1 3 N");
            commandStringBuilder.Append("5 1 E");
            return commandStringBuilder.ToString();
        }
        #endregion
    }
}
