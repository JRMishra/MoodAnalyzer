using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzerProgram;
using System.Runtime.Serialization;

namespace MoodAnalyzerTesting
{
    [TestClass]
    public class TestMoodAnalyser
    {
        [TestMethod]
        public void AnalyzeSadMood()
        {
            //Arrange
            string msg = "I am in Sad Mood";
            MoodAnalyser moodAnalyser = new MoodAnalyser(msg);
            string expectedMood = "SAD";

            //Act
            string actualMood = moodAnalyser.AnalyseMood();

            //Assert
            Assert.AreEqual(expectedMood, actualMood);
        }

        [TestMethod]
        public void AnalyzeHappyMood()
        {
            //Arrange
            string msg = "I am in Any Mood";
            MoodAnalyser moodAnalyser = new MoodAnalyser(msg);
            string expectedMood = "HAPPY";

            //Act
            string actualMood = moodAnalyser.AnalyseMood();

            //Assert
            Assert.AreEqual(expectedMood, actualMood);
        }

        [TestMethod]
        public void AnalyzeNullExceptionHandling()
        {
            //Arrange
            string msg = null;
            MoodAnalyser moodAnalyser = new MoodAnalyser(msg);

            //Act => Assert
            Assert.ThrowsException<MoodAnalyserException>(() => moodAnalyser.AnalyseMood());
        }

        [TestMethod]
        public void AnalyzeNullExceptionMessage()
        {
            //Arrange
            string msg = null;
            MoodAnalyser moodAnalyser = new MoodAnalyser(msg);
            string expectedMsg = "Mood should not be null";
            string actualMsg = "";

            //Act
            try
            {
                actualMsg = moodAnalyser.AnalyseMood();
            }
            catch (MoodAnalyserException exception)
            {
                actualMsg = exception.Message;
            }

            //Assert
            Assert.AreEqual(expectedMsg, actualMsg);
        }

        [TestMethod]
        public void AnalyzeEmptyExceptionHandling()
        {
            //Arrange
            string msg = "";
            MoodAnalyser moodAnalyser = new MoodAnalyser(msg);

            //Act => Assert
            Assert.ThrowsException<MoodAnalyserException>(() => moodAnalyser.AnalyseMood());
        }

        [TestMethod]
        public void AnalyzeEmptyExceptionMessage()
        {
            //Arrange
            string msg = "";
            MoodAnalyser moodAnalyser = new MoodAnalyser(msg);
            string expectedMsg = "Mood should not be empty";
            string actualMsg = "";

            //Act
            try
            {
                actualMsg = moodAnalyser.AnalyseMood();
            }
            catch (MoodAnalyserException exception)
            {
                actualMsg = exception.Message;
            }

            //Assert
            Assert.AreEqual(expectedMsg, actualMsg);
        }

        [TestMethod]
        public void MoodAnalysisBuilder_ShouldReturnMoodAnalysisObject()
        {
            //Arrange
            string className = "MoodAnalyser";
            string constructorName = className;
            object expectedInstance = new MoodAnalyser();

            //Add
            object actualInstance = MoodAnalysisBuilder.BuildMoodAnalysis(className,constructorName);

            //Assert
            expectedInstance.Equals(actualInstance);
        }

        
    }
}
