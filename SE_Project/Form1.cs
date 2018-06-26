using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;

using NAudio.Wave;     
using System.IO;           
using Google.Cloud.Speech.V1;
using System.Diagnostics;


namespace SE_Project
{
    public partial class Form1 : Form
    {

        // ** Expert System **
        public string query = "";               //What the user is asking for?
        public Image thePic = null;

        //** Google speech **//
        private BufferedWaveProvider bwp;

        WaveIn waveIn;
        WaveOut waveOut;
        WaveFileWriter writer;
        //WaveFileReader reader;
        string output = "audio.raw";



        //** Text to speech **//
        SpeechSynthesizer theSpeaker = new SpeechSynthesizer();             //The actual speaker
        PromptBuilder pb = new PromptBuilder();                                 //PromptBuilder for more features to the speaker
        string textPhrase = "";                                                     //THis string is what the speaker will speak.


        // ********* List of commands ****************
        public String[] greetings = { "Hello", "Hi", "Hey", "What Can I do for you?", "How can I help?", "Need help?" , "How can I help you?"};

        public String[] approves = {"Sure!", "You Got it!", "There you go!", "Working on it!","Done!","Okay!","Alright!"};

        public String[] farewell = { "Bye!", "Bye now!", "Farewell!", "See you!", "See you soon!", "Adios!" };

        public Form1()
        {
            InitializeComponent();
            thePic = waveBox.Image;


            if (CheckForInternetConnection())
            {
                //Internet works. SAM greets.
                samText.Text = "";
                Say(greetings[randomChoice(greetings)]);
            }

            else
                Say("Your internet is not connected. I may not fully be able to help you!");


            theSpeaker.Volume = 100;
            theSpeaker.Rate = -1;

            
            waveBox.Image = null;
            // ********** Google Cloud Speech ****************

            waveOut = new WaveOut();
            waveIn = new WaveIn();


            //configuring the settings for the audio file
            waveIn.DataAvailable += new EventHandler<WaveInEventArgs>(waveIn_DataAvailable);
            waveIn.WaveFormat = new NAudio.Wave.WaveFormat(16000, 1);           //16000hz
            bwp = new BufferedWaveProvider(waveIn.WaveFormat);
            bwp.DiscardOnBufferOverflow = true;                         //Discard data if overflowed.

            if (NAudio.Wave.WaveIn.DeviceCount < 1)
            {
                Say("No microphone!");
                return;
            }



        }


        //Event handler for recording voice
        void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            bwp.AddSamples(e.Buffer, 0, e.BytesRecorded);

        }




        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Expert(); //Speaks
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void mouseDownEvent(object sender, MouseEventArgs e)
        {
            //When the mouse is pressed... Listen to the audio
            waveIn.StartRecording();
        }

        private void mouseUpEvent(object sender, MouseEventArgs e)
        {

            //****************** Saving the speech into a raw file ********************************
            //When the mouse is released
            //stop recodring and save the file (Overwrtie if exist)
            waveIn.StopRecording();

            if (File.Exists("audio.raw"))
                File.Delete("audio.raw");

            //Create the raw audio file, with the given hz
            writer = new WaveFileWriter(output, waveIn.WaveFormat);

            byte[] buffer = new byte[bwp.BufferLength];
            int offset = 0;
            int count = bwp.BufferLength;

            var read = bwp.Read(buffer, offset, count);
            if (count > 0)
            {
                writer.Write(buffer, offset, read);
            }

            waveIn.Dispose();
            waveIn = null;
            writer.Close();
            writer = null;

            // ***************** RETRY

            waveOut = new WaveOut();
            waveIn = new WaveIn();

            
            //configuring the settings for the audio file
            waveIn.DataAvailable += new EventHandler<WaveInEventArgs>(waveIn_DataAvailable);
            waveIn.WaveFormat = new NAudio.Wave.WaveFormat(16000, 1);           //16000hz
            bwp = new BufferedWaveProvider(waveIn.WaveFormat);
            bwp.DiscardOnBufferOverflow = true;                         //Discard data if overflowed.

            // ***************************** speech to text conversion*******************************

            if (File.Exists("audio.raw"))
            {
                //create a speech client, (Google cloud speech API)
                var speech = SpeechClient.Create();

                //Start recognizing the audio
                var response = speech.Recognize(new RecognitionConfig()
                {
                    Encoding = RecognitionConfig.Types.AudioEncoding.Linear16,
                    SampleRateHertz = 16000,
                    LanguageCode = "en",
                }, RecognitionAudio.FromFile("audio.raw"));

                //Initializing the text 
                userText.Text = "";


                //Get each response in text
                foreach (var result in response.Results)
                {
                    foreach (var alternative in result.Alternatives)
                    {
                        userText.Text = alternative.Transcript + userText.Text;
                    }
                }

               

                //if nothing was said in the audio
                if (userText.Text.Length == 0)
                    userText.Text = "No Data ";

            }
            else
            {
                //if the audio file was not found
                userText.Text = "Audio File Missing ";

            }


            this.Expert(); 

        }



        // *********************** EXPERT SYSTEM ***************************

            // NOTE : Treat all string as a lower case.

        private void Expert()
        {
            query = userText.Text.ToLower();

            //Facebook
            if (query == "hi" || query == "hey" || query ==  "hello" || query == "how are you" || query == "what is up" || query == "how you doing")
            {
                Say(greetings[randomChoice(greetings)]);
            }

            else if (query.Contains("who are you") || query == "who is this" || query.Contains("what can you do") || query == "what are you" || query.Contains("how can you help me") || query.Contains("how can i use you") || query.Contains("what can you do for me") || query.Contains("introduce yourself") || query.Contains("who is sam"))
            {
                Say("Hello, My developers named me Sam, a System Assisted Manager. I can help you with anything. I can automate your system, open programs, tell you weather, time, news and much more. I am here to help, Just ask!");
            }

            else if (query.Contains("open word") || query == "microsoft word" || query.Contains("open ms word") || query.Contains("write a word document") || query.Contains("open microsoft word"))
            {
                Say(approves[randomChoice(approves)]);
                Process.Start(@"C:\Program Files\Microsoft Office\Office16\WINWORD.exe");
            }

            else if (query.Contains("open music player") || query == "music player" || query.Contains("open media player") || query.Contains("play a music") || query.Contains("play a song") || query.Contains("play music"))
            {
                Say(approves[randomChoice(approves)]);
                Say("Please choose a song.");

                Process.Start(@"C:\Program Files (x86)\Windows Media Player\wmplayer.exe");
            }



            else if (query.Contains("open browser") || query.Contains("browser") || query.Contains("open internet") || query.Contains("internet") || query.Contains("open web") || query.Contains("web"))
            {
                Say(approves[randomChoice(approves)]);
                Process.Start("https://www.google.com");
            }

            else if (query.Contains("what is the time")|| query.Contains("what time is it") || query.Contains("time now"))
            {
                Say("The time is " + DateTime.Now.ToString("h:mm tt"));
            }

            else if (query.Contains("what is the day") || query.Contains("what day is it") || query.Contains("date") || query.Contains("what is today"))
            {
                Say("Today is " + DateTime.Now.ToString("M/d/yyyy"));
            }

            else if (query.Contains("open facebook") || query.Contains("facebook") || query.Contains("fb") || query.Contains("face book"))
            {
                Say(approves[randomChoice(approves)]);
                Process.Start("https://www.facebook.com/");
            }

            //Youtube
            else if (query.Contains("open youtube") || query.Contains("youtube") || query.Contains("yt") || query.Contains("you tube"))
            {
                Say(approves[randomChoice(approves)]);
                Process.Start("https://www.youtube.com/");
            }


            //Twitter
            else if (query.Contains("open twitter") || query.Contains("twitter"))
            {
                Say(approves[randomChoice(approves)]);
                Process.Start("https://twitter.com/");
            }

            //IG
            else if (query.Contains("open instagram") || query.Contains("instagram") || query.Contains("ig"))
            {
                Say(approves[randomChoice(approves)]);
                Process.Start("https://www.instagram.com/");
            }

            //Google
            else if (query.Contains("open google") || query.Contains("google"))
            {
                Say(approves[randomChoice(approves)]);
                Process.Start("https://www.google.com");
            }

            else if (query.Contains("hide") || query.Contains("minimize"))
            {
                if (this.WindowState == FormWindowState.Normal)
                {
                    Say(approves[randomChoice(approves)]);
                    this.WindowState = FormWindowState.Minimized;
                }
            }

            else if (query.Contains("maximize") || query.Contains("show up") || query.Contains("where are you"))
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    Say("Here I am.");
                    this.WindowState = FormWindowState.Normal;
                }
            }
            else if (query.Contains("thank you"))
            {
                Say("My Pleasure!");

            }

            else if (query.Contains("who is pooya"))
            {
                Say("He is a Professor at Windsor University. Very generous at grading students. Does not likes to be called professor or doctor, Just Pooya!");

            }

            //Less imp
            else if (query.Contains("what") || query.Contains("who") || query.Contains("which") || query.Contains("how") || query.Contains("why") || query.Contains("when"))
            {

                Say(approves[randomChoice(approves)]);
                Process.Start("https://www.google.ca/search?q=" + query);
            }

            // Least important
            else if (query.Contains("sam"))
            {
                
                if (query.Contains("turn off") || query.Contains("bye") || query.Contains("shutdown") || query.Contains("shut down") || query.Contains("goodbye"))
                {
                    Say(farewell[randomChoice(farewell)]);
                    Application.Exit();
                }
            }

            //When all else fails
            else
            {
                Say("let me find it for you");
                Process.Start("https://www.google.ca/search?q=" + query);
            }

            //Save the report
            saveLogFile();

        }



        // ***************** SAM SPeaks *********************
        private void Say(string speakString)
        {
            waveBox.Image = thePic;
            textPhrase = "";

            textPhrase = speakString;
            pb.AppendText(textPhrase, PromptRate.Medium);
            theSpeaker.SpeakAsync(pb);


            samText.Text += textPhrase + "\n";
            pb.ClearContent();
            theSpeaker.SpeakCompleted += new EventHandler<SpeakCompletedEventArgs>(voiceComplete);
  
        }

        private void voiceComplete(object sender, EventArgs e)
        {
            //When the speak is complete
            waveBox.Image = null;
        }

        //*************** Random string generator *******************
        private int randomChoice(String[] theList)
        {
         
            Random r = new Random();

            //Random number from 0 to the length of the list
            return (r.Next(0, theList.Length));
        }

        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new System.Net.WebClient())
                {
                    using (client.OpenRead("http://clients3.google.com/generate_204"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        private void clearText(object sender, MouseEventArgs e)
        {
            userText.Text = "";
        }


        public static void killProcess(String s)
        {
            System.Diagnostics.Process[] procs = null;
            try
            {
                procs = Process.GetProcessesByName(s);
                Process curProg = procs[0];

                if (!curProg.HasExited)         //kill the main process
                    curProg.Kill();
            }
            finally
            {   //if child processes are still alive, kill them all
                if (procs != null)
                    foreach (Process p in procs)
                        p.Dispose();
            }
        }



        private void saveLogFile()
        {
            string path = @"C:\ProgramData\SAM_logFile.txt";
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;  //gets the user name

            //if the file does not exists.
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
                using (TextWriter tw = new StreamWriter(path))
                {
                    tw.WriteLine("*** Log File ****");
                    tw.Close();
                }

            }

            //keep writing 
            else if (File.Exists(path))
            {
                using (TextWriter tw = new StreamWriter(path,true)) //Parameter: path, append : bool
                {
                    tw.WriteLine("Name: "+userName+"\t"+ "Command: " + query +"\t"+ "Time: " + DateTime.Now.ToString("h:mm tt")+"\t"+ "Day: " + DateTime.Now.ToString("M/d/yyyy"));
                    tw.Close();
                }
            }
        }
    }
}

