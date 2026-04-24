namespace WinformApp
{
	partial class Form1
	{
		private System.ComponentModel.IContainer components = null;

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		private System.Windows.Forms.Label labelStatus;
		private System.Windows.Forms.Label labelStatusValue;

		private System.Windows.Forms.Label labelFDC3Open;
		private System.Windows.Forms.Button buttonOpen;
		private System.Windows.Forms.TextBox textBoxAppName;

		private System.Windows.Forms.Label labelFindIntent;
		private System.Windows.Forms.Button buttonFindIntent;
		private System.Windows.Forms.TextBox textBoxFindIntent;
		private System.Windows.Forms.Label labelFindIntentResult;

		private System.Windows.Forms.Label labelRaiseIntent;
		private System.Windows.Forms.Button buttonRaiseIntent;
		private System.Windows.Forms.TextBox textBoxRaiseIntent;
		private System.Windows.Forms.TextBox textBoxRaiseIntentContext;
		private System.Windows.Forms.Label labelRaiseIntentResult;

		private System.Windows.Forms.Label labelWorkspace;
		private System.Windows.Forms.Button buttonGetActiveWorkspace;
		private System.Windows.Forms.Label labelActiveWorkspaceResult;

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();

			this.labelStatus = new System.Windows.Forms.Label();
			this.labelStatusValue = new System.Windows.Forms.Label();

			this.labelFDC3Open = new System.Windows.Forms.Label();
			this.buttonOpen = new System.Windows.Forms.Button();
			this.textBoxAppName = new System.Windows.Forms.TextBox();

			this.labelFindIntent = new System.Windows.Forms.Label();
			this.buttonFindIntent = new System.Windows.Forms.Button();
			this.textBoxFindIntent = new System.Windows.Forms.TextBox();
			this.labelFindIntentResult = new System.Windows.Forms.Label();

			this.labelRaiseIntent = new System.Windows.Forms.Label();
			this.buttonRaiseIntent = new System.Windows.Forms.Button();
			this.textBoxRaiseIntent = new System.Windows.Forms.TextBox();
			this.textBoxRaiseIntentContext = new System.Windows.Forms.TextBox();
			this.labelRaiseIntentResult = new System.Windows.Forms.Label();

			this.labelWorkspace = new System.Windows.Forms.Label();
			this.buttonGetActiveWorkspace = new System.Windows.Forms.Button();
			this.labelActiveWorkspaceResult = new System.Windows.Forms.Label();

			this.SuspendLayout();

			// Status
			this.labelStatus.Location = new System.Drawing.Point(20, 20);
			this.labelStatus.Text = "Status:";
			this.labelStatus.Font = new System.Drawing.Font(this.Font, System.Drawing.FontStyle.Bold);
			this.labelStatus.AutoSize = true;

			this.labelStatusValue.Location = new System.Drawing.Point(20, 44);
			this.labelStatusValue.Text = "Connecting...";
			this.labelStatusValue.AutoSize = true;

			// FDC3 Open
			this.labelFDC3Open.Location = new System.Drawing.Point(20, 84);
			this.labelFDC3Open.Text = "FDC3 Open:";
			this.labelFDC3Open.Font = new System.Drawing.Font(this.Font, System.Drawing.FontStyle.Bold);
			this.labelFDC3Open.AutoSize = true;

			this.buttonOpen.Location = new System.Drawing.Point(20, 108);
			this.buttonOpen.Text = "Open";
			this.buttonOpen.Width = 60;
			this.buttonOpen.Enabled = false;
			this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);

			this.textBoxAppName.Location = new System.Drawing.Point(88, 110);
			this.textBoxAppName.Width = 200;
			this.textBoxAppName.Text = "FDC3 Home";

			// FDC3 Find Intent
			this.labelFindIntent.Location = new System.Drawing.Point(20, 148);
			this.labelFindIntent.Text = "FDC3 Find Intent:";
			this.labelFindIntent.Font = new System.Drawing.Font(this.Font, System.Drawing.FontStyle.Bold);
			this.labelFindIntent.AutoSize = true;

			this.buttonFindIntent.Location = new System.Drawing.Point(20, 172);
			this.buttonFindIntent.Text = "Find Intent";
			this.buttonFindIntent.Width = 90;
			this.buttonFindIntent.Enabled = false;
			this.buttonFindIntent.Click += new System.EventHandler(this.buttonFindIntent_Click);

			this.textBoxFindIntent.Location = new System.Drawing.Point(118, 174);
			this.textBoxFindIntent.Width = 200;
			this.textBoxFindIntent.Text = "ViewChart";

			this.labelFindIntentResult.Location = new System.Drawing.Point(20, 204);
			this.labelFindIntentResult.Size = new System.Drawing.Size(750, 48);
			this.labelFindIntentResult.AutoSize = false;

			// FDC3 Raise Intent
			this.labelRaiseIntent.Location = new System.Drawing.Point(20, 264);
			this.labelRaiseIntent.Text = "FDC3 Raise Intent:";
			this.labelRaiseIntent.Font = new System.Drawing.Font(this.Font, System.Drawing.FontStyle.Bold);
			this.labelRaiseIntent.AutoSize = true;

			this.buttonRaiseIntent.Location = new System.Drawing.Point(20, 288);
			this.buttonRaiseIntent.Text = "Raise Intent";
			this.buttonRaiseIntent.Width = 95;
			this.buttonRaiseIntent.Enabled = false;
			this.buttonRaiseIntent.Click += new System.EventHandler(this.buttonRaiseIntent_Click);

			this.textBoxRaiseIntent.Location = new System.Drawing.Point(123, 290);
			this.textBoxRaiseIntent.Width = 150;
			this.textBoxRaiseIntent.Text = "ViewChart";

			this.textBoxRaiseIntentContext.Location = new System.Drawing.Point(281, 290);
			this.textBoxRaiseIntentContext.Width = 150;
			this.textBoxRaiseIntentContext.Text = "fdc3.instrument";

			this.labelRaiseIntentResult.Location = new System.Drawing.Point(20, 320);
			this.labelRaiseIntentResult.Size = new System.Drawing.Size(750, 40);
			this.labelRaiseIntentResult.AutoSize = false;

			// Workspace
			this.labelWorkspace.Location = new System.Drawing.Point(20, 372);
			this.labelWorkspace.Text = "Workspace:";
			this.labelWorkspace.Font = new System.Drawing.Font(this.Font, System.Drawing.FontStyle.Bold);
			this.labelWorkspace.AutoSize = true;

			this.buttonGetActiveWorkspace.Location = new System.Drawing.Point(20, 396);
			this.buttonGetActiveWorkspace.Text = "Get Active Workspace";
			this.buttonGetActiveWorkspace.Width = 160;
			this.buttonGetActiveWorkspace.Enabled = false;
			this.buttonGetActiveWorkspace.Click += new System.EventHandler(this.buttonGetActiveWorkspace_Click);

			this.labelActiveWorkspaceResult.Location = new System.Drawing.Point(188, 399);
			this.labelActiveWorkspaceResult.AutoSize = true;

			// Form
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Text = "Form1";
			this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

			this.Controls.Add(this.labelStatus);
			this.Controls.Add(this.labelStatusValue);
			this.Controls.Add(this.labelFDC3Open);
			this.Controls.Add(this.buttonOpen);
			this.Controls.Add(this.textBoxAppName);
			this.Controls.Add(this.labelFindIntent);
			this.Controls.Add(this.buttonFindIntent);
			this.Controls.Add(this.textBoxFindIntent);
			this.Controls.Add(this.labelFindIntentResult);
			this.Controls.Add(this.labelRaiseIntent);
			this.Controls.Add(this.buttonRaiseIntent);
			this.Controls.Add(this.textBoxRaiseIntent);
			this.Controls.Add(this.textBoxRaiseIntentContext);
			this.Controls.Add(this.labelRaiseIntentResult);
			this.Controls.Add(this.labelWorkspace);
			this.Controls.Add(this.buttonGetActiveWorkspace);
			this.Controls.Add(this.labelActiveWorkspaceResult);

			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion
	}
}
