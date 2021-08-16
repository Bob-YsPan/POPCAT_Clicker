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
        //需要的變數放這喔
        bool Loop_enabled = false;
        bool NeedReload = false;
        Random rand = new Random();
        int skip_tick = 0;

        //在Cefsharp跑Script
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
        //紅眼偵測Script
        //參考：https://gist.github.com/droppey/9eb2297fcc83ca4aa092711c882700ab
        //參考：https://stackoverflow.com/questions/43392537/cefsharp-execute-javascript-and-get-value
        string Bot_Detect = @"(function() {
        var vue = document.getElementById('app').__vue__;
        // Check if user is marked as bot
        // console.log(vue.bot);
        if(vue.bot){
            return true;
        }
        else{
            return false;
        }
        })();";

        public MainForm()
        {
            var settings = new CefSettings();
            //使用CPU渲染，節省CPU工作運算，並增加連點效率
            settings.CefCommandLineArgs.Add("disable-gpu", "1");
            settings.CefCommandLineArgs.Add("disable-gpu-compositing", "1");
            settings.CefCommandLineArgs.Add("enable-begin-frame-scheduling", "1");
            //關閉點擊聲音
            settings.CefCommandLineArgs.Add("mute-audio", "1");
            //避免產生一大堆log
            settings.LogSeverity = LogSeverity.Disable;
            //避免顯示不正常
            Cef.EnableHighDPISupport();
            Cef.Initialize(settings);
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //如果在連點中，那就解除連點
            if (Loop_enabled)
            {
                chromiumWebBrowser1.ExecuteScriptAsync(Script_UP);
                timer1.Enabled = false;
                NeedReload = true;
            }
            //按下"Go/Reload"按鈕清除Cookie並讀取網址欄網頁
            // Empty Cookies: https://stackoverflow.com/questions/47739697/cefsharp-clearing-cache-cookies-and-browser-data-in-wpf
            Cef.GetGlobalCookieManager().DeleteCookies("", "");
            chromiumWebBrowser1.Load(urlBox1.Text);
        }

        private void click_btn_Click(object sender, EventArgs e)
        {
            //開始按鈕的自動切換
            if (Loop_enabled)
            {
                Loop_enabled = false;
                click_btn.Text = "Click!!!";
            }
            else
            {
                //手動開始把tick歸零
                skip_tick = 0;
                Loop_enabled = true;
                click_btn.Text = "Stop";
            }
            timer1.Enabled = Loop_enabled;
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            //如果有tick要跳過先跳過(避面網頁還是載入不全)
            if (skip_tick < 1)
            {
                try
                {
                    //一個點擊週期
                    //跑點擊的Script
                    chromiumWebBrowser1.ExecuteScriptAsync(Script);
                    //有勾就跑KeyUp指令，貓咪合嘴
                    if (keyUP_check.Checked)
                    {
                        chromiumWebBrowser1.ExecuteScriptAsync(Script_UP);
                    }
                    //非UltraFast點擊模式，隨機於設定數字~該數+100ms抽值點擊
                    if (!(ufast_check.Checked))
                    {
                        int interval_Val = rand.Next((int)interval_num_selector.Value, (int)interval_num_selector.Value + 100);
                        timer1.Interval = interval_Val;
                    }
                    //以下為紅眼偵測機制，遇到刷Cookie重載
                    //該方法在自動Reload後如果不使用Task自動重新刷會當機
                    //使用await解決：https://github.com/cefsharp/CefSharp/wiki/General-Usage#2-how-do-you-call-a-javascript-method-that-returns-a-result
                    //Bot_Detect是執行偵測紅眼指令(JS)，並抓取返回值
                    var response = await chromiumWebBrowser1.EvaluateScriptAsync(Bot_Detect);
                    if ((bool)response.Result)
                    {
                        //返回結果是紅眼就暫停點擊並清Cookies
                        chromiumWebBrowser1.ExecuteScriptAsync(Script_UP);
                        Cef.GetGlobalCookieManager().DeleteCookies("", "");
                        chromiumWebBrowser1.Reload();
                        timer1.Enabled = false;
                        NeedReload = true;
                    }
                }
                //Catch到例外可能是網頁不正確，跳出提示
                catch (System.Exception)
                {
                    Loop_enabled = false;
                    timer1.Enabled = false;
                    click_btn.Text = "Click!!!";
                    MessageBox.Show("請留意網頁是否正確或載入完成^_^", "出錯了...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //跳過一次tick減一次
                skip_tick--;
            }
        }

        private void keyUP_check_CheckedChanged(object sender, EventArgs e)
        {
            //變更KeyUp勾選時就跑KeyUp一次指令，貓咪合嘴
            if (keyUP_check.Checked)
            {
                chromiumWebBrowser1.ExecuteScriptAsyncWhenPageLoaded(Script_UP);
            }
        }

        private void interval_num_selector_ValueChanged(object sender, EventArgs e)
        {
            //設定一個點及週期的長度(Timer物件的Tick週期)
            timer1.Interval = (int)interval_num_selector.Value;
        }

        private void ufast_check_CheckedChanged(object sender, EventArgs e)
        {
            //UltraFast勾選時進入UltraFast模式，用tick能達到的最小值1ms連點!!!!
            //否則就以標準的優閒速度點擊
            if (ufast_check.Checked)
            {
                timer1.Interval = 1;
                interval_num_selector.Enabled = false;
            }
            else
            {
                timer1.Interval = (int)interval_num_selector.Value;
                interval_num_selector.Enabled = true;
            }
        }

        private void chromiumWebBrowser1_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            if (e.Frame.IsMain){
                //當NeedReload Flag(會在重新讀取的行附近變成True)
                //那就等待Browser狀態改變，直到變成讀取完成繼續連點並放下Flag
                if (NeedReload)
                {
                    NeedReload = false;
                    timer1.Enabled = true;
                    //跳過100tick避免載入不全
                    skip_tick = 100;
                }
            }
        }
    }
}
