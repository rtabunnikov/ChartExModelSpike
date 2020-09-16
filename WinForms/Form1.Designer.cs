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
            this.butTreemap = new System.Windows.Forms.Button();
            this.butPareto = new System.Windows.Forms.Button();
            this.butHistogram = new System.Windows.Forms.Button();
            this.butFunnel = new System.Windows.Forms.Button();
            this.butBoxWhisker = new System.Windows.Forms.Button();
            this.butWaterfall = new System.Windows.Forms.Button();
            this.viewPanel = new System.Windows.Forms.Panel();
            this.butSunburst = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.butSunburst);
            this.panel1.Controls.Add(this.butTreemap);
            this.panel1.Controls.Add(this.butPareto);
            this.panel1.Controls.Add(this.butHistogram);
            this.panel1.Controls.Add(this.butFunnel);
            this.panel1.Controls.Add(this.butBoxWhisker);
            this.panel1.Controls.Add(this.butWaterfall);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 605);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(964, 46);
            this.panel1.TabIndex = 0;
            // 
            // butTreemap
            // 
            this.butTreemap.Location = new System.Drawing.Point(417, 11);
            this.butTreemap.Name = "butTreemap";
            this.butTreemap.Size = new System.Drawing.Size(75, 23);
            this.butTreemap.TabIndex = 5;
            this.butTreemap.Text = "Treemap";
            this.butTreemap.UseVisualStyleBackColor = true;
            this.butTreemap.Click += new System.EventHandler(this.butTreemap_Click);
            // 
            // butPareto
            // 
            this.butPareto.Location = new System.Drawing.Point(336, 11);
            this.butPareto.Name = "butPareto";
            this.butPareto.Size = new System.Drawing.Size(75, 23);
            this.butPareto.TabIndex = 4;
            this.butPareto.Text = "Pareto";
            this.butPareto.UseVisualStyleBackColor = true;
            this.butPareto.Click += new System.EventHandler(this.butPareto_Click);
            // 
            // butHistogram
            // 
            this.butHistogram.Location = new System.Drawing.Point(255, 11);
            this.butHistogram.Name = "butHistogram";
            this.butHistogram.Size = new System.Drawing.Size(75, 23);
            this.butHistogram.TabIndex = 3;
            this.butHistogram.Text = "Histogram";
            this.butHistogram.UseVisualStyleBackColor = true;
            this.butHistogram.Click += new System.EventHandler(this.butHistogram_Click);
            // 
            // butFunnel
            // 
            this.butFunnel.Location = new System.Drawing.Point(174, 11);
            this.butFunnel.Name = "butFunnel";
            this.butFunnel.Size = new System.Drawing.Size(75, 23);
            this.butFunnel.TabIndex = 2;
            this.butFunnel.Text = "Funnel";
            this.butFunnel.UseVisualStyleBackColor = true;
            this.butFunnel.Click += new System.EventHandler(this.butFunnel_Click);
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
            // butSunburst
            // 
            this.butSunburst.Location = new System.Drawing.Point(498, 11);
            this.butSunburst.Name = "butSunburst";
            this.butSunburst.Size = new System.Drawing.Size(75, 23);
            this.butSunburst.TabIndex = 6;
            this.butSunburst.Text = "Sunburst";
            this.butSunburst.UseVisualStyleBackColor = true;
            this.butSunburst.Click += new System.EventHandler(this.butSunburst_Click);
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
        private System.Windows.Forms.Button butFunnel;
        private System.Windows.Forms.Button butHistogram;
        private System.Windows.Forms.Button butPareto;
        private System.Windows.Forms.Button butTreemap;
        private System.Windows.Forms.Button butSunburst;
    }
}

