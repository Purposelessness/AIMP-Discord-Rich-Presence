using System;
using System.Drawing;
using System.Windows.Forms;

namespace AIMP_Discord_Rich_Presence.Aimp.TrackInfoPresenter
{
    public class TrackInfoPresenterView : Form
    {
        private const string TimeFormat = @"mm\:ss";
        
        public TrackInfoPresenterView()
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
            _durationLabel.Text = TimeSpan.FromSeconds(trackInfo.Duration).ToString(TimeFormat);
            SetTrackCover(trackInfo.AlbumCover);
        }

        public void SetTrackCover(Image cover)
        {
            if (cover == null)
                return;
            _coverPicture.Image = cover;
        }

        public void SetPlayerState(string state)
        {
            _playerStateLabel.Text = state;
        }

        public void SetPlayerPosition(double position)
        {
            _playerPositionLabel.Text = TimeSpan.FromSeconds(position).ToString(TimeFormat);
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
            this._playerStateLabel = new System.Windows.Forms.Label();
            this._playerPositionLabel = new System.Windows.Forms.Label();
            this._durationLabel = new System.Windows.Forms.Label();
            this._timeSeparator = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._coverPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // _titleLabel
            // 
            this._titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._titleLabel.Location = new System.Drawing.Point(344, 20);
            this._titleLabel.Name = "_titleLabel";
            this._titleLabel.Size = new System.Drawing.Size(310, 36);
            this._titleLabel.TabIndex = 0;
            this._titleLabel.Text = "Title";
            this._titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _albumLabel
            // 
            this._albumLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._albumLabel.Location = new System.Drawing.Point(344, 56);
            this._albumLabel.Name = "_albumLabel";
            this._albumLabel.Size = new System.Drawing.Size(310, 36);
            this._albumLabel.TabIndex = 1;
            this._albumLabel.Text = "Album";
            this._albumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _artistLabel
            // 
            this._artistLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._artistLabel.Location = new System.Drawing.Point(344, 92);
            this._artistLabel.Name = "_artistLabel";
            this._artistLabel.Size = new System.Drawing.Size(310, 36);
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
            // _playerStateLabel
            // 
            this._playerStateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._playerStateLabel.Location = new System.Drawing.Point(344, 222);
            this._playerStateLabel.Name = "_playerStateLabel";
            this._playerStateLabel.Size = new System.Drawing.Size(310, 36);
            this._playerStateLabel.TabIndex = 5;
            this._playerStateLabel.Text = "Stopped";
            this._playerStateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _positionLabel
            // 
            this._playerPositionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._playerPositionLabel.Location = new System.Drawing.Point(344, 186);
            this._playerPositionLabel.Name = "_playerPositionLabel";
            this._playerPositionLabel.Size = new System.Drawing.Size(140, 36);
            this._playerPositionLabel.TabIndex = 6;
            this._playerPositionLabel.Text = "00:00";
            this._playerPositionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _durationLabel
            // 
            this._durationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._durationLabel.Location = new System.Drawing.Point(514, 186);
            this._durationLabel.Name = "_durationLabel";
            this._durationLabel.Size = new System.Drawing.Size(140, 36);
            this._durationLabel.TabIndex = 7;
            this._durationLabel.Text = "00:00";
            this._durationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _timeSeparator
            // 
            this._timeSeparator.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._timeSeparator.Location = new System.Drawing.Point(484, 186);
            this._timeSeparator.Name = "_timeSeparator";
            this._timeSeparator.Size = new System.Drawing.Size(30, 36);
            this._timeSeparator.TabIndex = 8;
            this._timeSeparator.Text = "/";
            this._timeSeparator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TrackInfoPresenterView
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(667, 443);
            this.Controls.Add(this._timeSeparator);
            this.Controls.Add(this._durationLabel);
            this.Controls.Add(this._playerPositionLabel);
            this.Controls.Add(this._playerStateLabel);
            this.Controls.Add(this._debugBox);
            this.Controls.Add(this._coverPicture);
            this.Controls.Add(this._artistLabel);
            this.Controls.Add(this._albumLabel);
            this.Controls.Add(this._titleLabel);
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "TrackInfoPresenterView";
            this.Padding = new System.Windows.Forms.Padding(10);
            ((System.ComponentModel.ISupportInitialize)(this._coverPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label _playerPositionLabel;
        private System.Windows.Forms.Label _durationLabel;
        private System.Windows.Forms.Label _timeSeparator;

        private System.Windows.Forms.Label _playerStateLabel;

        private System.Windows.Forms.TextBox _debugBox;

        private System.Windows.Forms.Label _artistLabel;

        private System.Windows.Forms.Label _titleLabel;
        private System.Windows.Forms.Label _albumLabel;
        private System.Windows.Forms.PictureBox _coverPicture;
    }
}