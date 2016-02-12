# WcfServiceAndClientDemo
透過Windows Service提供WCF Service給外界使用，此範例專案參考以下說明文件

https://msdn.microsoft.com/zh-tw/library/dd456779(v=vs.110).aspx WCF說明文件
https://msdn.microsoft.com/zh-tw/library/d56de412(v=vs.110).aspx Windows Service說明文件

此範例WCF Service使用Windows Process Activation Service當作註冊與訊息溝通的基礎架構，另一種基礎架構是使用IIS，在此範例並沒有展示。

## 目錄結構
- WcfServiceLibrary1：實作WCFService，提供加減乘除的服務
- WcfConsoleHost：用一般的Console Application來當作WCF Service的Host
- WcfWindowsServiceHost：用Windows Service來當作WCF Service的Host
- WcfConsoleClient：呼叫WCF Service的Console Client
- WcfWpfClient：呼叫WCF Service的WPF Client

## 跑範例所需環境
1. Windows 7
2. Visual Studio 2015，以下簡稱VS2015
3. Windows 7必須啟用Windows Process Activation Service，在新增移除程式頁面可找到設定

## 執行步驟
1. 用系統管理員權限執行VS2015，打開WcfServiceAndClientDemo.sln
2. 執行Build Solution，把所有Solution底下的專案都建置完成。
3. 用系統管理員權限執行Developer Command Prompt for VS2015，到有開發工具的Console底下
4. 註冊Windows Service
```
cd WcfServiceAndClientDemo\WcfWindowsServiceHost\bin\Debug 
\WcfServiceAndClientDemo>installutil WcfWindowsServiceHost.exe
```
5. 此時Windows Service已經啟用，可到"控制台\所有控制台項目\系統管理工具\服務"下看看是否有WCF Host Service，並且啟動它
6. 用瀏覽器連http://localhost:8000/GettingStarted/，如果有說明頁面表示WCF Host Service作動中
7. 執行WcfConsoleClient或是WcfWpfClient來測試WCF Service是否提供加減乘除功能
8. 到"控制台\所有控制台項目\系統管理工具\事件檢視器\應用程式及服務記錄檔\HostService1Log"看看EventLog有沒有被寫出來。
9. WPF Service就常駐於系統中，重新開機也會自行啟動。
10. 測試完畢，移除註冊的Windows Service
```
\WcfServiceAndClientDemo>installutil /u WcfWindowsServiceHost.exe
```