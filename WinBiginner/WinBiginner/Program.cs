using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace WinBiginner
{
    class Program
    {
        static void Main(string[] args)
        {
            //1 標準出力
            Console.WriteLine("Hello World!");
            /*-------------------------------------------------*/

            //2 標準入力
            string str1 = Console.ReadLine();
            string str2 = Console.ReadLine();
            int num1 = int.Parse(str1);
            int num2 = int.Parse(str2);
            Console.WriteLine(str1 + str2);
            Console.WriteLine(num1 + num2);
            /*-------------------------------------------------*/

            //3 フォームの表示
            /* 参照設定から System.Windows.Forms を参照 */

            // フォームの生成
            Form fm = new Form();

            // ボタンの生成
            Button btn = new Button();
            // ボタンの設定
            btn.Text = "Click Me!";
            btn.Click += (sender, eventArgs) =>
            {
                btn.Text = "Clicked!";
            };
            // ボタンをフォームに追加
            fm.Controls.Add(btn);

            // 生成したフォームでアプリを起動
            Application.Run(fm);
            /*-------------------------------------------------*/

            //4 ファイル操作
            // ファイルパスの指定
            string path = @"C:\Users\\Desktop\test.txt";
            // test.txt ファイルを作成
            Stream stream = File.Create(path);
            // test.txt ファイルに文字を書き込む
            StreamWriter sw = new StreamWriter(stream);
            sw.WriteLine("好きな文字を書き込みます。");
            // 書き込み終了
            sw.Close();
            // 既定のプログラムで test.txt を開く
            Process process = Process.Start(path);
            // 5秒待機
            Thread.Sleep(5000);
            // ファイルを閉じる
            process.Kill();
            // test.txt ファイルを削除
            File.Delete(path);
            /*-------------------------------------------------*/
        }
    }
}
