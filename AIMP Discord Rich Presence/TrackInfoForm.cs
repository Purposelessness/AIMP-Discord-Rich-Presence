using System.Drawing;
using System.Windows.Forms;

namespace AIMP_Discord_Rich_Presence
{
    public class TrackInfoForm : Form
    {
        public TrackInfoForm()
        {
            InitializeComponent();
        }

        public void SetTrackInfo(string trackName, string albumName, string artistName)
        {
            _titleLabel.Text = trackName;
            _albumLabel.Text = albumName;
            _artistLabel.Text = artistName;
        }

        public void SetTrackCover(Image cover)
        {
            _coverPicture.Image = cover;
        }

        public void SetDebugString(string str)
        {
            _debugLabel.Text = str;
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
            this._debugLabel = new System.Windows.Forms.Label();
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
            this._coverPicture.Location = new System.Drawing.Point(38, 9);
            this._coverPicture.Name = "_coverPicture";
            this._coverPicture.Size = new System.Drawing.Size(300, 300);
            this._coverPicture.TabIndex = 3;
            this._coverPicture.TabStop = false;
            // 
            // _debugLabel
            // 
            this._debugLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._debugLabel.Location = new System.Drawing.Point(344, 396);
            this._debugLabel.Name = "_debugLabel";
            this._debugLabel.Size = new System.Drawing.Size(306, 37);
            this._debugLabel.TabIndex = 4;
            this._debugLabel.Text = "Debug";
            this._debugLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TrackInfoForm
            // 
            this.ClientSize = new System.Drawing.Size(667, 443);
            this.Controls.Add(this._debugLabel);
            this.Controls.Add(this._coverPicture);
            this.Controls.Add(this._artistLabel);
            this.Controls.Add(this._albumLabel);
            this.Controls.Add(this._titleLabel);
            this.Name = "TrackInfoForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            ((System.ComponentModel.ISupportInitialize)(this._coverPicture)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label _artistLabel;

        private System.Windows.Forms.Label _titleLabel;
        private System.Windows.Forms.Label _albumLabel;
        private System.Windows.Forms.PictureBox _coverPicture;

        private System.Windows.Forms.Label _debugLabel;
    }
}