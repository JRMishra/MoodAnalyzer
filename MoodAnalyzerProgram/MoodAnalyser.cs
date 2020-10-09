using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MoodAnalyzerProgram
{
    public class MoodAnalyser
    {
        string _mood;
        string _message;

        public MoodAnalyser()
        {
            _mood = "";
        }

        public MoodAnalyser(string message)
        {
            this._message = message;
        }

        public string AnalyseMood()
        {
            string regexStr = "^(.*[ ])*[sSaAdD]{3}([ ].*)*";
            Regex regexExp = new Regex(regexStr);
            _mood = regexExp.IsMatch(this._message) ? "SAD" : "HAPPY";
            return _mood;
        }
    }
}
