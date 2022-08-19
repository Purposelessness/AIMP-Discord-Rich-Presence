using System;
using System.Drawing;
using System.Windows.Forms;

namespace AIMP_Discord_Rich_Presence
{
    public class TrackInfoForm : Form
    {
        public TrackInfoForm()
        {
            InitializeComponent();
            foreach (var message in Debug.Instance.List)
            {
                _debugBox.Text = _debugBox.Text + message + Environment.NewLine;
            }
        }

        public void SetTrackInfo(TrackInfo trackInfo)
        {
            _titleLabel.Text = trackInfo.Title;
            _albumLabel.Text = trackInfo.Album;
            _artistLabel.Text = trackInfo.Artist;
        }

        public void SetTrackCover(Image cover)
        {
            _coverPicture.Image = cover;
        }

        public void SetDebugString(string message)
        {
            _debugBox.Text = _debugBox.Text + message + Environment.NewLine;
        }

        public new void Dispose(bool disposing) => base.Dispose(disposing);

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._titleLabel = new System.Windows.Forms.Label();
            this._albumLabel = new System.Windows.Forms.Label();
            this._artistLabel = new System.Windows.Forms.Label();
            this._coverPicture = new System.Windows.Forms.PictureBox();
            this._debugBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this._coverPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // _titleLabel
            // 
            this._titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._titleLabel.Location = new System.Drawing.Point(344, 9);
            this._titleLabel.Name = "_titleLabel";
            this._titleLabel.Size = new System.Drawing.Size(311, 34);
            this._titleLabel.TabIndex = 0;
            this._titleLabel.Text = "Title";
            this._titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _albumLabel
            // 
            this._albumLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._albumLabel.Location = new System.Drawing.Point(344, 56);
            this._albumLabel.Name = "_albumLabel";
            this._albumLabel.Size = new System.Drawing.Size(311, 34);
            this._albumLabel.TabIndex = 1;
            this._albumLabel.Text = "Album";
            this._albumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _artistLabel
            // 
            this._artistLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._artistLabel.Location = new System.Drawing.Point(344, 101);
            this._artistLabel.Name = "_artistLabel";
            this._artistLabel.Size = new System.Drawing.Size(311, 34);
            this._artistLabel.TabIndex = 2;
            this._artistLabel.Text = "Artist";
            this._artistLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _coverPicture
            // 
            this._coverPicture.ImageLocation = "";
            this._coverPicture.Location = new System.Drawing.Point(38, 9);
            this._coverPicture.Name = "_coverPicture";
            this._coverPicture.Size = new System.Drawing.Size(300, 300);
            this._coverPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._coverPicture.TabIndex = 3;
            this._coverPicture.TabStop = false;
            // 
            // _debugBox
            // 
            this._debugBox.Location = new System.Drawing.Point(13, 343);
            this._debugBox.Multiline = true;
            this._debugBox.Name = "_debugBox";
            this._debugBox.ReadOnly = true;
            this._debugBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._debugBox.Size = new System.Drawing.Size(641, 87);
            this._debugBox.TabIndex = 4;
            this._debugBox.Text = "DEBUG:\r\n";
            // 
            // TrackInfoForm
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(667, 443);
            this.Controls.Add(this._debugBox);
            this.Controls.Add(this._coverPicture);
            this.Controls.Add(this._artistLabel);
            this.Controls.Add(this._albumLabel);
            this.Controls.Add(this._titleLabel);
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "TrackInfoForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            ((System.ComponentModel.ISupportInitialize)(this._coverPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox _debugBox;

        private System.Windows.Forms.Label _artistLabel;

        private System.Windows.Forms.Label _titleLabel;
        private System.Windows.Forms.Label _albumLabel;
        private System.Windows.Forms.PictureBox _coverPicture;
    }
}