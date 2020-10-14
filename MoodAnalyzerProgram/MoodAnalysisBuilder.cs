using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Net.Http;

namespace MoodAnalyzerProgram
{
    public class MoodAnalysisReflecter
    {
        public static object BuildMoodAnalysis(string className, string constructor)
        {
            Type typeRef;

            
                typeRef = Type.GetType("MoodAnalyzerProgram." + className);

            if(typeRef == null)
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUCH_CLASS, "Class not found");

            if (constructor != className)
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUCH_CONSTRUCTOR, "Constructor not found");

            ConstructorInfo constructorInfo = typeRef.GetConstructor(Type.EmptyTypes);
            object instance = constructorInfo.Invoke(null);

            return instance;
        }

        public static object BuildMoodAnalysis(string className, string constructor, string message)
        {
            Type typeRef;
            typeRef = Type.GetType("MoodAnalyzerProgram." + className);

            object instance = BuildMoodAnalysis(className,constructor);

            PropertyInfo propertyInfo = typeRef.GetProperty("Message");
            propertyInfo.SetValue(instance, message);

            return instance;
        }

        public static string InvokeMoodAnalysis(string methodName, string message)
        {
            Type typeRef = Type.GetType("MoodAnalyzerProgram.MoodAnalyser");
            object instance = BuildMoodAnalysis("MoodAnalyzerProgram.MoodAnalyser", "MoodAnalyser",message);

            MethodInfo methodInfo = typeRef.GetMethod(methodName);
            if (methodName == null)
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUCH_METHOD, "No such method found");

            object mood = methodInfo.Invoke(instance, null);
            return mood.ToString();
        }

    }
}
