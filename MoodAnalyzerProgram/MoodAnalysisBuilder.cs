using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Net.Http;

namespace MoodAnalyzerProgram
{
    public class MoodAnalysisBuilder
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
    }
}
