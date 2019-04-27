using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Speech.Tts;
using Android.Views;
using Android.Widget;

namespace Quotes.Droid
{
    public class TextToSpeechService : Java.Lang.Object, ITextToSpeech, TextToSpeech.IOnInitListener
    {
        TextToSpeech speech;
        string lastText;

        public void Speak(string text)
        {
            if (speech == null)
            {
                lastText = text;
                speech = new TextToSpeech(Android.App.Application.Context, this);
            }
            else
            {
                if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                {
                    var res = speech.Speak(text, QueueMode.Flush, null, null);
                }
                else
                {
#pragma warning disable 0618
                    var res = speech.Speak(text, QueueMode.Flush, null);
#pragma warning restore 0618
                }
            }
        }

        public void OnInit(OperationResult status)
        {
            if (status == OperationResult.Success)
            {
                if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                {
                    var res = speech.Speak(lastText, QueueMode.Flush, null, null);
                }
                else
                {
#pragma warning disable 0618
                    var res = speech.Speak(lastText, QueueMode.Flush, null);
#pragma warning restore 0618
                }
                lastText = null;
            }
        }
    }
}