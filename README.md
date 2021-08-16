# POPCAT 高速點擊器
程式使用Cefsharp，自帶Google Chrome

(v1.5)
![Screenshot](CAP4.png)

* 按下Go載入網頁
* 按下Click!!!開始高速點擊 ~~(10ms一下)~~ (預設10ms(可設定) ~ 110ms(10ms + 100)之間取亂數點擊(v1.3修改))
* KeyUp勾選欄可以發出KeyUp指令(沒有勾選只有KeyDown)，有了這個指令貓的嘴巴會高速開合
* 調整 ms per click 的數字可以改變點擊頻率 (V1.1增加)
* 增加紅眼自動重置機制(v1.5 增加)

(純屬程式練習，大家還是乖乖手點貢獻流量比較好吧...XD)

*注意：源碼不包含CefSharp Nuget Packages，請按照Packages.config底下之資料進行安裝*

# 歷代更新截圖

v1.0 截圖：
![Screenshot](CAP.png)

v1.1 截圖：
![Screenshot](CAP2.png)

v1.3 截圖(增加防作弊機制，可行性還沒驗證)：
四個實體跑了6個多小時後的狀態
![Screenshot](CAP3.png)
