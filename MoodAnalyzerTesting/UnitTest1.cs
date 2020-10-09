using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzerProgram;

namespace MoodAnalyzerTesting
{
    [TestClass]
    public class TestMoodAnalyser
    {
        [TestMethod]
        public void AnalyzeMood1a()
        {
            //Arrange
            MoodAnalyser moodAnalyser = new MoodAnalyser();
            string msg = "I am in Sad Mood";
            string expectedMood = "SAD";

            //Act
            string actualMood = moodAnalyser.AnalyseMood(msg);

            //Assert
            Assert.AreEqual(expectedMood, actualMood);
        }
    }
}
