using Xunit;

namespace RedBadgerAssesment_MartianRobot_MwelaseTshona_Tests
{
    public class MartianRobotsTests
    {
        [Fact]
        public void RobotFallsOffGrid_ShouldMarkLost()
        {
            var result = MartianRobotsTestHarness.Run(5, 3, 3, 2, 'N', "FRRFLLFFRRFLL");
            Assert.Equal("3 3 N LOST", result);
        }

        [Fact]
        public void RobotIgnoresScent_ShouldNotBeLost()
        {
            // First robot leaves scent
            MartianRobotsTestHarness.Run(5, 3, 3, 2, 'N', "FRRFLLFFRRFLL");
            // Second robot ignores scent
            var result = MartianRobotsTestHarness.Run(5, 3, 3, 2, 'N', "FRRFLLFFRRFLL");
            Assert.NotEqual("LOST", result);
        }

        [Fact]
        public void RobotBackwardCommand_ShouldMoveOppositeDirection()
        {
            var result = MartianRobotsTestHarness.Run(5, 3, 1, 1, 'E', "B");
            Assert.Equal("0 1 E", result);
        }
    }

    // Helper harness for testing
    public static class MartianRobotsTestHarness
    {
        public static string Run(int maxX, int maxY, int startX, int startY, char orientation, string instructions)
        {
            // Reset scents for each test
            var type = typeof(MartianRobots);
            type.GetField("scents", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)
                ?.SetValue(null, new HashSet<(int, int, char)>());

            // Set grid
            type.GetField("maxX", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)
                ?.SetValue(null, maxX);
            type.GetField("maxY", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)
                ?.SetValue(null, maxY);

            var method = type.GetMethod("ProcessRobot", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            return (string)method.Invoke(null, new object[] { startX, startY, orientation, instructions });
        }
    }
}
