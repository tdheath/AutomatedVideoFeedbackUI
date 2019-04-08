using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Wireframe_GUI
{
    /// <summary>
    /// Class which includes a separate window that plays videos sent by the main GUI
    /// </summary>
    public partial class Player : Window
    {
        AxWMPLib.AxWindowsMediaPlayer axWmp; //The media player object
        private double clipStart, clipStop = -1;
        private double origStartTime, origStopTime = -1; //Start/stop times, defaulted to a bad value which not in use
        private DispatcherTimer pauseTimer; //Background thread which pauses the video based on the given stop time
        private int rowid = -1;
        private TimeUpdateStack updateStack = TimeUpdateStack.Instance;

        /* Player
         * Description: Base constructor. Invokes the window and does nothing else
         */
        public Player()
        {
            InitializeComponent();

            // Get the AxHost wrapper from the WindowsFormsHost control.
            axWmp = formsHost.Child as AxWMPLib.AxWindowsMediaPlayer;
        }

        /* Player
         * Description: Overloaded constructor, which also takes in a file and starts it.
         * Args: mediaFilePath - The path to the file to be played
         */
        public Player(string mediaFilePath)
        {
            InitializeComponent();

            // Get the AxHost wrapper from the WindowsFormsHost control.
            axWmp = formsHost.Child as AxWMPLib.AxWindowsMediaPlayer;
            axWmp.URL = mediaFilePath;

        }

        /* Player
         * Description: Overloaded constructor, which takes in a file and starts it 
         *          at a given time.
         * Args: mediaFilePath - The path to the file to be played
         *       startingTime - The time to start at, in seconds
         */
        public Player(string mediaFilePath, double startingTime, int row)
        {
            InitializeComponent();

            // Get the AxHost wrapper from the WindowsFormsHost control.
            axWmp = formsHost.Child as AxWMPLib.AxWindowsMediaPlayer;
            axWmp.URL = mediaFilePath;
            axWmp.Ctlcontrols.currentPosition = startingTime;
            startTimeEntry.Text = startingTime.ToString();
            origStartTime = startingTime;
            clipStart = startingTime;
            rowid = row;
        }

        /* Player
         * Description: Overloaded constructor, which takes in a file and starts it 
         *          at a given time, then stops it at the given time.
         * Args: mediaFilePath - The path to the file to be played
         *       startingTime - The time to start at, in seconds
         *       stoppingTime - The time to stop the video, in seconds
         */
        public Player(string mediaFilePath, double startingTime, double stoppingTime, int row)
        {
            InitializeComponent();

            // Get the AxHost wrapper from the WindowsFormsHost control.
            axWmp = formsHost.Child as AxWMPLib.AxWindowsMediaPlayer;
            axWmp.URL = mediaFilePath;

            startTimeEntry.Text = startingTime.ToString();
            stopTimeEntry.Text = stoppingTime.ToString();
            origStartTime = startingTime;
            origStopTime = stoppingTime;
            clipStart = startingTime;
            clipStop = stoppingTime;
            rowid = row;

            playMediaWithStop(startingTime, stoppingTime);
        }

        /* playMediaWithStop
         * Description: Method to start a video and then initiate a 
         *              pause timer to stop it after a given amount 
         *              of time has passed.
         * Args: startingTime - The time to start at, in seconds
         *       stoppingTime - The time to stop the video, in seconds
         */
        private void playMediaWithStop(double startingTime, double stoppingTime)
        {

            axWmp.Ctlcontrols.currentPosition = startingTime;
            //Build a timer to ensure that the video pauses once the given time has elapsed. Add 1 second to allow for a buffer
            pauseTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(stoppingTime - startingTime + 1) };

            //Lamba expression for the pause timer, which only ticks the one time
            pauseTimer.Tick += (sender, args) =>
            {
                axWmp.Ctlcontrols.pause();
                pauseTimer.Stop();
            };

            pauseTimer.Start();
        }

        /* Window_Closing
         * Description: Event handler for when the window closes.
         * Args: sender - The object where the event originated
         *       e - The event arguments
         */
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (rowid != -1 && (clipStart != origStartTime || clipStop != origStopTime))
            {
                updateStack.PushUpdate(rowid, origStartTime.ToString(), origStopTime.ToString());
            }

            axWmp.close();
        }

        /* restartBtn_Click
         * Description: Event handler for when restart button is clicked
         * Args: sender - The object where the event originated
         *       e - The event arguments
         */
        private void restartBtn_Click(object sender, RoutedEventArgs e)
        {
            //If there is a stop time set, then kill the current timer and restart it
            if(origStopTime != -1)
            {
                if (pauseTimer != null && pauseTimer.IsEnabled)
                {
                    pauseTimer.Stop();
                }
                playMediaWithStop(origStartTime, origStopTime);
            }
            else
            {
                axWmp.Ctlcontrols.currentPosition = origStartTime;
            }
        }

        private void newstartBtn_Click(object sender, RoutedEventArgs e)
        {
            origStartTime = Math.Round(axWmp.Ctlcontrols.currentPosition, 2);
            startTimeEntry.Text = origStartTime.ToString();
        }

        private void newstopBtn_Click(object sender, RoutedEventArgs e)
        {
            origStopTime = Math.Round(axWmp.Ctlcontrols.currentPosition, 2);
            stopTimeEntry.Text = origStopTime.ToString();
        }
    }
}
