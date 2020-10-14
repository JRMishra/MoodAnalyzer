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
            object actualInstance = MoodAnalysisReflecter.BuildMoodAnalysis(className, constructorName);

            //Assert
            expectedInstance.Equals(actualInstance);
        }

        [TestMethod]
        public void TestMoodAnalysisBuilder_WrongClassName_ThrowClassNotFoundException()
        {
            //Arrange
            string className = "MoodAnalyserWrongName";
            string constructorName = className;
            string expected = "Class not found";
            string actual;

            //Add
            try
            {
                object actualInstance = MoodAnalysisReflecter.BuildMoodAnalysis(className, constructorName);
                actual = actualInstance.ToString();
            }
            catch (MoodAnalyserException e)
            {
                actual = e.Message;
            }

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMoodAnalysisBuilder_WrongConstructorName_ThrowConstructorNotFoundException()
        {
            //Arrange
            string className = "MoodAnalyser";
            string constructorName = "Wrong" + className;
            string expected = "Constructor not found";
            string actual;

            //Add
            try
            {
                object actualInstance = MoodAnalysisReflecter.BuildMoodAnalysis(className, constructorName);
                actual = actualInstance.ToString();
            }
            catch (MoodAnalyserException e)
            {
                actual = e.Message;
            }

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestParameterizedMoodAnalysisBuilder_ShouldReturnMoodAnalysisObject()
        {
            //Arrange
            string className = "MoodAnalyser";
            string constructorName = className;
            string message = "he is sad";
            object expectedInstance = new MoodAnalyser(message);

            //Add
            object actualInstance = MoodAnalysisReflecter.BuildMoodAnalysis(className, constructorName,message);

            //Assert
            expectedInstance.Equals(actualInstance);
        }

        [TestMethod]
        public void TestParameterizedMoodAnalysisBuilder_WrongClassName_ThrowClassNotFoundException()
        {
            //Arrange
            string className = "MoodAnalyserWrongName";
            string constructorName = className;
            string message = "She is happy";
            string expected = "Class not found";
            string actual;

            //Add
            try
            {
                object actualInstance = MoodAnalysisReflecter.BuildMoodAnalysis(className, constructorName,message);
                actual = actualInstance.ToString();
            }
            catch (MoodAnalyserException e)
            {
                actual = e.Message;
            }

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestParameterizedMoodAnalysisBuilder_WrongConstructorName_ThrowConstructorNotFoundException()
        {
            //Arrange
            string className = "MoodAnalyser";
            string constructorName = "Wrong" + className;
            string message = "She is happy";
            string expected = "Constructor not found";
            string actual;

            //Add
            try
            {
                object actualInstance = MoodAnalysisReflecter.BuildMoodAnalysis(className, constructorName,message);
                actual = actualInstance.ToString();
            }
            catch (MoodAnalyserException e)
            {
                actual = e.Message;
            }

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestInvokeMoodAnalysis_ShouldReturnMoodAsPerMessage()
        {
            //Arrange
            string methodName = "AnalyseMood";
            string message = "he is sad";
            string expectedMood = "SAD";

            //Add
            string actualMood = MoodAnalysisReflecter.InvokeMoodAnalysis(methodName, message);

            //Assert
            Assert.AreEqual(expectedMood, actualMood);
        }

        [TestMethod]
        public void TestInvokeMoodAnalysis_WrongMethodName_ThrowMethodNotFoundException()
        {
            //Arrange
            string methodName = "AnalyseMoodWrongName";
            string message = "he is sad";
            string expected = "Method not found";
            string actual;

            //Add
            try
            {
                actual = MoodAnalysisReflecter.InvokeMoodAnalysis(methodName, message);
            }
            catch (MoodAnalyserException e)
            {
                actual = e.Message;
            }

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSetFieldValue_ShouldReturnCorrectMood()
        {
            //Arrange
            string fieldName = "_message";
            string message = "he is sad";
            string expectedMood = "SAD";

            //Add
            string actualMood = MoodAnalysisReflecter.SetFieldValue(fieldName, message);

            //Assert
            Assert.AreEqual(expectedMood, actualMood);
        }

        [TestMethod]
        public void TestSetFieldValue_WrongFieldName_ThrowExceptionFieldNotFound()
        {
            //Arrange
            string fieldName = "wrongField";
            string message = "he is happy";
            string expected = "Field not found";
            string actual;
            
            //Add
            try
            {
                actual = MoodAnalysisReflecter.SetFieldValue(fieldName, message);
            }
            catch (MoodAnalyserException e)
            {
                actual = e.Message;
            }

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSetFieldValue_NullMessage_ThrowExceptionNullMessage()
        {
            //Arrange
            string fieldName = "_message";
            string message = null;
            string expected = "Message should not be null";
            string actual;

            //Add
            try
            {
                actual = MoodAnalysisReflecter.SetFieldValue(fieldName, message);
            }
            catch (MoodAnalyserException e)
            {
                actual = e.Message;
            }

            //Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
