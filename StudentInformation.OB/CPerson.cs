using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Speech;
using System.Speech.Synthesis;
using System.Speech.AudioFormat;

namespace StudentInformation.OB
{
    public abstract class CPerson
    {
        private string _sFirstName;

        public string FirstName
        {
            get { return _sFirstName; }
            set { _sFirstName = value; }
        }
        private string _sLastName;

        public string LastName
        {
            get { return _sLastName; }
            set { _sLastName = value; }
        }
        private CAddress _oAddress1;

        public CAddress Address1
        {
            get { return _oAddress1; }
            set { _oAddress1 = value; }
        }
        private CAddress _oAddress2;

        public CAddress Address2
        {
            get { return _oAddress2; }
            set { _oAddress2 = value; }
        }

        public CPerson()
        {
            _sFirstName = string.Empty;
            _sLastName = string.Empty;
            _oAddress1 = new CAddress();
            _oAddress2 = new CAddress();

        }

        public string Speak(string sText, bool bToFile)
        {
            SpeechSynthesizer oSpeaker = new SpeechSynthesizer();

            oSpeaker.Rate = 1;
            oSpeaker.SelectVoice("Microsoft Anna");

            oSpeaker.Volume = 100;

            if (bToFile)
            {
                oSpeaker.SetOutputToWaveFile("SoundByte.wav");
            }
            oSpeaker.Speak(sText);


            string msg;
            // Initialize a new instance of the SpeechSynthesizer.
            using (SpeechSynthesizer synth = new SpeechSynthesizer())
            {

                // Get information about supported audio formats.
                string AudioFormats = "";
                foreach (SpeechAudioFormatInfo fmt in synth.Voice.SupportedAudioFormats)
                {
                    AudioFormats += String.Format("{0}\n",
                    fmt.EncodingFormat.ToString());
                }

                // Write information about the voice to the console.
                msg = "Name:          " + synth.Voice.Name + "\n";
                msg += "Culture:       " + synth.Voice.Culture + "\n";
                msg += " Age:           " + synth.Voice.Age + "\n";
                msg += " Gender:        " + synth.Voice.Gender + "\n";
                msg += " Description:   " + synth.Voice.Description + "\n";
                msg += " ID:            " + synth.Voice.Id + "\n";
                if (synth.Voice.SupportedAudioFormats.Count != 0)
                {
                     msg += " Audio formats: " + AudioFormats + "\n";
                }
                else
                {
                     msg += " No supported audio formats found" + "\n";
                }

                // Get additional information about the voice.
                
                foreach (string key in synth.Voice.AdditionalInfo.Keys)
                {
                    msg += String.Format("  {0}: {1}\n",key, synth.Voice.AdditionalInfo[key]);
                }

                msg += " Additional Info - ";
               
               
            }
            oSpeaker.Dispose();
            oSpeaker = null;
            return msg;

        }

    }
}
