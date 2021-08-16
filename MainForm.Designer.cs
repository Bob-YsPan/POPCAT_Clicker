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
            this.chromiumWebBrowser1 = new CefSharp.WinForms.ChromiumWebBrowser();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.interval_num_selector)).BeginInit();
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
            this.splitContainer1.Size = new System.Drawing.Size(800, 707);
            this.splitContainer1.SplitterDistance = 32;
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
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(800, 32);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // urlBox1
            // 
            this.urlBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.urlBox1.Location = new System.Drawing.Point(3, 3);
            this.urlBox1.Name = "urlBox1";
            this.urlBox1.Size = new System.Drawing.Size(275, 25);
            this.urlBox1.TabIndex = 1;
            this.urlBox1.Text = "https://popcat.click";
            // 
            // go_btn
            // 
            this.go_btn.Location = new System.Drawing.Point(284, 3);
            this.go_btn.Name = "go_btn";
            this.go_btn.Size = new System.Drawing.Size(95, 23);
            this.go_btn.TabIndex = 0;
            this.go_btn.Text = "Go / Reload";
            this.go_btn.UseVisualStyleBackColor = true;
            this.go_btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // click_btn
            // 
            this.click_btn.Location = new System.Drawing.Point(385, 3);
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
            this.keyUP_check.Location = new System.Drawing.Point(466, 3);
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
            this.ufast_check.Location = new System.Drawing.Point(541, 3);
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
            this.interval_num_selector.Location = new System.Drawing.Point(628, 3);
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
            10,
            0,
            0,
            0});
            this.interval_num_selector.ValueChanged += new System.EventHandler(this.interval_num_selector_ValueChanged);
            // 
            // label_ms
            // 
            this.label_ms.AutoSize = true;
            this.label_ms.Dock = System.Windows.Forms.DockStyle.Left;
            this.label_ms.Location = new System.Drawing.Point(693, 0);
            this.label_ms.Name = "label_ms";
            this.label_ms.Size = new System.Drawing.Size(76, 29);
            this.label_ms.TabIndex = 5;
            this.label_ms.Text = "ms per click";
            this.label_ms.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chromiumWebBrowser1
            // 
            this.chromiumWebBrowser1.ActivateBrowserOnCreation = false;
// TODO: 無法產生 '' 的程式碼 (原因為發生例外狀況 '無效的基本類型: System.IntPtr。請考慮使用 CodeObjectCreateExpression。')。
            this.chromiumWebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chromiumWebBrowser1.Location = new System.Drawing.Point(0, 0);
            this.chromiumWebBrowser1.Name = "chromiumWebBrowser1";
            this.chromiumWebBrowser1.Size = new System.Drawing.Size(800, 671);
            this.chromiumWebBrowser1.TabIndex = 0;
            this.chromiumWebBrowser1.FrameLoadEnd += new System.EventHandler<CefSharp.FrameLoadEndEventArgs>(this.chromiumWebBrowser1_FrameLoadEnd);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 707);
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
    }
}

