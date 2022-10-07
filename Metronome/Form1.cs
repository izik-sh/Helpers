using System.Media;

namespace Metronome
{
    public partial class Form1 : Form
    {
        System.Diagnostics.Stopwatch beatTimer = new System.Diagnostics.Stopwatch(); //Counting the time between clicks
        //DispatcherTimer metronome = new DispatcherTimer(); //Playing our metronome tick at our generated pace
        long beatCount = 0; //How many times have we clicked the button?
        long beatTime = 0; //How long should the metronome take between ticks?
        long timePile = 0; //Accumulate the time from the Stopwatch

        SoundPlayer metronomeTick = new SoundPlayer("metronome-tick.wav"); //Metronome ticking sound
        public Form1()
        {
            InitializeComponent();
            Console.Beep();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SoundPlayer simpleSound = new SoundPlayer(@"C:\Users\iziks\source\repos\Helpers\Metronome\bin\Debug\Sounds\Roland-PN-D10-03-Typewriting.wav");
                simpleSound.Play();
                
                Console.Beep(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Console.Beep();

        }

        private void setupMetronome()
        {
            //metronome.Interval = TimeSpan.FromMilliseconds(1000);
            //metronome.Tick += new EventHandler(metronome_Tick);
        }

        void metronome_Tick(object sender, EventArgs e)
        {
            metronomeTick.Play();
        }

        private void tmrTick_Tick(object sender, EventArgs e)
        {
            metronomeTick.Play();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //tmrTick.Interval = BpmExtensions.ToInterval(Convert.ToInt32(txtInterval.Text));
            //tmrTick_Tick(null, null);
        }
    }
}

public static class BpmExtensions
{
    const long SecondsPerMinute = TimeSpan.TicksPerMinute / TimeSpan.TicksPerSecond;

    public static int ToBpm(this TimeSpan timeSpan)
    {
        var seconds = 1 / timeSpan.TotalSeconds;
        return (int)Math.Round(seconds * SecondsPerMinute);
    }

    public static TimeSpan ToInterval(this int bpm)
    {
        var bps = (double)bpm / SecondsPerMinute;
        var interval = 1 / bps;
        return TimeSpan.FromSeconds(interval);
    }
}