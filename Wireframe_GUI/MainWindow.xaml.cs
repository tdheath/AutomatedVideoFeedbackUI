using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Configuration;

namespace Wireframe_GUI
{

    //Class which defines the values of each row in the table, for each column
    public class InfoRow
    {
        public string timeRange { get; set; }
        public string audioLabel { get; set; }
        public string attnLabel { get; set; }
        public string screenPath { get; set; }
        public string videoPath { get; set; }
        public string comment { get; set; }
        public string note { get; set; }

    }

    //Static class that allows for specific defining of CSV indices rather than using magic numbers. 
    //Essentially an enum, but mapped directly to numbers to avoid casting.
    public static class CSVIndices
    {
        public const int STARTTIME = 0;
        public const int STOPTIME = 1;
        public const int AUDIOLABEL = 2;
        public const int ATTNLABEL = 3;
        public const int SCREENJPG = 4;
        public const int COMMENTS = 5;
        public const int NOTES = 6;
    }

    public partial class MainWindow : Window
    {
        string directory = ConfigurationManager.AppSettings["basedirectory"];//Current directory to read data from
        //static Dictionary<string, string> AUDIO_LABELS = new Dictionary<string, string> { { "adult_only", "Adult" }, { "child_only", "Child" }, { "adult_child", "Adult\\Child" }, { "child_adult", "Child\\Adult" }, { "adult_child_adult", "Adult\\Child\\Adult" }, { "no_speech", "No Speech" } };
        //static Dictionary<string,string> ATTN_LABELS = new Dictionary<string,string> { {"shared","Shared"}, {"attentive","Attentive"}, {"inattentive","Inattentive"} };
        
        //The list of the prefix and the directories associated with it, in the form of { Prefix, DirectoriesList }
        Dictionary<string, List<string>> prefixedDirs = new Dictionary<string,List<string>>();
        TimeUpdateStack updateStack;
        ObservableCollection<InfoRow> newData = new ObservableCollection<InfoRow>();
        /* MainWindow
         * Description: Constructor for the program
         */
        public MainWindow()
        {
            InitializeComponent();
            populateCombobox();
            updateStack = TimeUpdateStack.Instance;
        }

        /* populateTable
         * Description: Method to go through the results csv file and build the table from it.
         * Args:    dataDir - The path to the directory containing the data.
         */
        private void populateTable(string dataDir)
        {
            
            string resultsCSV = dataDir.Substring(dataDir.LastIndexOf('\\') + 1).ToLower().Replace("storyboard", "results.csv");
            if (!File.Exists(dataDir + "\\" + resultsCSV))
            {
                //TODO: Throw error here?
                return;
            }

            StreamReader csvReader = new StreamReader(dataDir + "\\" + resultsCSV);
            string[] lineSplit;
            string mediaPath, startTime;
//            ObservableCollection<InfoRow> newData = new ObservableCollection<InfoRow>();

            while (csvReader.Peek() >= 0)
            {
                lineSplit = csvReader.ReadLine().Split(',');
                if(lineSplit.Length < 7)
                {
                    //TODO:Throw error?
                    continue;
                }
                InfoRow newRow = new InfoRow();
                newRow.timeRange = lineSplit[CSVIndices.STARTTIME] + "-" + lineSplit[CSVIndices.STOPTIME];
                newRow.audioLabel = lineSplit[CSVIndices.AUDIOLABEL];
                newRow.attnLabel = lineSplit[CSVIndices.ATTNLABEL];
                newRow.comment = lineSplit[CSVIndices.COMMENTS];
                newRow.note = lineSplit[CSVIndices.NOTES];

                //Trim the leading zeros, since the video/image files don't actually use them
                startTime = lineSplit[CSVIndices.STARTTIME].TrimStart("0".ToCharArray());
                //In the event that the video starts at 0, the leading 0 needs to be added back in
                if (startTime[0] == '.')
                {
                    startTime = "0" + startTime;
                }

                //Build the base media path, then use it to update the actual data values
                mediaPath = dataDir + "\\" + lineSplit[CSVIndices.AUDIOLABEL] + "\\" +
                                    startTime + "-" +
                                    lineSplit[CSVIndices.STOPTIME].TrimStart("0".ToCharArray()) +
                                    "_" + lineSplit[CSVIndices.ATTNLABEL];
                newRow.screenPath = dataDir +"\\" + lineSplit[CSVIndices.SCREENJPG];
                newRow.videoPath = dataDir + "\\full_video.wmv"+";"+ lineSplit[CSVIndices.STARTTIME] + ";"+ lineSplit[CSVIndices.STOPTIME] + ";" + (newData.Count).ToString();
                newData.Add(newRow);
            }
            csvReader.Close();

            dataTable.ItemsSource = newData;
            
            //Original way of populating data, directly from filenames. Keep for now.
            /*foreach (string dir in Directory.EnumerateDirectories(dataDir))
            {
                string dirName;
                string audioLbl = "";
                dirName = dir.Substring(dir.LastIndexOf('\\') + 1).ToLower();

                audioLbl = AUDIO_LABELS.FirstOrDefault(pair => dirName.Equals(pair.Key)).Value;

                if (audioLbl != null)
                {
                    dataSrc.AddRange(getTableData(audioLbl, dir));
                }
                else if (dirName == "graphs")
                {
                    showGraphBtn.Tag = dir;
                }

            }
             dataTable.ItemsSource = newData;
             */
        }


        /* populateCombobox
         * Description: Method to go through each subdirectory of the source files, 
         *              group them by prefix, and then populate the combobox based 
         *              on those groupings for the user to select which data subset to view.
         */ 
        private void populateCombobox()
        {
            string prefix;

            try
            {
                foreach (string dirName in Directory.EnumerateDirectories(directory))
                {
                    //Pull the prefix off of the filename, then group into the dictionary
                    //Do this in multiple steps to avoid false flags for certain chars
                    prefix = dirName.Substring(dirName.LastIndexOf('\\') + 1);
                    prefix = prefix.Substring(0, prefix.IndexOf("_")).ToUpper();

                    if (prefixedDirs.ContainsKey(prefix))
                    {
                        prefixedDirs[prefix].Add(dirName);
                    }
                    else
                    {
                        prefixedDirs.Add(prefix, new List<string> { dirName });
                    }
                }

                prefixCombo.ItemsSource = prefixedDirs.Keys;
            }
            catch(Exception e)
            {
                MessageBox.Show("Error reading data files: \n" + e.Message);
            }
        }

        /* saveToCSV
         * Description: Method to go through all rows of the table and save them
         *              back to the source csv file.
         */ 
        private void saveToCSV()
        {
            string srcDir = prefixedDirs[prefixCombo.SelectedValue.ToString()][tabCtrl.SelectedIndex];
            string resultsCSV = srcDir.Substring(srcDir.LastIndexOf('\\') + 1).ToLower().Replace("storyboard", "results.csv");
            string newLine;
            StreamWriter csvWriter = new StreamWriter(srcDir + "\\" + resultsCSV, false);
            foreach (InfoRow row in dataTable.Items)
            {
                newLine = row.timeRange.Substring(0, row.timeRange.IndexOf('-')) + "," +
                          row.timeRange.Substring(row.timeRange.IndexOf('-') + 1) + "," +
                          row.audioLabel + "," + row.attnLabel + "," + row.comment + "," + row.note;
                csvWriter.WriteLine(newLine);
            }
            csvWriter.Close();
        }

        /* exportData
         * Description: Method to update videos with the content from the 
         *          comments and then save them in a new place.
         * Args: exportDir - The directory to save the exported data to
         */ 
        private void exportData(string exportDir)
        {
            string baseDir;
            foreach (InfoRow row in dataTable.Items)
            {
                baseDir = exportDir + "\\" + row.videoPath.Substring(row.videoPath.LastIndexOf('\\') + 1, row.videoPath.LastIndexOf('.') - 1);
                Directory.CreateDirectory(baseDir);
                if (row.comment != "")
                {
                    //Update video clip here
                }
            }
        }

        #region Event Handlers

        /* directorySelect_Click
         * Description: Event handler for the directory select toolbar option
         * Args: sender - The object where the event originated
         *       e - The event arguments
         */ 
        private void directorySelect_Click(object sender, RoutedEventArgs e)
        {
            //Get the new directory, and then update the available options in the combobox
            System.Windows.Forms.FolderBrowserDialog findChooser = new System.Windows.Forms.FolderBrowserDialog();
            if (findChooser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                directory = findChooser.SelectedPath;
                populateCombobox();
            }
        }

        /* prefixCombo_SelectionChanged
         * Description: Event handler for the prefix combobox selection
         * Args: sender - The object where the event originated
         *       e - The event arguments
         */ 
        private void prefixCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selPrefix = prefixCombo.SelectedValue.ToString();

            //Clear everything, then build a new set of tabs based on the stored filepaths
            tabCtrl.Items.Clear();
            foreach (string dir in prefixedDirs[selPrefix])
            {
                TabItem newTab = new TabItem();
                newTab.Header = dir.Substring(dir.IndexOf(selPrefix) + selPrefix.Length + 1, dir.LastIndexOf('_') - (dir.IndexOf(selPrefix) + selPrefix.Length + 1)).ToUpper();
                newTab.Style = (Style)mainGrid.FindResource("tabStyle");
                tabCtrl.Items.Add(newTab);
            }

            //Link the graphs folder to the graph button
            if (Directory.Exists(prefixedDirs[selPrefix][0] + "\\graphs"))
            {
                showGraphBtn.Tag = prefixedDirs[selPrefix][0] + "\\graphs";
                playVideoBtn.Tag = prefixedDirs[selPrefix][0] + "\\full_video.wmv";
            }

            //Always default to the first tab
            populateTable(prefixedDirs[selPrefix][0]);
        }

        /* screen_Click
         * Description: Event handler for the screenshot buttons 
         * Args: sender - The object where the event originated
         *       e - The event arguments
         */ 
        private void screen_Click(object sender, RoutedEventArgs e)
        {
            Button mediaBtn = sender as Button;
            Player mediaPlayer;
            //Pull the stored filepath from the button's tag
            string tag = (string)mediaBtn.Tag;
            string mediaFile = tag.Split(';')[0];
            string beginTime = tag.Split(';')[1];
            string stopTime = tag.Split(';')[2];
            int row = int.Parse(tag.Split(';')[3]);
            double startSecs, stopSecs;

            //TODO: Is this still needed?
           
            //If the start time fails, then just start at the beginning. 
            //If the stop time fails, only use the start time, otherwise use both. 
            if(!Double.TryParse(beginTime, out startSecs))
            {
                mediaPlayer = new Player(mediaFile);
            }
            else if (!Double.TryParse(stopTime, out stopSecs))
            {
                mediaPlayer = new Player(mediaFile, startSecs, row);
            }
            else
            {
                mediaPlayer = new Player(mediaFile, startSecs, stopSecs, row);
            }


            mediaPlayer.Show();
        }

        /* tab_SelectionChanged
         * Description: Event handler for when tabs are changed
         * Args: sender - The object where the event originated
         *       e - The event arguments
         */ 
        private void tab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string curPrefix = prefixCombo.SelectedValue.ToString();

            //Make sure that the prefix is actually valid and that the new index is within range before trying to update the table
            if (prefixedDirs.ContainsKey(curPrefix) && prefixedDirs[curPrefix].Count >= tabCtrl.SelectedIndex && tabCtrl.SelectedIndex != -1)
            {
                string dirName = prefixedDirs[curPrefix][tabCtrl.SelectedIndex];
                populateTable(dirName);
            }
            else
            {
                //TODO: Throw error message?
            }
        }

        /* showGraphBtn_Click
         * Description: Event handler forwhen the show graph button is clicked
         * Args: sender - The object where the event originated
         *       e - The event arguments
         */ 
        private void showGraphBtn_Click(object sender, RoutedEventArgs e)
        {
            if (showGraphBtn.Tag != null)
            {
                ImageViewer imgView = new ImageViewer(showGraphBtn.Tag.ToString());
                imgView.Show();
            }
        }

        /* showCompGraphBtn_Click
         * Description: Event handler for the show comparison graph button is clicked
         * Args: sender - The object where the event originated
         *       e - The event arguments
         */ 
        private void showCompGraphBtn_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Show comparison graphs here
        }

        /* exportBtn_Click
         * Description: Event handler for when the export button is clicked
         * Args: sender - The object where the event originated
         *       e - The event arguments
         */ 
        private void exportBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog findChooser = new System.Windows.Forms.FolderBrowserDialog();

            //Get the export path and then route to the correct method
            if (findChooser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                exportData(findChooser.SelectedPath);
            }
        }

        /* saveBtn_Click
         * Description: Event handler for when the save button is clicked
         * Args: sender - The object where the event originated
         *       e - The event arguments
         */ 
        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            saveToCSV();
        }

        private void window_Activated(object sender, EventArgs e)
        {
            bool updated = false;
            while(!updateStack.IsStackEmpty())
            {
                int rowid = updateStack.PopUpdate(out string seg);
                var segsplit = seg.Split('-');
                newData[rowid].timeRange = seg;
                string[] newpath = newData[rowid].videoPath.Split(';');
                newData[rowid].videoPath = newpath[0] + ';' + segsplit[0] + ';' + segsplit[1] + ';' + newpath[3];
                updated = true;
            }

            if(updated)
            {
                dataTable.ItemsSource = newData;
                dataTable.Items.Refresh();
            }
        }

        private void playfullBtn_Click(object sender, RoutedEventArgs e)
        {
            if (playVideoBtn != null)
            {
                var mediaPlayer = new Player(playVideoBtn.Tag.ToString());
                mediaPlayer.Show();
            }
        }
        #endregion

        #region DEPRECATED CODE

        /*
         * DEPRECATED CODE. Keep for now in case source dataset changes.
        private List<inputRowList> getTableData(string audioLbl, string srcDir)
        {
            var query = Directory.EnumerateFiles(srcDir).GroupBy(
                prefix => prefix.Substring(prefix.LastIndexOf('\\') + 1, prefix.LastIndexOf("_") - prefix.LastIndexOf('\\') - 1),
                name => name,
                (prefixValue, fileName) => new
                {
                    Key = prefixValue,
                    FileName = fileName
                });

            List<inputRowList> newData = new List<inputRowList>();
            foreach (var result in query)
            {
                inputRowList newRow = new inputRowList();
                newRow.timeRange = result.Key;
                newRow.audioLabel = audioLbl;
                foreach (string name in result.FileName)
                {
                    switch (name.Substring(name.LastIndexOf('.') + 1).ToLower())
                    {
                        case "mp4":
                            newRow.videoPath = name;
                            newRow.attnLabel = ATTN_LABELS.FirstOrDefault(pair => name.ToLower().Contains(pair.Key)).Value;
                            if (newRow.attnLabel == null)
                            {
                                newRow.attnLabel = "NOT FOUND";
                            }
                            break;
                        case "png":
                        case "jpg":
                            newRow.screenPath = name;
                            break;
                        default:
                            break;
                    }
                }
                newData.Add(newRow);
            }

            return newData;
        }


        //Method to search for all desired files
        //
        //Returns a list of filepaths
        public List<string> search(string path)
        {
            //List any files with the extensions chosen
            List<string> files = Directory.EnumerateDirectories(path).ToList();
            return files;
        }


        //Method to parse file paths down to just the name
        private static string getFileName(string f, bool includeExtension)
        {
            string[] pathSplit = f.Split('\\');
            string tempName = pathSplit.Last();

            if (!includeExtension)
            {
                int extStart = tempName.LastIndexOf('.');
                tempName = tempName.Substring(0, extStart);
            }
            return tempName;
        }*/
        #endregion
    }
}
