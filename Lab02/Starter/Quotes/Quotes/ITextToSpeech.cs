using System;
using System.Collections.Generic;
using System.Text;

namespace Quotes
{
    public interface ITextToSpeech
    {
        void Speak(string text);
    }
}
