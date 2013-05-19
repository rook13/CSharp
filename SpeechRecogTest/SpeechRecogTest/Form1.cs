using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Threading;

namespace SpeechRecogTest
{
    public partial class Form1 : Form
    {

        public SpeechRecognitionEngine recognitionEngine;

        public Form1()
        {
            InitializeComponent();

            recognitionEngine = new SpeechRecognitionEngine();
            recognitionEngine.SetInputToDefaultAudioDevice();

            recognitionEngine.SpeechRecognized += (s, args) =>
            {
                foreach (RecognizedWordUnit word in args.Result.Words)
                {
                   txtOutput.Text += word.Text + " ";
                }
                txtOutput.Text += Environment.NewLine;
            };

            recognitionEngine.LoadGrammar(new DictationGrammar());

        }

        private void enableButton_Click(object sender, EventArgs e)
        {
            recognitionEngine.RecognizeAsync(RecognizeMode.Multiple);
        }

        private void disableButton_Click(object sender, EventArgs e)
        {
            recognitionEngine.RecognizeAsyncStop();
        }

        
    }
}
