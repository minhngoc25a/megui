// ****************************************************************************
// 
// Copyright (C) 2005-2012 Doom9 & al
// 
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
// 
// ****************************************************************************

namespace MeGUI
{
    partial class FileIndexerWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileIndexerWindow));
            this.gbInput = new System.Windows.Forms.GroupBox();
            this.input = new MeGUI.FileBar();
            this.inputLabel = new System.Windows.Forms.Label();
            this.queueButton = new System.Windows.Forms.Button();
            this.loadOnComplete = new System.Windows.Forms.CheckBox();
            this.gbAudio = new System.Windows.Forms.GroupBox();
            this.demuxAll = new System.Windows.Forms.RadioButton();
            this.AudioTracks = new System.Windows.Forms.CheckedListBox();
            this.demuxNoAudiotracks = new System.Windows.Forms.RadioButton();
            this.demuxTracks = new System.Windows.Forms.RadioButton();
            this.gbOutput = new System.Windows.Forms.GroupBox();
            this.demuxVideo = new System.Windows.Forms.CheckBox();
            this.pickOutputButton = new System.Windows.Forms.Button();
            this.output = new System.Windows.Forms.TextBox();
            this.outputLabel = new System.Windows.Forms.Label();
            this.saveProjectDialog = new System.Windows.Forms.SaveFileDialog();
            this.closeOnQueue = new System.Windows.Forms.CheckBox();
            this.gbIndexer = new System.Windows.Forms.GroupBox();
            this.btnDGA = new System.Windows.Forms.RadioButton();
            this.btnFFMS = new System.Windows.Forms.RadioButton();
            this.btnD2V = new System.Windows.Forms.RadioButton();
            this.btnDGI = new System.Windows.Forms.RadioButton();
            this.gbFileInformation = new System.Windows.Forms.GroupBox();
            this.cbPGC = new System.Windows.Forms.ComboBox();
            this.lblPGC = new System.Windows.Forms.Label();
            this.txtContainerInformation = new System.Windows.Forms.TextBox();
            this.txtScanTypeInformation = new System.Windows.Forms.TextBox();
            this.txtCodecInformation = new System.Windows.Forms.TextBox();
            this.lblScanType = new System.Windows.Forms.Label();
            this.lblCodec = new System.Windows.Forms.Label();
            this.lblContainer = new System.Windows.Forms.Label();
            this.helpButton1 = new MeGUI.core.gui.HelpButton();
            this.gbInput.SuspendLayout();
            this.gbAudio.SuspendLayout();
            this.gbOutput.SuspendLayout();
            this.gbIndexer.SuspendLayout();
            this.gbFileInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbInput
            // 
            this.gbInput.Controls.Add(this.input);
            this.gbInput.Controls.Add(this.inputLabel);
            this.gbInput.Location = new System.Drawing.Point(12, 6);
            this.gbInput.Name = "gbInput";
            this.gbInput.Size = new System.Drawing.Size(424, 50);
            this.gbInput.TabIndex = 0;
            this.gbInput.TabStop = false;
            this.gbInput.Text = " Input ";
            // 
            // input
            // 
            this.input.AllowDrop = true;
            this.input.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.input.Filename = "";
            this.input.Filter = "";
            this.input.FilterIndex = 0;
            this.input.FolderMode = false;
            this.input.Location = new System.Drawing.Point(77, 10);
            this.input.Name = "input";
            this.input.ReadOnly = true;
            this.input.SaveMode = false;
            this.input.Size = new System.Drawing.Size(329, 34);
            this.input.TabIndex = 4;
            this.input.Title = null;
            this.input.FileSelected += new MeGUI.FileBarEventHandler(this.input_FileSelected);
            // 
            // inputLabel
            // 
            this.inputLabel.Location = new System.Drawing.Point(9, 22);
            this.inputLabel.Name = "inputLabel";
            this.inputLabel.Size = new System.Drawing.Size(100, 13);
            this.inputLabel.TabIndex = 0;
            this.inputLabel.Text = "Input File";
            // 
            // queueButton
            // 
            this.queueButton.Location = new System.Drawing.Point(362, 395);
            this.queueButton.Name = "queueButton";
            this.queueButton.Size = new System.Drawing.Size(74, 23);
            this.queueButton.TabIndex = 10;
            this.queueButton.Text = "Queue";
            this.queueButton.Click += new System.EventHandler(this.queueButton_Click);
            // 
            // loadOnComplete
            // 
            this.loadOnComplete.Checked = true;
            this.loadOnComplete.CheckState = System.Windows.Forms.CheckState.Checked;
            this.loadOnComplete.Location = new System.Drawing.Point(91, 395);
            this.loadOnComplete.Name = "loadOnComplete";
            this.loadOnComplete.Size = new System.Drawing.Size(144, 24);
            this.loadOnComplete.TabIndex = 11;
            this.loadOnComplete.Text = "On completion load files";
            // 
            // gbAudio
            // 
            this.gbAudio.Controls.Add(this.demuxAll);
            this.gbAudio.Controls.Add(this.AudioTracks);
            this.gbAudio.Controls.Add(this.demuxNoAudiotracks);
            this.gbAudio.Controls.Add(this.demuxTracks);
            this.gbAudio.Enabled = false;
            this.gbAudio.Location = new System.Drawing.Point(12, 187);
            this.gbAudio.Name = "gbAudio";
            this.gbAudio.Size = new System.Drawing.Size(424, 125);
            this.gbAudio.TabIndex = 8;
            this.gbAudio.TabStop = false;
            this.gbAudio.Text = " Audio Demux ";
            // 
            // demuxAll
            // 
            this.demuxAll.AutoSize = true;
            this.demuxAll.Checked = true;
            this.demuxAll.Location = new System.Drawing.Point(304, 20);
            this.demuxAll.Name = "demuxAll";
            this.demuxAll.Size = new System.Drawing.Size(100, 17);
            this.demuxAll.TabIndex = 15;
            this.demuxAll.TabStop = true;
            this.demuxAll.Text = "All Audio Tracks";
            this.demuxAll.UseVisualStyleBackColor = true;
            this.demuxAll.CheckedChanged += new System.EventHandler(this.rbtracks_CheckedChanged);
            // 
            // AudioTracks
            // 
            this.AudioTracks.CheckOnClick = true;
            this.AudioTracks.Enabled = false;
            this.AudioTracks.FormattingEnabled = true;
            this.AudioTracks.Location = new System.Drawing.Point(16, 43);
            this.AudioTracks.Name = "AudioTracks";
            this.AudioTracks.Size = new System.Drawing.Size(394, 68);
            this.AudioTracks.TabIndex = 14;
            // 
            // demuxNoAudiotracks
            // 
            this.demuxNoAudiotracks.Location = new System.Drawing.Point(19, 16);
            this.demuxNoAudiotracks.Name = "demuxNoAudiotracks";
            this.demuxNoAudiotracks.Size = new System.Drawing.Size(120, 24);
            this.demuxNoAudiotracks.TabIndex = 13;
            this.demuxNoAudiotracks.Text = "No Audio";
            this.demuxNoAudiotracks.CheckedChanged += new System.EventHandler(this.rbtracks_CheckedChanged);
            // 
            // demuxTracks
            // 
            this.demuxTracks.Enabled = false;
            this.demuxTracks.Location = new System.Drawing.Point(155, 16);
            this.demuxTracks.Name = "demuxTracks";
            this.demuxTracks.Size = new System.Drawing.Size(120, 24);
            this.demuxTracks.TabIndex = 7;
            this.demuxTracks.Text = "Select Audio Tracks";
            this.demuxTracks.CheckedChanged += new System.EventHandler(this.rbtracks_CheckedChanged);
            // 
            // gbOutput
            // 
            this.gbOutput.Controls.Add(this.demuxVideo);
            this.gbOutput.Controls.Add(this.pickOutputButton);
            this.gbOutput.Controls.Add(this.output);
            this.gbOutput.Controls.Add(this.outputLabel);
            this.gbOutput.Enabled = false;
            this.gbOutput.Location = new System.Drawing.Point(12, 318);
            this.gbOutput.Name = "gbOutput";
            this.gbOutput.Size = new System.Drawing.Size(424, 69);
            this.gbOutput.TabIndex = 12;
            this.gbOutput.TabStop = false;
            this.gbOutput.Text = " Output ";
            // 
            // demuxVideo
            // 
            this.demuxVideo.AutoSize = true;
            this.demuxVideo.Location = new System.Drawing.Point(81, 44);
            this.demuxVideo.Name = "demuxVideo";
            this.demuxVideo.Size = new System.Drawing.Size(125, 17);
            this.demuxVideo.TabIndex = 6;
            this.demuxVideo.Text = "Demux Video Stream";
            this.demuxVideo.UseVisualStyleBackColor = true;
            // 
            // pickOutputButton
            // 
            this.pickOutputButton.Location = new System.Drawing.Point(380, 17);
            this.pickOutputButton.Name = "pickOutputButton";
            this.pickOutputButton.Size = new System.Drawing.Size(30, 23);
            this.pickOutputButton.TabIndex = 5;
            this.pickOutputButton.Text = "...";
            this.pickOutputButton.Click += new System.EventHandler(this.pickOutputButton_Click);
            // 
            // output
            // 
            this.output.Location = new System.Drawing.Point(81, 17);
            this.output.Name = "output";
            this.output.ReadOnly = true;
            this.output.Size = new System.Drawing.Size(289, 21);
            this.output.TabIndex = 4;
            // 
            // outputLabel
            // 
            this.outputLabel.Location = new System.Drawing.Point(11, 21);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(100, 13);
            this.outputLabel.TabIndex = 3;
            this.outputLabel.Text = "Output File";
            // 
            // saveProjectDialog
            // 
            this.saveProjectDialog.Filter = "DGIndex project files|*.d2v";
            this.saveProjectDialog.Title = "Pick a name for your DGIndex project";
            // 
            // closeOnQueue
            // 
            this.closeOnQueue.Checked = true;
            this.closeOnQueue.CheckState = System.Windows.Forms.CheckState.Checked;
            this.closeOnQueue.Location = new System.Drawing.Point(281, 395);
            this.closeOnQueue.Name = "closeOnQueue";
            this.closeOnQueue.Size = new System.Drawing.Size(72, 24);
            this.closeOnQueue.TabIndex = 13;
            this.closeOnQueue.Text = "and close";
            // 
            // gbIndexer
            // 
            this.gbIndexer.Controls.Add(this.btnDGA);
            this.gbIndexer.Controls.Add(this.btnFFMS);
            this.gbIndexer.Controls.Add(this.btnD2V);
            this.gbIndexer.Controls.Add(this.btnDGI);
            this.gbIndexer.Enabled = false;
            this.gbIndexer.Location = new System.Drawing.Point(12, 135);
            this.gbIndexer.Name = "gbIndexer";
            this.gbIndexer.Size = new System.Drawing.Size(424, 46);
            this.gbIndexer.TabIndex = 15;
            this.gbIndexer.TabStop = false;
            this.gbIndexer.Text = " File Indexer ";
            // 
            // btnDGA
            // 
            this.btnDGA.AutoSize = true;
            this.btnDGA.Location = new System.Drawing.Point(115, 19);
            this.btnDGA.Name = "btnDGA";
            this.btnDGA.Size = new System.Drawing.Size(87, 17);
            this.btnDGA.TabIndex = 3;
            this.btnDGA.TabStop = true;
            this.btnDGA.Text = "DGAVCIndex";
            this.btnDGA.UseVisualStyleBackColor = true;
            this.btnDGA.Click += new System.EventHandler(this.btnDGA_Click);
            // 
            // btnFFMS
            // 
            this.btnFFMS.AutoSize = true;
            this.btnFFMS.Location = new System.Drawing.Point(329, 19);
            this.btnFFMS.Name = "btnFFMS";
            this.btnFFMS.Size = new System.Drawing.Size(79, 17);
            this.btnFFMS.TabIndex = 2;
            this.btnFFMS.TabStop = true;
            this.btnFFMS.Text = "FFMSIndex";
            this.btnFFMS.UseVisualStyleBackColor = true;
            this.btnFFMS.Click += new System.EventHandler(this.btnFFMS_Click);
            // 
            // btnD2V
            // 
            this.btnD2V.AutoSize = true;
            this.btnD2V.Location = new System.Drawing.Point(12, 20);
            this.btnD2V.Name = "btnD2V";
            this.btnD2V.Size = new System.Drawing.Size(67, 17);
            this.btnD2V.TabIndex = 1;
            this.btnD2V.TabStop = true;
            this.btnD2V.Text = "DGIndex";
            this.btnD2V.UseVisualStyleBackColor = true;
            this.btnD2V.Click += new System.EventHandler(this.btnD2V_Click);
            // 
            // btnDGI
            // 
            this.btnDGI.AutoSize = true;
            this.btnDGI.Location = new System.Drawing.Point(229, 19);
            this.btnDGI.Name = "btnDGI";
            this.btnDGI.Size = new System.Drawing.Size(80, 17);
            this.btnDGI.TabIndex = 0;
            this.btnDGI.TabStop = true;
            this.btnDGI.Text = "DGIndexNV";
            this.btnDGI.UseVisualStyleBackColor = true;
            this.btnDGI.Click += new System.EventHandler(this.btnDGI_Click);
            // 
            // gbFileInformation
            // 
            this.gbFileInformation.Controls.Add(this.cbPGC);
            this.gbFileInformation.Controls.Add(this.lblPGC);
            this.gbFileInformation.Controls.Add(this.txtContainerInformation);
            this.gbFileInformation.Controls.Add(this.txtScanTypeInformation);
            this.gbFileInformation.Controls.Add(this.txtCodecInformation);
            this.gbFileInformation.Controls.Add(this.lblScanType);
            this.gbFileInformation.Controls.Add(this.lblCodec);
            this.gbFileInformation.Controls.Add(this.lblContainer);
            this.gbFileInformation.Location = new System.Drawing.Point(12, 62);
            this.gbFileInformation.Name = "gbFileInformation";
            this.gbFileInformation.Size = new System.Drawing.Size(424, 67);
            this.gbFileInformation.TabIndex = 16;
            this.gbFileInformation.TabStop = false;
            this.gbFileInformation.Text = " File Information ";
            // 
            // cbPGC
            // 
            this.cbPGC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPGC.Enabled = false;
            this.cbPGC.FormattingEnabled = true;
            this.cbPGC.Location = new System.Drawing.Point(354, 34);
            this.cbPGC.Name = "cbPGC";
            this.cbPGC.Size = new System.Drawing.Size(56, 21);
            this.cbPGC.TabIndex = 7;
            // 
            // lblPGC
            // 
            this.lblPGC.AutoSize = true;
            this.lblPGC.Location = new System.Drawing.Point(351, 18);
            this.lblPGC.Name = "lblPGC";
            this.lblPGC.Size = new System.Drawing.Size(27, 13);
            this.lblPGC.TabIndex = 6;
            this.lblPGC.Text = "PGC";
            // 
            // txtContainerInformation
            // 
            this.txtContainerInformation.Enabled = false;
            this.txtContainerInformation.Location = new System.Drawing.Point(240, 34);
            this.txtContainerInformation.Name = "txtContainerInformation";
            this.txtContainerInformation.Size = new System.Drawing.Size(108, 21);
            this.txtContainerInformation.TabIndex = 5;
            // 
            // txtScanTypeInformation
            // 
            this.txtScanTypeInformation.Enabled = false;
            this.txtScanTypeInformation.Location = new System.Drawing.Point(126, 34);
            this.txtScanTypeInformation.Name = "txtScanTypeInformation";
            this.txtScanTypeInformation.Size = new System.Drawing.Size(108, 21);
            this.txtScanTypeInformation.TabIndex = 4;
            // 
            // txtCodecInformation
            // 
            this.txtCodecInformation.Enabled = false;
            this.txtCodecInformation.Location = new System.Drawing.Point(12, 34);
            this.txtCodecInformation.Name = "txtCodecInformation";
            this.txtCodecInformation.Size = new System.Drawing.Size(108, 21);
            this.txtCodecInformation.TabIndex = 3;
            // 
            // lblScanType
            // 
            this.lblScanType.AutoSize = true;
            this.lblScanType.Location = new System.Drawing.Point(123, 18);
            this.lblScanType.Name = "lblScanType";
            this.lblScanType.Size = new System.Drawing.Size(57, 13);
            this.lblScanType.TabIndex = 2;
            this.lblScanType.Text = "Scan Type";
            // 
            // lblCodec
            // 
            this.lblCodec.AutoSize = true;
            this.lblCodec.Location = new System.Drawing.Point(11, 18);
            this.lblCodec.Margin = new System.Windows.Forms.Padding(0);
            this.lblCodec.Name = "lblCodec";
            this.lblCodec.Size = new System.Drawing.Size(37, 13);
            this.lblCodec.TabIndex = 1;
            this.lblCodec.Text = "Codec";
            // 
            // lblContainer
            // 
            this.lblContainer.AutoSize = true;
            this.lblContainer.Location = new System.Drawing.Point(237, 18);
            this.lblContainer.Name = "lblContainer";
            this.lblContainer.Size = new System.Drawing.Size(54, 13);
            this.lblContainer.TabIndex = 0;
            this.lblContainer.Text = "Container";
            // 
            // helpButton1
            // 
            this.helpButton1.ArticleName = "File Indexer window";
            this.helpButton1.AutoSize = true;
            this.helpButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.helpButton1.Location = new System.Drawing.Point(13, 394);
            this.helpButton1.Name = "helpButton1";
            this.helpButton1.Size = new System.Drawing.Size(38, 23);
            this.helpButton1.TabIndex = 14;
            // 
            // FileIndexerWindow
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(444, 425);
            this.Controls.Add(this.gbFileInformation);
            this.Controls.Add(this.gbIndexer);
            this.Controls.Add(this.helpButton1);
            this.Controls.Add(this.closeOnQueue);
            this.Controls.Add(this.gbInput);
            this.Controls.Add(this.gbOutput);
            this.Controls.Add(this.loadOnComplete);
            this.Controls.Add(this.queueButton);
            this.Controls.Add(this.gbAudio);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FileIndexerWindow";
            this.Text = "MeGUI - File Indexer";
            this.gbInput.ResumeLayout(false);
            this.gbAudio.ResumeLayout(false);
            this.gbAudio.PerformLayout();
            this.gbOutput.ResumeLayout(false);
            this.gbOutput.PerformLayout();
            this.gbIndexer.ResumeLayout(false);
            this.gbIndexer.PerformLayout();
            this.gbFileInformation.ResumeLayout(false);
            this.gbFileInformation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        private System.Windows.Forms.GroupBox gbAudio;
        private System.Windows.Forms.GroupBox gbOutput;
        private System.Windows.Forms.Label inputLabel;
        private System.Windows.Forms.TextBox output;
        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.SaveFileDialog saveProjectDialog;
        private System.Windows.Forms.Button pickOutputButton;
        private System.Windows.Forms.GroupBox gbInput;
        private System.Windows.Forms.RadioButton demuxTracks;
        private System.Windows.Forms.RadioButton demuxNoAudiotracks;
        private System.Windows.Forms.Button queueButton;
        private System.Windows.Forms.CheckBox loadOnComplete;
        private System.Windows.Forms.CheckBox closeOnQueue;
        private MeGUI.core.gui.HelpButton helpButton1;
        private System.Windows.Forms.CheckedListBox AudioTracks;
        private System.Windows.Forms.RadioButton demuxAll;
        private FileBar input;
        private System.Windows.Forms.CheckBox demuxVideo;
        private System.Windows.Forms.GroupBox gbIndexer;
        private System.Windows.Forms.RadioButton btnDGI;
        private System.Windows.Forms.RadioButton btnD2V;
        private System.Windows.Forms.RadioButton btnFFMS;
        private System.Windows.Forms.RadioButton btnDGA;
        private System.Windows.Forms.GroupBox gbFileInformation;
        private System.Windows.Forms.Label lblContainer;
        private System.Windows.Forms.Label lblScanType;
        private System.Windows.Forms.Label lblCodec;
        private System.Windows.Forms.TextBox txtCodecInformation;
        private System.Windows.Forms.TextBox txtContainerInformation;
        private System.Windows.Forms.TextBox txtScanTypeInformation;
        private System.Windows.Forms.Label lblPGC;
        private System.Windows.Forms.ComboBox cbPGC;
    }
}