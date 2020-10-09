using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MoodAnalyzerProgram
{
    public class MoodAnalyser
    {
        string _mood;

        public MoodAnalyser()
        {
            _mood = "";
        }

        public string AnalyseMood(string msg)
        {
            string regexStr = "^(.*[ ])*[sSaAdD]{3}([ ].*)*";
            Regex regexExp = new Regex(regexStr);
            _mood = regexExp.IsMatch(msg) ? "SAD" : "HAPPY";
            return _mood;
        }
    }
}
