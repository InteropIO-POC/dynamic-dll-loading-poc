namespace WinformApp
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
		private System.Windows.Forms.Label labelStatus;
		private System.Windows.Forms.Label labelStatusValue;
		private System.Windows.Forms.Label labelPlatform;
		private System.Windows.Forms.Label labelVersion;
		private System.Windows.Forms.Label labelFDC3;
		private System.Windows.Forms.TextBox textBoxAppName;
		private System.Windows.Forms.Button buttonOpen;

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.labelStatus = new System.Windows.Forms.Label();
			this.labelStatusValue = new System.Windows.Forms.Label();
			this.labelPlatform = new System.Windows.Forms.Label();
			this.labelVersion = new System.Windows.Forms.Label();
			this.labelFDC3 = new System.Windows.Forms.Label();
			this.textBoxAppName = new System.Windows.Forms.TextBox();
			this.buttonOpen = new System.Windows.Forms.Button();
			this.SuspendLayout();

			this.labelStatus.Location = new System.Drawing.Point(20, 20);
			this.labelStatus.Text = "Status:";
			this.labelStatus.Font = new System.Drawing.Font(this.Font, System.Drawing.FontStyle.Bold);
			this.labelStatus.AutoSize = true;

			this.labelStatusValue.Location = new System.Drawing.Point(20, 44);
			this.labelStatusValue.Text = "Connecting...";
			this.labelStatusValue.AutoSize = true;

			this.labelPlatform.Location = new System.Drawing.Point(20, 80);
			this.labelPlatform.AutoSize = true;

			this.labelVersion.Location = new System.Drawing.Point(20, 104);
			this.labelVersion.AutoSize = true;

			this.labelFDC3.Location = new System.Drawing.Point(20, 140);
			this.labelFDC3.Text = "FDC3 Open:";
			this.labelFDC3.Font = new System.Drawing.Font(this.Font, System.Drawing.FontStyle.Bold);
			this.labelFDC3.AutoSize = true;

			this.textBoxAppName.Location = new System.Drawing.Point(20, 164);
			this.textBoxAppName.Width = 200;

			this.buttonOpen.Location = new System.Drawing.Point(228, 162);
			this.buttonOpen.Text = "Open";
			this.buttonOpen.AutoSize = true;
			this.buttonOpen.Enabled = false;
			this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);

			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Text = "Form1";
			this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.Controls.Add(this.labelStatus);
			this.Controls.Add(this.labelStatusValue);
			this.Controls.Add(this.labelPlatform);
			this.Controls.Add(this.labelVersion);
			this.Controls.Add(this.labelFDC3);
			this.Controls.Add(this.textBoxAppName);
			this.Controls.Add(this.buttonOpen);
			this.ResumeLayout(false);
			this.PerformLayout();

			NativeMethods.SetPlaceholder(textBoxAppName, "App name...");
		}

		#endregion
	}
}

