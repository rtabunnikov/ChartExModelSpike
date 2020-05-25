namespace ChartExModelSpike {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.panel1 = new System.Windows.Forms.Panel();
            this.butBoxWhisker = new System.Windows.Forms.Button();
            this.butWaterfall = new System.Windows.Forms.Button();
            this.viewPanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.butBoxWhisker);
            this.panel1.Controls.Add(this.butWaterfall);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 605);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(964, 46);
            this.panel1.TabIndex = 0;
            // 
            // butBoxWhisker
            // 
            this.butBoxWhisker.Location = new System.Drawing.Point(93, 11);
            this.butBoxWhisker.Name = "butBoxWhisker";
            this.butBoxWhisker.Size = new System.Drawing.Size(75, 23);
            this.butBoxWhisker.TabIndex = 1;
            this.butBoxWhisker.Text = "BoxWhisker";
            this.butBoxWhisker.UseVisualStyleBackColor = true;
            this.butBoxWhisker.Click += new System.EventHandler(this.butBoxWhisker_Click);
            // 
            // butWaterfall
            // 
            this.butWaterfall.Location = new System.Drawing.Point(12, 11);
            this.butWaterfall.Name = "butWaterfall";
            this.butWaterfall.Size = new System.Drawing.Size(75, 23);
            this.butWaterfall.TabIndex = 0;
            this.butWaterfall.Text = "Waterfall";
            this.butWaterfall.UseVisualStyleBackColor = true;
            this.butWaterfall.Click += new System.EventHandler(this.butWaterfall_Click);
            // 
            // viewPanel
            // 
            this.viewPanel.BackColor = System.Drawing.Color.White;
            this.viewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewPanel.Location = new System.Drawing.Point(0, 0);
            this.viewPanel.Name = "viewPanel";
            this.viewPanel.Size = new System.Drawing.Size(964, 605);
            this.viewPanel.TabIndex = 1;
            this.viewPanel.SizeChanged += new System.EventHandler(this.View_SizeChanged);
            this.viewPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.View_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 651);
            this.Controls.Add(this.viewPanel);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChartEx - Common Charts Model spike (WinForms)";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel viewPanel;
        private System.Windows.Forms.Button butWaterfall;
        private System.Windows.Forms.Button butBoxWhisker;
    }
}

