using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MoodAnalyzerProgram
{
    public class MoodAnalyser
    {
        string _mood;
        string _message;
        enum Errors
        {
            NULL,
            EMPTY,
            OTHERS
        }

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

            if (_message == null)
                throw new MoodAnalysisException(Errors.NULL.ToString());
            else if (_message.Length == 0)
                throw new MoodAnalysisException(Errors.EMPTY.ToString());

            try
            {   
                _mood = regexExp.IsMatch(this._message) ? "SAD" : "HAPPY";
            }
            catch (MoodAnalysisException e)
            {
                throw new MoodAnalysisException(Errors.OTHERS.ToString()+" "+e.Message);
            }

            return _mood;
        }
    }
}
