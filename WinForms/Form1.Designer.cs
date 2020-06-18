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
            this.butHistogram = new System.Windows.Forms.Button();
            this.butFunnel = new System.Windows.Forms.Button();
            this.butBoxWhisker = new System.Windows.Forms.Button();
            this.butWaterfall = new System.Windows.Forms.Button();
            this.viewPanel = new System.Windows.Forms.Panel();
            this.butPareto = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.butPareto);
            this.panel1.Controls.Add(this.butHistogram);
            this.panel1.Controls.Add(this.butFunnel);
            this.panel1.Controls.Add(this.butBoxWhisker);
            this.panel1.Controls.Add(this.butWaterfall);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 744);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1285, 57);
            this.panel1.TabIndex = 0;
            // 
            // butHistogram
            // 
            this.butHistogram.Location = new System.Drawing.Point(340, 14);
            this.butHistogram.Margin = new System.Windows.Forms.Padding(4);
            this.butHistogram.Name = "butHistogram";
            this.butHistogram.Size = new System.Drawing.Size(100, 28);
            this.butHistogram.TabIndex = 3;
            this.butHistogram.Text = "Histogram";
            this.butHistogram.UseVisualStyleBackColor = true;
            this.butHistogram.Click += new System.EventHandler(this.butHistogram_Click);
            // 
            // butFunnel
            // 
            this.butFunnel.Location = new System.Drawing.Point(232, 14);
            this.butFunnel.Margin = new System.Windows.Forms.Padding(4);
            this.butFunnel.Name = "butFunnel";
            this.butFunnel.Size = new System.Drawing.Size(100, 28);
            this.butFunnel.TabIndex = 2;
            this.butFunnel.Text = "Funnel";
            this.butFunnel.UseVisualStyleBackColor = true;
            this.butFunnel.Click += new System.EventHandler(this.butFunnel_Click);
            // 
            // butBoxWhisker
            // 
            this.butBoxWhisker.Location = new System.Drawing.Point(124, 14);
            this.butBoxWhisker.Margin = new System.Windows.Forms.Padding(4);
            this.butBoxWhisker.Name = "butBoxWhisker";
            this.butBoxWhisker.Size = new System.Drawing.Size(100, 28);
            this.butBoxWhisker.TabIndex = 1;
            this.butBoxWhisker.Text = "BoxWhisker";
            this.butBoxWhisker.UseVisualStyleBackColor = true;
            this.butBoxWhisker.Click += new System.EventHandler(this.butBoxWhisker_Click);
            // 
            // butWaterfall
            // 
            this.butWaterfall.Location = new System.Drawing.Point(16, 14);
            this.butWaterfall.Margin = new System.Windows.Forms.Padding(4);
            this.butWaterfall.Name = "butWaterfall";
            this.butWaterfall.Size = new System.Drawing.Size(100, 28);
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
            this.viewPanel.Margin = new System.Windows.Forms.Padding(4);
            this.viewPanel.Name = "viewPanel";
            this.viewPanel.Size = new System.Drawing.Size(1285, 744);
            this.viewPanel.TabIndex = 1;
            this.viewPanel.SizeChanged += new System.EventHandler(this.View_SizeChanged);
            this.viewPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.View_Paint);
            // 
            // butPareto
            // 
            this.butPareto.Location = new System.Drawing.Point(448, 14);
            this.butPareto.Margin = new System.Windows.Forms.Padding(4);
            this.butPareto.Name = "butPareto";
            this.butPareto.Size = new System.Drawing.Size(100, 28);
            this.butPareto.TabIndex = 4;
            this.butPareto.Text = "Pareto";
            this.butPareto.UseVisualStyleBackColor = true;
            this.butPareto.Click += new System.EventHandler(this.butPareto_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1285, 801);
            this.Controls.Add(this.viewPanel);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
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
    }
}

