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
using CefSharp.DevTools;
using CefSharp.WinForms;

namespace POP_Clicker
{
    public partial class MainForm : Form
    {
        //需要的變數放這喔
        bool Loop_enabled = false;
        bool NeedReload = false;
        //Ultra模式第一次跑的提示
        bool Ultra_first_launch = true;
        Random rand = new Random();
        int skip_tick = 0;
        //計算程式跑幾次(點幾下)
        decimal click_count = 0;
        //計算點擊量
        decimal startpop = 0;
        decimal stoppop = 0;

        //在Cefsharp跑Script
        //參考：https://gist.github.com/DaWe35/0febd8b058e4476967d12675a622c989
        string Script = @"
                var event = new KeyboardEvent('keydown', {
	                key: 'g',
	                ctrlKey: true
                });
                document.dispatchEvent(event);
                ";
        //用vue得到一些關鍵變數
        //直接參考大神令XD：https://gist.github.com/droppey/9eb2297fcc83ca4aa092711c882700ab
        //參考：https://stackoverflow.com/questions/43392537/cefsharp-execute-javascript-and-get-value
        //0 = bot
        //1 = accumulator
        //2 = sequential_max_pops
        private string get_vue_code(byte type)
        {
            string get_element = "";
            switch (type)
            {
                case 0:
                    get_element = "vue.bot";
                    break;
                case 1:
                    get_element = "vue.accumulator";
                    break;
                case 2:
                    get_element = "vue.sequential_max_pops";
                    break;
                default:
                    get_element = "";
                    break;
            }
            string get_vue = @"(function() {
                    var vue = document.getElementById('app').__vue__;
                    return " + get_element + @";
                    })();";
            return get_vue;
        }

        //用vue設定一些關鍵參數
        //用一個method必較容易
        //0 = sequential_max_pops
        //1 = accumulator
        //2 = open(mouth)
        private void set_vue(byte type, int value)
        {
            string value_name = "";
            switch (type)
            {
                case 0:
                    value_name = "sequential_max_pops";
                    break;
                case 1:
                    value_name = "accumulator";
                    break;
                default:
                    Console.WriteLine("Function not correct!!!");
                    break;

            }
            string set_vue = @"(function() {
                var vue = document.getElementById('app').__vue__;
                vue." + value_name + " = " + value.ToString() + @"
                })();";
            chromiumWebBrowser1.ExecuteScriptAsync(set_vue);
        }
        private void set_vue(byte type, bool value)
        {
            string value_name = "";
            switch (type)
            {
                case 2:
                    value_name = "open";
                    break;
                default:
                    Console.WriteLine("Function not correct!!!");
                    break;

            }
            string set_vue = @"(function() {
                var vue = document.getElementById('app').__vue__;
                vue." + value_name + " = " + value.ToString() + @"
                })();";
            chromiumWebBrowser1.ExecuteScriptAsync(set_vue);
        }

        //KeyUp的部分
        string Script_UP = @"
                var event_up = new KeyboardEvent('keyup', {
	                key: 'g',
	                ctrlKey: true
                });
                document.dispatchEvent(event_up);
                ";
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
                rate_timer.Enabled = false;
                NeedReload = true;
                Ultra_first_launch = true;
            }
            //按下"Go/Reload"按鈕清除Cookie並讀取網址欄網頁
            // Empty Cookies: https://stackoverflow.com/questions/47739697/cefsharp-clearing-cache-cookies-and-browser-data-in-wpf
            Cef.GetGlobalCookieManager().DeleteCookies("", "");
            chromiumWebBrowser1.Load(urlBox1.Text);
            click_count = 0;
            rate_label.Text = 0.ToString();
            rate_label.ForeColor = Color.Black;
            count_num_label.Text = click_count.ToString();
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
                //還有一些變數的初始值
                skip_tick = 0;
                rate_label.ForeColor = Color.Black;
                Loop_enabled = true;
                click_btn.Text = "Stop";
                //Ufast不適用rate計算，直接設定成800
                if (!(ufast_check.Checked))
                {
                    rate_timer.Enabled = true;
                    startpop = click_count;
                    stoppop = click_count;
                }
                else
                {
                    rate_label.Text = 800.ToString();
                }
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
                    //非UltraFast點擊模式，隨機於設定數字~該數+100ms抽值點擊
                    //UltraFast模式會在JS內點600下後才偵測紅眼
                    if (ufast_check.Checked)
                    {
                        if (Ultra_first_launch)
                        {
                            click_count = 0;
                            chromiumWebBrowser1.ExecuteScriptAsync(Script);
                            chromiumWebBrowser1.ExecuteScriptAsync(Script_UP);
                            Ultra_first_launch = false;
                        }
                        rate_timer.Enabled = false;
                        var acc_result = await chromiumWebBrowser1.EvaluateScriptAsync(get_vue_code(1));
                        if ((int)acc_result.Result == 0)
                        {
                            click_count += 800;
                            chromiumWebBrowser1.ExecuteScriptAsync(Script);
                            chromiumWebBrowser1.ExecuteScriptAsync(Script_UP);
                        }
                        set_vue(0, 0);
                        set_vue(1, 800);
                    }
                    else
                    {
                        //跑點擊的Script
                        chromiumWebBrowser1.ExecuteScriptAsync(Script);
                        ////隨機抽一個點擊間隔(禁用，改成Rate計算方式)
                        //int interval_Val = rand.Next((int)interval_num_selector.Value, (int)interval_num_selector.Value + 100);
                        //timer1.Interval = interval_Val;
                        click_count++;
                    }
                    //以下為紅眼偵測機制，遇到刷Cookie重載
                    //該方法在自動Reload後如果不使用Task自動重新刷會當機
                    //使用await解決：https://github.com/cefsharp/CefSharp/wiki/General-Usage#2-how-do-you-call-a-javascript-method-that-returns-a-result
                    var bot_result = await chromiumWebBrowser1.EvaluateScriptAsync(get_vue_code(0));
                    //Console.WriteLine("PA");
                    //如果沒有資料預設為False
                    bool bot_bool = false;
                    try
                    {
                        bot_bool = (bool)bot_result.Result;
                    }
                    catch (System.InvalidCastException)
                    {
                        Console.WriteLine("WARNING:無法讀取BOT狀態");
                        bot_bool = false;
                    }
                    catch (System.NullReferenceException)
                    {
                        Console.WriteLine("WARNING:無法讀取BOT狀態");
                        bot_bool = false;
                    }
                    if (bot_bool)
                    {
                        //有勾就跑KeyUp指令，貓咪合嘴
                        if (keyUP_check.Checked)
                        {
                            chromiumWebBrowser1.ExecuteScriptAsync(Script_UP);
                        }
                        //返回結果是紅眼就暫停點擊並清Cookies
                        chromiumWebBrowser1.ExecuteScriptAsync(Script_UP);
                        Cef.GetGlobalCookieManager().DeleteCookies("", "");
                        chromiumWebBrowser1.Reload();
                        timer1.Enabled = false;
                        rate_timer.Enabled = false;
                        NeedReload = true;
                        Ultra_first_launch = true;
                    }
                    //必須用invoke的方式否則會例外
                    BeginInvoke(new Action(() =>
                    {
                        //將程式執行次數顯示出來
                        count_num_label.Text = click_count.ToString();
                    }));
                    //Console.WriteLine("PB");
                }
                //Catch到例外可能是網頁不正確，跳出提示
                catch (System.Exception)
                {
                    Loop_enabled = false;
                    timer1.Enabled = false;
                    rate_timer.Enabled = false;
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
            //UltraFast勾選時進入UltraFast模式，使用Script進行模擬點擊!!!!
            //否則就以標準的優閒速度點擊
            if (ufast_check.Checked)
            {
                if (Loop_enabled)
                {
                    //突然進入Ultra模式，Rate要是固定值(非開始階段不行)
                    //ClickCount要歸零，之前點的不算
                    rate_label.Text = 800.ToString();
                    click_count = 0;
                }
                MessageBox.Show("請勿亂點擊貓貓影響程式計算正確性^_^", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                timer1.Interval = 500;
                interval_num_selector.Enabled = false;
                keyUP_check.Enabled = false;
            }
            else
            {
                rate_label.Text = 0.ToString();
                set_vue(0, 0);
                set_vue(1, 0);
                timer1.Interval = (int)interval_num_selector.Value;
                interval_num_selector.Enabled = true;
                keyUP_check.Enabled = true;
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
                    rate_timer.Enabled = false;
                    //Reload網頁需要跑第一次執行的東西
                    Ultra_first_launch = true;
                }
                //剛載完啟動點擊次數timer，Ultrafast模式不能用
                if (!(ufast_check.Checked))
                {
                    startpop = click_count;
                    stoppop = click_count;
                    rate_timer.Enabled = true;
                }
                else
                    //否則載入完要把pop rate調成800，準備跑Script
                    rate_label.Text = 800.ToString();
            }
        }

        private void count_label_Click(object sender, EventArgs e)
        {
            //隱藏功能？打開DevTools
            chromiumWebBrowser1.ShowDevTools();
        }

        private void rate_timer_Tick(object sender, EventArgs e)
        {
            stoppop = click_count;
            decimal rate = stoppop - startpop;
            //點擊率上色，POPCAT 800，POPASS 1000
            if (rate > 1000)
                rate_label.ForeColor = Color.Purple;
            else if (rate > 800)
                rate_label.ForeColor = Color.Red;
            else
                rate_label.ForeColor = Color.Black;
            //必須用invoke的方式否則會例外
            BeginInvoke(new Action(() =>
            {
                //將點擊率呈現出來
                rate_label.Text = rate.ToString();
            }));
            startpop = click_count;
        }
    }
}
