namespace DigitalPulseAnalyzer_Demo
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonSet = new System.Windows.Forms.Button();
            this.button3Run = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.lblRealRate = new System.Windows.Forms.Label();
            this.lblRealRateLabel = new System.Windows.Forms.Label();
            this.lblRealCount = new System.Windows.Forms.Label();
            this.lblRealCountLabel = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.lblRunTimeLabel = new System.Windows.Forms.Label();
            this.lblRunTime = new System.Windows.Forms.Label();
            this.lblDetectorVoltageLabel = new System.Windows.Forms.Label();
            this.lblDetectorVoltage = new System.Windows.Forms.Label();
            this.lblDetectorTemp = new System.Windows.Forms.Label();
            this.lblDetectorTempLabel = new System.Windows.Forms.Label();
            this.lblConnect = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonStop = new System.Windows.Forms.Button();
            this.lblDeadTime = new System.Windows.Forms.Label();
            this.lblDeadTimeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(80, 110);
            this.buttonConnect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(101, 58);
            this.buttonConnect.TabIndex = 0;
            this.buttonConnect.Text = "连接";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonSet
            // 
            this.buttonSet.Location = new System.Drawing.Point(248, 110);
            this.buttonSet.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonSet.Name = "buttonSet";
            this.buttonSet.Size = new System.Drawing.Size(101, 58);
            this.buttonSet.TabIndex = 0;
            this.buttonSet.Text = "设置";
            this.buttonSet.UseVisualStyleBackColor = true;
            this.buttonSet.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3Run
            // 
            this.button3Run.Location = new System.Drawing.Point(423, 110);
            this.button3Run.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button3Run.Name = "button3Run";
            this.button3Run.Size = new System.Drawing.Size(101, 58);
            this.button3Run.TabIndex = 0;
            this.button3Run.Text = "运行";
            this.button3Run.UseVisualStyleBackColor = true;
            this.button3Run.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(715, 110);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(101, 58);
            this.button4.TabIndex = 2;
            this.button4.Text = "清除";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // lblRealRate
            // 
            this.lblRealRate.AutoSize = true;
            this.lblRealRate.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRealRate.Location = new System.Drawing.Point(243, 296);
            this.lblRealRate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRealRate.Name = "lblRealRate";
            this.lblRealRate.Size = new System.Drawing.Size(23, 25);
            this.lblRealRate.TabIndex = 133;
            this.lblRealRate.Text = "0";
            // 
            // lblRealRateLabel
            // 
            this.lblRealRateLabel.AutoSize = true;
            this.lblRealRateLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRealRateLabel.Location = new System.Drawing.Point(75, 296);
            this.lblRealRateLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRealRateLabel.Name = "lblRealRateLabel";
            this.lblRealRateLabel.Size = new System.Drawing.Size(66, 25);
            this.lblRealRateLabel.TabIndex = 128;
            this.lblRealRateLabel.Text = "快成形";
            this.lblRealRateLabel.Click += new System.EventHandler(this.lblRealRateLabel_Click);
            // 
            // lblRealCount
            // 
            this.lblRealCount.AutoSize = true;
            this.lblRealCount.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRealCount.Location = new System.Drawing.Point(243, 256);
            this.lblRealCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRealCount.Name = "lblRealCount";
            this.lblRealCount.Size = new System.Drawing.Size(23, 25);
            this.lblRealCount.TabIndex = 131;
            this.lblRealCount.Text = "0";
            // 
            // lblRealCountLabel
            // 
            this.lblRealCountLabel.AutoSize = true;
            this.lblRealCountLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRealCountLabel.Location = new System.Drawing.Point(75, 256);
            this.lblRealCountLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRealCountLabel.Name = "lblRealCountLabel";
            this.lblRealCountLabel.Size = new System.Drawing.Size(66, 25);
            this.lblRealCountLabel.TabIndex = 126;
            this.lblRealCountLabel.Text = "慢成形";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label33.Location = new System.Drawing.Point(313, 216);
            this.label33.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(23, 25);
            this.label33.TabIndex = 135;
            this.label33.Text = "S";
            // 
            // lblRunTimeLabel
            // 
            this.lblRunTimeLabel.AutoSize = true;
            this.lblRunTimeLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRunTimeLabel.Location = new System.Drawing.Point(75, 216);
            this.lblRunTimeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRunTimeLabel.Name = "lblRunTimeLabel";
            this.lblRunTimeLabel.Size = new System.Drawing.Size(84, 25);
            this.lblRunTimeLabel.TabIndex = 125;
            this.lblRunTimeLabel.Text = "运行时间";
            // 
            // lblRunTime
            // 
            this.lblRunTime.AutoSize = true;
            this.lblRunTime.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRunTime.Location = new System.Drawing.Point(243, 216);
            this.lblRunTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRunTime.Name = "lblRunTime";
            this.lblRunTime.Size = new System.Drawing.Size(61, 25);
            this.lblRunTime.TabIndex = 130;
            this.lblRunTime.Text = "0.000";
            // 
            // lblDetectorVoltageLabel
            // 
            this.lblDetectorVoltageLabel.AutoSize = true;
            this.lblDetectorVoltageLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDetectorVoltageLabel.Location = new System.Drawing.Point(418, 246);
            this.lblDetectorVoltageLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDetectorVoltageLabel.Name = "lblDetectorVoltageLabel";
            this.lblDetectorVoltageLabel.Size = new System.Drawing.Size(102, 25);
            this.lblDetectorVoltageLabel.TabIndex = 145;
            this.lblDetectorVoltageLabel.Text = "探测器高压";
            // 
            // lblDetectorVoltage
            // 
            this.lblDetectorVoltage.AutoSize = true;
            this.lblDetectorVoltage.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDetectorVoltage.Location = new System.Drawing.Point(586, 246);
            this.lblDetectorVoltage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDetectorVoltage.Name = "lblDetectorVoltage";
            this.lblDetectorVoltage.Size = new System.Drawing.Size(61, 25);
            this.lblDetectorVoltage.TabIndex = 147;
            this.lblDetectorVoltage.Text = "0.000";
            // 
            // lblDetectorTemp
            // 
            this.lblDetectorTemp.AutoSize = true;
            this.lblDetectorTemp.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDetectorTemp.Location = new System.Drawing.Point(586, 216);
            this.lblDetectorTemp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDetectorTemp.Name = "lblDetectorTemp";
            this.lblDetectorTemp.Size = new System.Drawing.Size(50, 25);
            this.lblDetectorTemp.TabIndex = 146;
            this.lblDetectorTemp.Text = "0.00";
            // 
            // lblDetectorTempLabel
            // 
            this.lblDetectorTempLabel.AutoSize = true;
            this.lblDetectorTempLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDetectorTempLabel.Location = new System.Drawing.Point(418, 216);
            this.lblDetectorTempLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDetectorTempLabel.Name = "lblDetectorTempLabel";
            this.lblDetectorTempLabel.Size = new System.Drawing.Size(102, 25);
            this.lblDetectorTempLabel.TabIndex = 144;
            this.lblDetectorTempLabel.Text = "探测器温度";
            // 
            // lblConnect
            // 
            this.lblConnect.AutoSize = true;
            this.lblConnect.BackColor = System.Drawing.Color.Transparent;
            this.lblConnect.Location = new System.Drawing.Point(77, 76);
            this.lblConnect.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConnect.Name = "lblConnect";
            this.lblConnect.Size = new System.Drawing.Size(62, 18);
            this.lblConnect.TabIndex = 148;
            this.lblConnect.Text = "未连接";
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(565, 110);
            this.buttonStop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(101, 58);
            this.buttonStop.TabIndex = 149;
            this.buttonStop.Text = "停止";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.button5_Click);
            // 
            // lblDeadTime
            // 
            this.lblDeadTime.AutoSize = true;
            this.lblDeadTime.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDeadTime.Location = new System.Drawing.Point(243, 344);
            this.lblDeadTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDeadTime.Name = "lblDeadTime";
            this.lblDeadTime.Size = new System.Drawing.Size(61, 25);
            this.lblDeadTime.TabIndex = 151;
            this.lblDeadTime.Text = "0.000";
            // 
            // lblDeadTimeLabel
            // 
            this.lblDeadTimeLabel.AutoSize = true;
            this.lblDeadTimeLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDeadTimeLabel.Location = new System.Drawing.Point(72, 344);
            this.lblDeadTimeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDeadTimeLabel.Name = "lblDeadTimeLabel";
            this.lblDeadTimeLabel.Size = new System.Drawing.Size(66, 25);
            this.lblDeadTimeLabel.TabIndex = 150;
            this.lblDeadTimeLabel.Text = "死时间";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 575);
            this.Controls.Add(this.lblDeadTime);
            this.Controls.Add(this.lblDeadTimeLabel);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.lblConnect);
            this.Controls.Add(this.lblDetectorVoltageLabel);
            this.Controls.Add(this.lblDetectorVoltage);
            this.Controls.Add(this.lblDetectorTemp);
            this.Controls.Add(this.lblDetectorTempLabel);
            this.Controls.Add(this.lblRealRate);
            this.Controls.Add(this.lblRealRateLabel);
            this.Controls.Add(this.lblRealCount);
            this.Controls.Add(this.lblRealCountLabel);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.lblRunTimeLabel);
            this.Controls.Add(this.lblRunTime);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3Run);
            this.Controls.Add(this.buttonSet);
            this.Controls.Add(this.buttonConnect);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmMain";
            this.Text = "FrmMain";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonSet;
        private System.Windows.Forms.Button button3Run;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lblRealRate;
        private System.Windows.Forms.Label lblRealRateLabel;
        private System.Windows.Forms.Label lblRealCount;
        private System.Windows.Forms.Label lblRealCountLabel;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label lblRunTimeLabel;
        private System.Windows.Forms.Label lblRunTime;
        private System.Windows.Forms.Label lblDetectorVoltageLabel;
        private System.Windows.Forms.Label lblDetectorVoltage;
        private System.Windows.Forms.Label lblDetectorTemp;
        private System.Windows.Forms.Label lblDetectorTempLabel;
        private System.Windows.Forms.Label lblConnect;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Label lblDeadTime;
        private System.Windows.Forms.Label lblDeadTimeLabel;
    }
}

