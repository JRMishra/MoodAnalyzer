﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Net.Http;
using System.Runtime.CompilerServices;

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
            object instance = BuildMoodAnalysis("MoodAnalyser", "MoodAnalyser", message);

            MethodInfo methodInfo = typeRef.GetMethod(methodName);
            if (methodInfo == null)
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUCH_METHOD, "Method not found");

            object mood = methodInfo.Invoke(instance, null);
            return mood.ToString();
        }

        public static string SetFieldValue(string fieldName, string message)
        {
            if(message==null)
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NULL_MESSAGE, "Message should not be null");

            Type typeRef = Type.GetType("MoodAnalyzerProgram.MoodAnalyser");
            object instance = BuildMoodAnalysis("MoodAnalyser", "MoodAnalyser");

            FieldInfo fieldInfo = typeRef.GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
            if (fieldInfo == null)
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUCH_FIELD, "Field not found");
            
            fieldInfo.SetValue(instance, message);
            MethodInfo methodInfo = typeRef.GetMethod("AnalyseMood");

            object mood = methodInfo.Invoke(instance, null);
            return mood.ToString();
        }
    }
}
