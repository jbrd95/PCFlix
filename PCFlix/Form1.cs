using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace PCFlix
{
    public partial class Form1 : Form
    {

        Dictionary<string, Series> seriesDict;
        string CurrentEpisode;
        string CurrentSeries;

        List<string> FileTypes = new List<string>();
        List<string> BlackList = new List<string>();
        string MediaDirectory;
        string MediaPlayer;

        public Form1()
        {
            InitializeComponent();

            #region Get Saved Data
            //Check for data and .ini files
            if (File.Exists("PCFlix.ini"))
            {
                string[] data = File.ReadAllLines("PCFlix.ini");
                MediaDirectory = data[0].Substring(10).TrimEnd();
                MediaPlayer = data[1].Substring(12).TrimEnd();

                string[] dataTypes = data[2].Trim().Split(' ');
                foreach (string type in dataTypes)
                {
                    FileTypes.Add(type.ToLower());
                }
            }
            else
            {
                File.AppendAllText("PCFlix.ini", "MediaDir: " + Directory.GetCurrentDirectory()+"\n"); //first line is video directory
                File.AppendAllText("PCFlix.ini", "PlayerPath: PUT FULL PATH TO MEDIA PLAYER HERE\n"); //second line is video directory
                File.AppendAllText("PCFlix.ini", ".mkv .avi .flv\n");

                MediaDirectory = Directory.GetCurrentDirectory();

                FileTypes.Add(".mkv");
                FileTypes.Add(".mp4");
                FileTypes.Add(".avi");
                FileTypes.Add(".flv");
            }

            //holds series that should not be loaded from memory
            if (File.Exists("PCFlix.bl"))
            {
                string[] data = File.ReadAllLines("PCFlix.bl");
                foreach (string entry in data)
                    BlackList.Add(entry);
            }

            //Holds all episodes in heieracrhy series->episodes->episode data
            seriesDict = new Dictionary<string, Series>();

           


            LoadEpisodesFromSaveFile(seriesDict, "PCFlix.dat");
            #endregion

            #region Populate Episode Dictionary

            LoadEpisodesFromDirectory(seriesDict, MediaDirectory);

            
            #endregion

            //dictionary should now contain all video files
            //Next populate the SeriesListBox with the available series names.
            LoadSeriesFromDictionary(seriesDict);



        }

        private void SeriesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //user selected a series from the series menu
            //load the episodes int othe the episode list view box

            try
            {

                if ((string)SeriesListBox.SelectedItem != null)
                {
                    //Fill the list view with videos from the selected series in the Series list box
                    EpisodeListBox.Items.Clear();

                    EpisodesLabel.Text = Convert.ToString(SeriesListBox.SelectedValue) + " Episodes";

                    foreach (string episode in seriesDict[(string)SeriesListBox.SelectedItem].Episodes.Keys)
                    {
                        Episode currentEpisode = seriesDict[(string)SeriesListBox.SelectedItem].Episodes[episode];


                        EpisodeListBox.Items.Add(episode, currentEpisode.isWatched);
                    }
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        #region Series List Box Right Click Menu
        private void refreshToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string lastSeries;
            if (SeriesListBox.SelectedIndices.Count > 0)
                lastSeries = SeriesListBox.SelectedItem.ToString();
            else
                lastSeries = "";

            LoadEpisodesFromDirectory(seriesDict, MediaDirectory);

            //dictionary should now contain all video files
            //Next populate the SeriesListBox with the available series names.

            LoadSeriesFromDictionary(seriesDict);

            try
            {
                foreach (object seriesName in SeriesListBox.Items)
                {
                    if (String.Compare(lastSeries, seriesName.ToString()) == 0)
                        SeriesListBox.SelectedItem = seriesName;
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void deleteSelectionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            seriesDict.Remove(SeriesListBox.SelectedItem.ToString());

            SeriesListBox.Items.Remove(SeriesListBox.SelectedItem);

            EpisodeListBox.Clear();
        }

        private void deleteAndBlacklistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BlackList.Add(SeriesListBox.SelectedItem.ToString());
            deleteSelectionToolStripMenuItem1_Click(sender, e);
        }
        #endregion

        private void EpisodeListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //user selected an episode
            //show the episode in the display panel
            //update the current show

            try
            {

                if (EpisodeListBox.SelectedItems.Count > 0) //DesignOnlyAttribute change if there is AcceptRejectRule selection
                {
                    CurrentSeriesLabel.Text = CurrentSeries = (string)SeriesListBox.SelectedItem;
                    CurrentEpisodeLabel.Text = CurrentEpisode = EpisodeListBox.SelectedItems[0].Text;

                    CurrentEpisodePanel.BackgroundImage = WatchedImageList.Images[seriesDict[CurrentSeries].Episodes[CurrentEpisode].isWatched];

                    //get previous episode image on display panel
                    if (EpisodeListBox.SelectedIndices[0] > 0)
                    {
                        string episodeName = EpisodeListBox.Items[EpisodeListBox.SelectedIndices[0] - 1].Text;
                        PrevEpisodePanel.BackgroundImage = WatchedImageList.Images[seriesDict[CurrentSeries].Episodes[episodeName].isWatched];
                    }
                    else
                    {
                        PrevEpisodePanel.BackgroundImage = null;
                    }

                    //get next episode image on display panel
                    if (EpisodeListBox.SelectedIndices[0] < EpisodeListBox.Items.Count - 1)
                    {
                        string episodeName = EpisodeListBox.Items[EpisodeListBox.SelectedIndices[0] + 1].Text;
                        NextEpisodePanel.BackgroundImage = WatchedImageList.Images[seriesDict[CurrentSeries].Episodes[episodeName].isWatched];
                    }
                    else
                    {
                        NextEpisodePanel.BackgroundImage = null;
                    }

                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        #region Episode List Box Right Click Menu
        private void MarkWatched_Click(object sender, EventArgs e)
        {
            //mark each item 
            foreach (int index in EpisodeListBox.SelectedIndices)
            {
                string episodeName = EpisodeListBox.Items[index].Text;
                seriesDict[CurrentSeries].Episodes[episodeName].isWatched = 1;
            }

            //grab selected index
            int selectedIndex = EpisodeListBox.SelectedIndices[0];
            //reload the episode list view box
            SeriesListBox_SelectedIndexChanged(sender, e);
            //reselect the item, reloading unselects all of the indexes
            EpisodeListBox.Items[selectedIndex].Selected = true;
            //reupdate panels
            EpisodeListBox_SelectedIndexChanged(sender, e);
        }

        private void MarkSkipped_Click(object sender, EventArgs e)
        {
            //mark each item 
            foreach (int index in EpisodeListBox.SelectedIndices)
            {
                string episodeName = EpisodeListBox.Items[index].Text;
                seriesDict[CurrentSeries].Episodes[episodeName].isWatched = 2;
            }

            //grab selected index
            int selectedIndex = EpisodeListBox.SelectedIndices[0];
            //reload the episode list view box
            SeriesListBox_SelectedIndexChanged(sender, e);
            //reselect the item, reloading unselects all of the indexes
            EpisodeListBox.Items[selectedIndex].Selected = true;
            //reupdate panels
            EpisodeListBox_SelectedIndexChanged(sender, e);
        }

        private void MarkNotWatched_Click(object sender, EventArgs e)
        {
            //mark each item 
            foreach (int index in EpisodeListBox.SelectedIndices)
            {
                string episodeName = EpisodeListBox.Items[index].Text;
                seriesDict[CurrentSeries].Episodes[episodeName].isWatched = 0;
            }

            //grab selected index
            int selectedIndex = EpisodeListBox.SelectedIndices[0];
            //reload the episode list view box
            SeriesListBox_SelectedIndexChanged(sender, e);
            //reselect the item, reloading unselects all of the indexes
            EpisodeListBox.Items[selectedIndex].Selected = true;
            //reupdate panels
            EpisodeListBox_SelectedIndexChanged(sender, e);
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string lastItem;
            if (EpisodeListBox.SelectedItems.Count > 0)
                lastItem = EpisodeListBox.SelectedItems[0].Text;
            else
                lastItem = "";

            refreshToolStripMenuItem1_Click(sender, e);

            //refresh the episode box
            EpisodeListBox_SelectedIndexChanged(sender, e);

            foreach (ListViewItem item in EpisodeListBox.Items)
            {
                if (String.Compare(item.Text, lastItem) == 0)
                    item.Selected = true;
            }
        }

        private void deleteSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in EpisodeListBox.SelectedItems)
            {
                seriesDict[CurrentSeries].Episodes.Remove(item.Text);
                EpisodeListBox.Items.Remove(item);
            }

        }
        #endregion

        private void PreviousVideoButton_Click(object sender, EventArgs e)
        {
            //get previous episode
            if (EpisodeListBox.SelectedIndices[0] > 0)
            {
                int selectedIndex = EpisodeListBox.SelectedIndices[0];
                foreach (ListViewItem item in EpisodeListBox.Items)
                {
                    if (selectedIndex - 1 != item.Index)
                        item.Selected = false;
                    else
                        item.Selected = true;
                }
            }
        }

        private void NextVideoButton_Click(object sender, EventArgs e)
        {
            //get next episode
            if (EpisodeListBox.SelectedIndices[0] < EpisodeListBox.Items.Count-1)
            {
                int selectedIndex = EpisodeListBox.SelectedIndices[0];
                foreach (ListViewItem item in EpisodeListBox.Items)
                {
                    if (selectedIndex + 1 != item.Index)
                        item.Selected = false;
                    else
                        item.Selected = true;
                }
            }
        }

        private void PlayVideoButton_Click(object sender, EventArgs e)
        {
            Process.Start(seriesDict[CurrentSeries].Episodes[CurrentEpisode].fullPath);

            //mark video as watched
            seriesDict[CurrentSeries].Episodes[CurrentEpisode].isWatched = 1;

            //get next episode
            int selectedIndex = EpisodeListBox.SelectedIndices[0];
            if (selectedIndex < EpisodeListBox.Items.Count - 1)
            {
                foreach (ListViewItem item in EpisodeListBox.Items)
                {
                    if (selectedIndex + 1 != item.Index)
                        item.Selected = false;
                    else
                        item.Selected = true;
                }

                selectedIndex += 1; //shift the index up to the new value
            }

            //reload the episode list view box
            SeriesListBox_SelectedIndexChanged(sender, e);

            //reselect the item, reloading unselects all of the indexes
            EpisodeListBox.Items[selectedIndex].Selected = true;

            //reupdate panels
            EpisodeListBox_SelectedIndexChanged(sender, e);
        }

        private void MarkSkippedButton_Click(object sender, EventArgs e)
        {
            //mark video as skipped
            seriesDict[CurrentSeries].Episodes[CurrentEpisode].isWatched = 2;

            //get next episode
            int selectedIndex = EpisodeListBox.SelectedIndices[0];
            if (selectedIndex < EpisodeListBox.Items.Count - 1)
            {
                foreach (ListViewItem item in EpisodeListBox.Items)
                {
                    if (selectedIndex + 1 != item.Index)
                        item.Selected = false;
                    else
                        item.Selected = true;
                }

                selectedIndex += 1; //shift the index up to the new value
            }

            //reload the episode list view box
            SeriesListBox_SelectedIndexChanged(sender, e);

            //reselect the item, reloading unselects all of the indexes
            EpisodeListBox.Items[selectedIndex].Selected = true;

            //reupdate panels
            EpisodeListBox_SelectedIndexChanged(sender, e);

        }

        private bool IsCorrectFileType(string file, List<string> types)
        {
            foreach (string type in types)
            {
                if (file.ToLower().EndsWith(type))
                    return true;
            }

            return false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //form is closing save all data to PCFlix.data
            SaveAllData(seriesDict);
        }

        private void EpisodeListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (EpisodeListBox.SelectedIndices.Count > 0)
                PlayVideoButton_Click(sender, e);
        }

        #region Functions
        void LoadEpisodesFromDirectory(Dictionary<string, Series> seriesDict, string directory)
        {
            //Get all files in the root folder
            String[] files = Directory.GetFiles(MediaDirectory, "*", SearchOption.AllDirectories);

            //go through each file and add it to the dict if it is a video
            string[] tempFile;
            string tempFolder;
            string tempName;

            foreach (string fileName in files)
            {
                if (IsCorrectFileType(fileName, FileTypes))
                {
                    //get episode and series name
                    tempFile = fileName.Split('\\');

                    tempName = tempFile.Last();
                    tempFolder = tempFile[tempFile.Length - 2];

                    if (!BlackList.Contains(tempFolder)) //Checks to see if the series is blacklisted
                    {

                        //store in dictionary
                        if (seriesDict.ContainsKey(tempFolder)) //check to see if the series is already in the dictionary
                        {
                            //only add episode data, not series data
                            if (!seriesDict[tempFolder].Episodes.ContainsKey(tempName)) //don't overwrite episode data if its already in there
                            {
                                seriesDict[tempFolder].Episodes.Add(tempName, new Episode(tempName, tempFolder, fileName));
                                seriesDict[tempFolder].isWatched = 0;
                            }
                        }
                        else //create series entry
                        {
                            seriesDict.Add(tempFolder, new Series(tempFolder, "0"));

                            //since we just created the series it will be empty, so add the episode
                            seriesDict[tempFolder].Episodes.Add(tempName, new Episode(tempName, tempFolder, fileName));
                        }
                        
                    }
                }
            }
        }

        void LoadEpisodesFromSaveFile(Dictionary<string, Series> seriesDict, string file)
        {
            if (File.Exists("PCFlix.dat"))
            {
                //load existing data into dictionary
                string[] data = File.ReadAllLines("PCFlix.dat");

                string[] dataSplit;
                foreach (string entry in data)
                {
                    dataSplit = entry.Trim().Split('|');

                    //store in dictionary
                    if (seriesDict.ContainsKey(dataSplit[1])) //check to see if the series is already in the dictionary
                    {
                        //only add episode data, not series data
                        if (!seriesDict[dataSplit[1]].Episodes.ContainsKey(dataSplit[0])) //don't overwrite episode data if its already in there
                        {
                            seriesDict[dataSplit[1]].Episodes.Add(dataSplit[0], new Episode(dataSplit[0], dataSplit[1], dataSplit[2], dataSplit[3]));
                        }
                    }
                    else //create series entry
                    {
                        seriesDict.Add(dataSplit[1], new Series(dataSplit[1], "1"));

                        //since we just created the series it will be empty, so add the episode
                        seriesDict[dataSplit[1]].Episodes.Add(dataSplit[0], new Episode(dataSplit[0], dataSplit[1], dataSplit[2], dataSplit[3]));
                        
                    }

                    //if an episode hasn't been watched, set series to in progress
                    if (string.Compare(dataSplit[3], "0") == 0) 
                    {
                        seriesDict[dataSplit[1]].isWatched = 0;
                    }
                }

            }
            else
            {
                FileStream dat = File.Create("PCFlix.dat");
                dat.Close();
            }
        }

        void LoadSeriesFromDictionary(Dictionary<string, Series> Series)
        {
            
            SeriesListBox.Items.Clear();

            foreach (string key in Series.Keys)
            {
                SeriesListBox.Items.Add(key);
            }
        }

        void LoadEpisodesFromDictionary(Dictionary<string, Series> series)
        {
            //Fill the list view with videos from the selected series in the Series list box
            EpisodeListBox.Items.Clear();
            
            if (SeriesListBox.SelectedIndices.Count > 0 && (string)SeriesListBox.SelectedItem != null)
            {
                EpisodesLabel.Text = Convert.ToString(SeriesListBox.SelectedValue) + " Episodes";

                foreach (string episode in series[(string)SeriesListBox.SelectedItem].Episodes.Keys)
                {
                    Episode currentEpisode = series[(string)SeriesListBox.SelectedItem].Episodes[episode];


                    EpisodeListBox.Items.Add(episode, currentEpisode.isWatched);
                }
            }
        }

        void SaveAllData(Dictionary<string, Series> series)
        {
            //save all data to PCFlix.data
            File.Delete("PCFlix.dat.backup");
            File.Copy("PCFlix.dat", "PCFlix.dat.backup");
            FileStream file = File.Create("PCFlix.dat");
            file.Close();

            foreach (string key in series.Keys)
            {
                foreach (string key2 in series[key].Episodes.Keys)
                {
                    File.AppendAllText("PCFlix.dat", series[key].Episodes[key2].episodeName + "|" +
                                                     series[key].Episodes[key2].seriesName + "|" +
                                                     series[key].Episodes[key2].fullPath + "|" +
                                                     series[key].Episodes[key2].isWatched + "\n");
                }
            }

            //Update the blacklist
            file = File.Create("PCFlix.bl");
            file.Close();

            File.AppendAllLines("PCFlix.bl", BlackList);
        }






        #endregion
    }

    

    public class Episode
    {
        public string episodeName;
        public string seriesName;
        public string fullPath;
        public int isWatched; //0 not watched, 1 watched, 2 skipped

        public Episode(string episode, string series, string path)
        {
            episodeName = episode;
            seriesName = series;
            fullPath = path;
            isWatched = 0;
        }

        public Episode(string episode, string series, string path, string watched)
        {
            episodeName = episode;
            seriesName = series;
            fullPath = path;
            isWatched = Convert.ToInt16(watched);
        }
    }

    public class Series
    {
        public string seriesName;
        public Dictionary<string, Episode> Episodes;
        public int isWatched; // 0 not started, 1 finished, 2 in progress

        public Series(string series, string watched)
        {
            seriesName = series;
            isWatched = Convert.ToInt16(watched);
            Episodes = new Dictionary<string,Episode>();
        }
    }
}
