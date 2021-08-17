namespace POP_Clicker
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.urlBox1 = new System.Windows.Forms.TextBox();
            this.go_btn = new System.Windows.Forms.Button();
            this.click_btn = new System.Windows.Forms.Button();
            this.keyUP_check = new System.Windows.Forms.CheckBox();
            this.ufast_check = new System.Windows.Forms.CheckBox();
            this.interval_num_selector = new System.Windows.Forms.NumericUpDown();
            this.label_ms = new System.Windows.Forms.Label();
            this.count_label = new System.Windows.Forms.Label();
            this.count_num_label = new System.Windows.Forms.Label();
            this.border_label = new System.Windows.Forms.Label();
            this.rate_label = new System.Windows.Forms.Label();
            this.rate_ext = new System.Windows.Forms.Label();
            this.botfallback = new System.Windows.Forms.Label();
            this.bot_count_selector = new System.Windows.Forms.NumericUpDown();
            this.chromiumWebBrowser1 = new CefSharp.WinForms.ChromiumWebBrowser();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.rate_timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.interval_num_selector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bot_count_selector)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.chromiumWebBrowser1);
            this.splitContainer1.Size = new System.Drawing.Size(1006, 553);
            this.splitContainer1.SplitterDistance = 36;
            this.splitContainer1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.urlBox1);
            this.flowLayoutPanel1.Controls.Add(this.go_btn);
            this.flowLayoutPanel1.Controls.Add(this.click_btn);
            this.flowLayoutPanel1.Controls.Add(this.keyUP_check);
            this.flowLayoutPanel1.Controls.Add(this.ufast_check);
            this.flowLayoutPanel1.Controls.Add(this.interval_num_selector);
            this.flowLayoutPanel1.Controls.Add(this.label_ms);
            this.flowLayoutPanel1.Controls.Add(this.count_label);
            this.flowLayoutPanel1.Controls.Add(this.count_num_label);
            this.flowLayoutPanel1.Controls.Add(this.border_label);
            this.flowLayoutPanel1.Controls.Add(this.rate_label);
            this.flowLayoutPanel1.Controls.Add(this.rate_ext);
            this.flowLayoutPanel1.Controls.Add(this.botfallback);
            this.flowLayoutPanel1.Controls.Add(this.bot_count_selector);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1006, 36);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // urlBox1
            // 
            this.urlBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.urlBox1.Location = new System.Drawing.Point(3, 3);
            this.urlBox1.Name = "urlBox1";
            this.urlBox1.Size = new System.Drawing.Size(145, 25);
            this.urlBox1.TabIndex = 1;
            this.urlBox1.Text = "https://popcat.click";
            // 
            // go_btn
            // 
            this.go_btn.Location = new System.Drawing.Point(154, 3);
            this.go_btn.Name = "go_btn";
            this.go_btn.Size = new System.Drawing.Size(95, 23);
            this.go_btn.TabIndex = 0;
            this.go_btn.Text = "Go / Reload";
            this.go_btn.UseVisualStyleBackColor = true;
            this.go_btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // click_btn
            // 
            this.click_btn.Location = new System.Drawing.Point(255, 3);
            this.click_btn.Name = "click_btn";
            this.click_btn.Size = new System.Drawing.Size(75, 23);
            this.click_btn.TabIndex = 2;
            this.click_btn.Text = "Click!!!";
            this.click_btn.UseVisualStyleBackColor = true;
            this.click_btn.Click += new System.EventHandler(this.click_btn_Click);
            // 
            // keyUP_check
            // 
            this.keyUP_check.AutoSize = true;
            this.keyUP_check.Dock = System.Windows.Forms.DockStyle.Left;
            this.keyUP_check.Location = new System.Drawing.Point(336, 3);
            this.keyUP_check.Name = "keyUP_check";
            this.keyUP_check.Size = new System.Drawing.Size(69, 23);
            this.keyUP_check.TabIndex = 3;
            this.keyUP_check.Text = "KeyUp";
            this.keyUP_check.UseVisualStyleBackColor = true;
            this.keyUP_check.CheckedChanged += new System.EventHandler(this.keyUP_check_CheckedChanged);
            // 
            // ufast_check
            // 
            this.ufast_check.AutoSize = true;
            this.ufast_check.Dock = System.Windows.Forms.DockStyle.Left;
            this.ufast_check.Location = new System.Drawing.Point(411, 3);
            this.ufast_check.Name = "ufast_check";
            this.ufast_check.Size = new System.Drawing.Size(81, 23);
            this.ufast_check.TabIndex = 6;
            this.ufast_check.Text = "UltraFast";
            this.ufast_check.UseVisualStyleBackColor = true;
            this.ufast_check.CheckedChanged += new System.EventHandler(this.ufast_check_CheckedChanged);
            // 
            // interval_num_selector
            // 
            this.interval_num_selector.Dock = System.Windows.Forms.DockStyle.Left;
            this.interval_num_selector.Location = new System.Drawing.Point(498, 3);
            this.interval_num_selector.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.interval_num_selector.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.interval_num_selector.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.interval_num_selector.Name = "interval_num_selector";
            this.interval_num_selector.Size = new System.Drawing.Size(59, 25);
            this.interval_num_selector.TabIndex = 4;
            this.interval_num_selector.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.interval_num_selector.Value = new decimal(new int[] {
            38,
            0,
            0,
            0});
            this.interval_num_selector.ValueChanged += new System.EventHandler(this.interval_num_selector_ValueChanged);
            // 
            // label_ms
            // 
            this.label_ms.AutoSize = true;
            this.label_ms.Dock = System.Windows.Forms.DockStyle.Left;
            this.label_ms.Location = new System.Drawing.Point(557, 0);
            this.label_ms.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.label_ms.Name = "label_ms";
            this.label_ms.Size = new System.Drawing.Size(76, 29);
            this.label_ms.TabIndex = 5;
            this.label_ms.Text = "ms per click";
            this.label_ms.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // count_label
            // 
            this.count_label.AutoSize = true;
            this.count_label.Dock = System.Windows.Forms.DockStyle.Left;
            this.count_label.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.count_label.Location = new System.Drawing.Point(639, 0);
            this.count_label.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.count_label.Name = "count_label";
            this.count_label.Size = new System.Drawing.Size(51, 29);
            this.count_label.TabIndex = 7;
            this.count_label.Text = "Count:";
            this.count_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.count_label.Click += new System.EventHandler(this.count_label_Click);
            // 
            // count_num_label
            // 
            this.count_num_label.AutoSize = true;
            this.count_num_label.Dock = System.Windows.Forms.DockStyle.Left;
            this.count_num_label.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.count_num_label.Location = new System.Drawing.Point(693, 0);
            this.count_num_label.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.count_num_label.Name = "count_num_label";
            this.count_num_label.Size = new System.Drawing.Size(21, 29);
            this.count_num_label.TabIndex = 8;
            this.count_num_label.Text = "0";
            this.count_num_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // border_label
            // 
            this.border_label.AutoSize = true;
            this.border_label.Dock = System.Windows.Forms.DockStyle.Left;
            this.border_label.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.border_label.Location = new System.Drawing.Point(714, 0);
            this.border_label.Margin = new System.Windows.Forms.Padding(0);
            this.border_label.Name = "border_label";
            this.border_label.Size = new System.Drawing.Size(21, 29);
            this.border_label.TabIndex = 11;
            this.border_label.Text = "|";
            this.border_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rate_label
            // 
            this.rate_label.AutoSize = true;
            this.rate_label.Dock = System.Windows.Forms.DockStyle.Left;
            this.rate_label.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rate_label.Location = new System.Drawing.Point(738, 0);
            this.rate_label.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.rate_label.Name = "rate_label";
            this.rate_label.Size = new System.Drawing.Size(21, 29);
            this.rate_label.TabIndex = 9;
            this.rate_label.Text = "0";
            this.rate_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rate_ext
            // 
            this.rate_ext.AutoSize = true;
            this.rate_ext.Dock = System.Windows.Forms.DockStyle.Left;
            this.rate_ext.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rate_ext.Location = new System.Drawing.Point(759, 0);
            this.rate_ext.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.rate_ext.Name = "rate_ext";
            this.rate_ext.Size = new System.Drawing.Size(65, 29);
            this.rate_ext.TabIndex = 10;
            this.rate_ext.Text = "Pops/30s";
            this.rate_ext.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // botfallback
            // 
            this.botfallback.AutoSize = true;
            this.botfallback.Dock = System.Windows.Forms.DockStyle.Left;
            this.botfallback.Location = new System.Drawing.Point(830, 0);
            this.botfallback.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.botfallback.Name = "botfallback";
            this.botfallback.Size = new System.Drawing.Size(33, 29);
            this.botfallback.TabIndex = 13;
            this.botfallback.Text = "bot: ";
            this.botfallback.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bot_count_selector
            // 
            this.bot_count_selector.Dock = System.Windows.Forms.DockStyle.Left;
            this.bot_count_selector.Location = new System.Drawing.Point(863, 3);
            this.bot_count_selector.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.bot_count_selector.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.bot_count_selector.Name = "bot_count_selector";
            this.bot_count_selector.Size = new System.Drawing.Size(48, 25);
            this.bot_count_selector.TabIndex = 12;
            this.bot_count_selector.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.bot_count_selector.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // chromiumWebBrowser1
            // 
            this.chromiumWebBrowser1.ActivateBrowserOnCreation = false;
// TODO: 無法產生 '' 的程式碼 (原因為發生例外狀況 '無效的基本類型: System.IntPtr。請考慮使用 CodeObjectCreateExpression。')。
            this.chromiumWebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chromiumWebBrowser1.Location = new System.Drawing.Point(0, 0);
            this.chromiumWebBrowser1.Name = "chromiumWebBrowser1";
            this.chromiumWebBrowser1.Size = new System.Drawing.Size(1006, 513);
            this.chromiumWebBrowser1.TabIndex = 0;
            this.chromiumWebBrowser1.FrameLoadEnd += new System.EventHandler<CefSharp.FrameLoadEndEventArgs>(this.chromiumWebBrowser1_FrameLoadEnd);
            // 
            // timer1
            // 
            this.timer1.Interval = 38;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // rate_timer
            // 
            this.rate_timer.Interval = 30000;
            this.rate_timer.Tick += new System.EventHandler(this.rate_timer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 553);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Click click click";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.interval_num_selector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bot_count_selector)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox urlBox1;
        private System.Windows.Forms.Button go_btn;
        private System.Windows.Forms.Button click_btn;
        private CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox keyUP_check;
        private System.Windows.Forms.NumericUpDown interval_num_selector;
        private System.Windows.Forms.Label label_ms;
        private System.Windows.Forms.CheckBox ufast_check;
        private System.Windows.Forms.Label count_label;
        private System.Windows.Forms.Label count_num_label;
        private System.Windows.Forms.Label rate_label;
        private System.Windows.Forms.Label rate_ext;
        private System.Windows.Forms.Timer rate_timer;
        private System.Windows.Forms.Label border_label;
        private System.Windows.Forms.Label botfallback;
        private System.Windows.Forms.NumericUpDown bot_count_selector;
    }
}

