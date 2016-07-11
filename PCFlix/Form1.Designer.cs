namespace PCFlix
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.SeriesListBox = new System.Windows.Forms.ListBox();
            this.SeriesRightClickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteSelectionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAndBlacklistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SeriesLabel = new System.Windows.Forms.Label();
            this.EpisodeListBox = new System.Windows.Forms.ListView();
            this.EpisodeRightClickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MarkWatched = new System.Windows.Forms.ToolStripMenuItem();
            this.MarkSkipped = new System.Windows.Forms.ToolStripMenuItem();
            this.MarkNotWatched = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WatchedImageList = new System.Windows.Forms.ImageList(this.components);
            this.EpisodesLabel = new System.Windows.Forms.Label();
            this.CurrentEpisodeLabel = new System.Windows.Forms.Label();
            this.PreviousVideoButton = new System.Windows.Forms.Button();
            this.NextVideoButton = new System.Windows.Forms.Button();
            this.PlayVideoButton = new System.Windows.Forms.Button();
            this.CurrentEpisodePanel = new System.Windows.Forms.Panel();
            this.CurrentSeriesLabel = new System.Windows.Forms.Label();
            this.NextEpisodePanel = new System.Windows.Forms.Panel();
            this.PrevEpisodePanel = new System.Windows.Forms.Panel();
            this.MarkSkippedButton = new System.Windows.Forms.Button();
            this.filterShowsCheck = new System.Windows.Forms.CheckBox();
            this.SeriesRightClickMenu.SuspendLayout();
            this.EpisodeRightClickMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // SeriesListBox
            // 
            this.SeriesListBox.ContextMenuStrip = this.SeriesRightClickMenu;
            this.SeriesListBox.FormattingEnabled = true;
            this.SeriesListBox.Items.AddRange(new object[] {
            "Hello",
            "World"});
            this.SeriesListBox.Location = new System.Drawing.Point(12, 25);
            this.SeriesListBox.Name = "SeriesListBox";
            this.SeriesListBox.Size = new System.Drawing.Size(270, 238);
            this.SeriesListBox.Sorted = true;
            this.SeriesListBox.TabIndex = 0;
            this.SeriesListBox.SelectedIndexChanged += new System.EventHandler(this.SeriesListBox_SelectedIndexChanged);
            // 
            // SeriesRightClickMenu
            // 
            this.SeriesRightClickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem1,
            this.toolStripSeparator3,
            this.deleteSelectionToolStripMenuItem1,
            this.deleteAndBlacklistToolStripMenuItem});
            this.SeriesRightClickMenu.Name = "contextMenuStrip1";
            this.SeriesRightClickMenu.Size = new System.Drawing.Size(177, 76);
            // 
            // refreshToolStripMenuItem1
            // 
            this.refreshToolStripMenuItem1.Name = "refreshToolStripMenuItem1";
            this.refreshToolStripMenuItem1.Size = new System.Drawing.Size(176, 22);
            this.refreshToolStripMenuItem1.Text = "Refresh";
            this.refreshToolStripMenuItem1.Click += new System.EventHandler(this.refreshToolStripMenuItem1_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(173, 6);
            // 
            // deleteSelectionToolStripMenuItem1
            // 
            this.deleteSelectionToolStripMenuItem1.Name = "deleteSelectionToolStripMenuItem1";
            this.deleteSelectionToolStripMenuItem1.Size = new System.Drawing.Size(176, 22);
            this.deleteSelectionToolStripMenuItem1.Text = "Delete Selection";
            this.deleteSelectionToolStripMenuItem1.Click += new System.EventHandler(this.deleteSelectionToolStripMenuItem1_Click);
            // 
            // deleteAndBlacklistToolStripMenuItem
            // 
            this.deleteAndBlacklistToolStripMenuItem.Name = "deleteAndBlacklistToolStripMenuItem";
            this.deleteAndBlacklistToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.deleteAndBlacklistToolStripMenuItem.Text = "Delete and Blacklist";
            this.deleteAndBlacklistToolStripMenuItem.ToolTipText = "Removes the records as well as preventing the application from adding this series" +
    " upon refresh or restarting the application.";
            this.deleteAndBlacklistToolStripMenuItem.Click += new System.EventHandler(this.deleteAndBlacklistToolStripMenuItem_Click);
            // 
            // SeriesLabel
            // 
            this.SeriesLabel.AutoSize = true;
            this.SeriesLabel.Location = new System.Drawing.Point(12, 9);
            this.SeriesLabel.Name = "SeriesLabel";
            this.SeriesLabel.Size = new System.Drawing.Size(36, 13);
            this.SeriesLabel.TabIndex = 1;
            this.SeriesLabel.Text = "Series";
            // 
            // EpisodeListBox
            // 
            this.EpisodeListBox.ContextMenuStrip = this.EpisodeRightClickMenu;
            this.EpisodeListBox.LargeImageList = this.WatchedImageList;
            this.EpisodeListBox.Location = new System.Drawing.Point(11, 282);
            this.EpisodeListBox.Name = "EpisodeListBox";
            this.EpisodeListBox.Size = new System.Drawing.Size(800, 300);
            this.EpisodeListBox.SmallImageList = this.WatchedImageList;
            this.EpisodeListBox.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.EpisodeListBox.StateImageList = this.WatchedImageList;
            this.EpisodeListBox.TabIndex = 2;
            this.EpisodeListBox.UseCompatibleStateImageBehavior = false;
            this.EpisodeListBox.SelectedIndexChanged += new System.EventHandler(this.EpisodeListBox_SelectedIndexChanged);
            this.EpisodeListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.EpisodeListBox_MouseDoubleClick);
            // 
            // EpisodeRightClickMenu
            // 
            this.EpisodeRightClickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MarkWatched,
            this.MarkSkipped,
            this.MarkNotWatched,
            this.toolStripSeparator1,
            this.refreshToolStripMenuItem,
            this.toolStripSeparator2,
            this.deleteSelectionToolStripMenuItem});
            this.EpisodeRightClickMenu.Name = "EpisodeRightClickMenu";
            this.EpisodeRightClickMenu.Size = new System.Drawing.Size(189, 126);
            // 
            // MarkWatched
            // 
            this.MarkWatched.Name = "MarkWatched";
            this.MarkWatched.Size = new System.Drawing.Size(188, 22);
            this.MarkWatched.Text = "Mark as Watched";
            this.MarkWatched.Click += new System.EventHandler(this.MarkWatched_Click);
            // 
            // MarkSkipped
            // 
            this.MarkSkipped.Name = "MarkSkipped";
            this.MarkSkipped.Size = new System.Drawing.Size(188, 22);
            this.MarkSkipped.Text = "Mark as Skipped";
            this.MarkSkipped.Click += new System.EventHandler(this.MarkSkipped_Click);
            // 
            // MarkNotWatched
            // 
            this.MarkNotWatched.Name = "MarkNotWatched";
            this.MarkNotWatched.Size = new System.Drawing.Size(188, 22);
            this.MarkNotWatched.Text = "Mark as Not Watched";
            this.MarkNotWatched.Click += new System.EventHandler(this.MarkNotWatched_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(185, 6);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(185, 6);
            // 
            // deleteSelectionToolStripMenuItem
            // 
            this.deleteSelectionToolStripMenuItem.Name = "deleteSelectionToolStripMenuItem";
            this.deleteSelectionToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.deleteSelectionToolStripMenuItem.Text = "Delete Selection";
            this.deleteSelectionToolStripMenuItem.ToolTipText = "Deletes the record of the episode(s) from the Watched database. This does NOT del" +
    "ete the episode(s) from the storage device.";
            this.deleteSelectionToolStripMenuItem.Click += new System.EventHandler(this.deleteSelectionToolStripMenuItem_Click);
            // 
            // WatchedImageList
            // 
            this.WatchedImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("WatchedImageList.ImageStream")));
            this.WatchedImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.WatchedImageList.Images.SetKeyName(0, "No.png");
            this.WatchedImageList.Images.SetKeyName(1, "Yes.png");
            this.WatchedImageList.Images.SetKeyName(2, "skip.png");
            // 
            // EpisodesLabel
            // 
            this.EpisodesLabel.AutoSize = true;
            this.EpisodesLabel.Location = new System.Drawing.Point(12, 266);
            this.EpisodesLabel.Name = "EpisodesLabel";
            this.EpisodesLabel.Size = new System.Drawing.Size(50, 13);
            this.EpisodesLabel.TabIndex = 3;
            this.EpisodesLabel.Text = "Episodes";
            // 
            // CurrentEpisodeLabel
            // 
            this.CurrentEpisodeLabel.AutoSize = true;
            this.CurrentEpisodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentEpisodeLabel.Location = new System.Drawing.Point(317, 49);
            this.CurrentEpisodeLabel.Name = "CurrentEpisodeLabel";
            this.CurrentEpisodeLabel.Size = new System.Drawing.Size(203, 24);
            this.CurrentEpisodeLabel.TabIndex = 4;
            this.CurrentEpisodeLabel.Text = "Current Episode Name";
            // 
            // PreviousVideoButton
            // 
            this.PreviousVideoButton.Location = new System.Drawing.Point(291, 171);
            this.PreviousVideoButton.Name = "PreviousVideoButton";
            this.PreviousVideoButton.Size = new System.Drawing.Size(75, 23);
            this.PreviousVideoButton.TabIndex = 5;
            this.PreviousVideoButton.Text = "Previous";
            this.PreviousVideoButton.UseVisualStyleBackColor = true;
            this.PreviousVideoButton.Click += new System.EventHandler(this.PreviousVideoButton_Click);
            // 
            // NextVideoButton
            // 
            this.NextVideoButton.Location = new System.Drawing.Point(506, 171);
            this.NextVideoButton.Name = "NextVideoButton";
            this.NextVideoButton.Size = new System.Drawing.Size(75, 23);
            this.NextVideoButton.TabIndex = 6;
            this.NextVideoButton.Text = "Next";
            this.NextVideoButton.UseVisualStyleBackColor = true;
            this.NextVideoButton.Click += new System.EventHandler(this.NextVideoButton_Click);
            // 
            // PlayVideoButton
            // 
            this.PlayVideoButton.Location = new System.Drawing.Point(372, 210);
            this.PlayVideoButton.Name = "PlayVideoButton";
            this.PlayVideoButton.Size = new System.Drawing.Size(128, 51);
            this.PlayVideoButton.TabIndex = 7;
            this.PlayVideoButton.Text = "Watch!";
            this.PlayVideoButton.UseVisualStyleBackColor = true;
            this.PlayVideoButton.Click += new System.EventHandler(this.PlayVideoButton_Click);
            // 
            // CurrentEpisodePanel
            // 
            this.CurrentEpisodePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CurrentEpisodePanel.Location = new System.Drawing.Point(372, 76);
            this.CurrentEpisodePanel.Name = "CurrentEpisodePanel";
            this.CurrentEpisodePanel.Size = new System.Drawing.Size(128, 128);
            this.CurrentEpisodePanel.TabIndex = 8;
            // 
            // CurrentSeriesLabel
            // 
            this.CurrentSeriesLabel.AutoSize = true;
            this.CurrentSeriesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentSeriesLabel.Location = new System.Drawing.Point(317, 25);
            this.CurrentSeriesLabel.Name = "CurrentSeriesLabel";
            this.CurrentSeriesLabel.Size = new System.Drawing.Size(130, 24);
            this.CurrentSeriesLabel.TabIndex = 9;
            this.CurrentSeriesLabel.Text = "Current Series";
            // 
            // NextEpisodePanel
            // 
            this.NextEpisodePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.NextEpisodePanel.Location = new System.Drawing.Point(517, 101);
            this.NextEpisodePanel.Name = "NextEpisodePanel";
            this.NextEpisodePanel.Size = new System.Drawing.Size(64, 64);
            this.NextEpisodePanel.TabIndex = 9;
            // 
            // PrevEpisodePanel
            // 
            this.PrevEpisodePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PrevEpisodePanel.Location = new System.Drawing.Point(291, 101);
            this.PrevEpisodePanel.Name = "PrevEpisodePanel";
            this.PrevEpisodePanel.Size = new System.Drawing.Size(64, 64);
            this.PrevEpisodePanel.TabIndex = 11;
            // 
            // MarkSkippedButton
            // 
            this.MarkSkippedButton.Location = new System.Drawing.Point(506, 238);
            this.MarkSkippedButton.Name = "MarkSkippedButton";
            this.MarkSkippedButton.Size = new System.Drawing.Size(75, 23);
            this.MarkSkippedButton.TabIndex = 12;
            this.MarkSkippedButton.Text = "Skip";
            this.MarkSkippedButton.UseVisualStyleBackColor = true;
            this.MarkSkippedButton.Click += new System.EventHandler(this.MarkSkippedButton_Click);
            // 
            // filterShowsCheck
            // 
            this.filterShowsCheck.AutoSize = true;
            this.filterShowsCheck.Location = new System.Drawing.Point(54, 8);
            this.filterShowsCheck.Name = "filterShowsCheck";
            this.filterShowsCheck.Size = new System.Drawing.Size(141, 17);
            this.filterShowsCheck.TabIndex = 13;
            this.filterShowsCheck.Text = "Show Completed Shows";
            this.filterShowsCheck.UseVisualStyleBackColor = true;
            this.filterShowsCheck.CheckedChanged += new System.EventHandler(this.filterShowsCheck_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 593);
            this.Controls.Add(this.filterShowsCheck);
            this.Controls.Add(this.MarkSkippedButton);
            this.Controls.Add(this.PrevEpisodePanel);
            this.Controls.Add(this.NextEpisodePanel);
            this.Controls.Add(this.CurrentSeriesLabel);
            this.Controls.Add(this.CurrentEpisodePanel);
            this.Controls.Add(this.PlayVideoButton);
            this.Controls.Add(this.NextVideoButton);
            this.Controls.Add(this.PreviousVideoButton);
            this.Controls.Add(this.CurrentEpisodeLabel);
            this.Controls.Add(this.EpisodesLabel);
            this.Controls.Add(this.EpisodeListBox);
            this.Controls.Add(this.SeriesLabel);
            this.Controls.Add(this.SeriesListBox);
            this.Name = "Form1";
            this.Text = "PCFlix";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.SeriesRightClickMenu.ResumeLayout(false);
            this.EpisodeRightClickMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox SeriesListBox;
        private System.Windows.Forms.Label SeriesLabel;
        private System.Windows.Forms.ListView EpisodeListBox;
        private System.Windows.Forms.Label EpisodesLabel;
        private System.Windows.Forms.ImageList WatchedImageList;
        private System.Windows.Forms.Label CurrentEpisodeLabel;
        private System.Windows.Forms.Button PreviousVideoButton;
        private System.Windows.Forms.Button NextVideoButton;
        private System.Windows.Forms.Button PlayVideoButton;
        private System.Windows.Forms.Panel CurrentEpisodePanel;
        private System.Windows.Forms.Label CurrentSeriesLabel;
        private System.Windows.Forms.ContextMenuStrip EpisodeRightClickMenu;
        private System.Windows.Forms.ToolStripMenuItem MarkWatched;
        private System.Windows.Forms.ToolStripMenuItem MarkSkipped;
        private System.Windows.Forms.ToolStripMenuItem MarkNotWatched;
        private System.Windows.Forms.Panel NextEpisodePanel;
        private System.Windows.Forms.Panel PrevEpisodePanel;
        private System.Windows.Forms.Button MarkSkippedButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem deleteSelectionToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip SeriesRightClickMenu;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem deleteSelectionToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteAndBlacklistToolStripMenuItem;
        private System.Windows.Forms.CheckBox filterShowsCheck;
    }
}

