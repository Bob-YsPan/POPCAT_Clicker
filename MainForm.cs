using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace POP_Clicker
{
    public partial class MainForm : Form
    {
        bool Loop_enabled = false;
        //參考：https://gist.github.com/DaWe35/0febd8b058e4476967d12675a622c989
        string Script = @"
                var event = new KeyboardEvent('keydown', {
	                key: 'g',
	                ctrlKey: true
                });
                document.dispatchEvent(event);
                ";
        string Script_UP = @"
                var event_up = new KeyboardEvent('keyup', {
	                key: 'g',
	                ctrlKey: true
                });
                document.dispatchEvent(event_up);
                ";

        public MainForm()
        {
            Cef.EnableHighDPISupport();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chromiumWebBrowser1.Load(urlBox1.Text);
        }

        private void click_btn_Click(object sender, EventArgs e)
        {
            if (Loop_enabled)
            {
                Loop_enabled = false;
                click_btn.Text = "Click!!!";
            }
            else
            {
                Loop_enabled = true;
                click_btn.Text = "Stop";
            }
            timer1.Enabled = Loop_enabled;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            chromiumWebBrowser1.ExecuteScriptAsyncWhenPageLoaded(Script);
            if (keyUP_check.Checked)
            {
                chromiumWebBrowser1.ExecuteScriptAsyncWhenPageLoaded(Script_UP);
            }
        }

        private void keyUP_check_CheckedChanged(object sender, EventArgs e)
        {
            if (keyUP_check.Checked)
            {
                chromiumWebBrowser1.ExecuteScriptAsyncWhenPageLoaded(Script_UP);
            }
        }

        private void interval_num_selector_ValueChanged(object sender, EventArgs e)
        {
            timer1.Interval = (int)interval_num_selector.Value;
        }
    }
}
