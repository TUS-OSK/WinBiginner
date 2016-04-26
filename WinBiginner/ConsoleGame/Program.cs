using System;
using System.Threading;

namespace ConsoleGame
{
    class Program
    {
        volatile static bool _keyReaded = true;
        private static ConsoleKeyInfo _keyInfo;

        static void Main()
        {
            // 画面の領域
            int width = 100;
            int height = 30;

            // データの確保
            char[,] map = new char[height, width];
            int top = height / 2;
            int right = width / 2;

            // 別スレッドで入力待機
            ThreadPool.QueueUserWorkItem(MyHandler, null);  
            while (true)
            {        
                // 入力があった場合
                if (_keyReaded)
                {
                    if (_keyInfo.Key == ConsoleKey.UpArrow && top > 0)
                        top--;
                    if (_keyInfo.Key == ConsoleKey.DownArrow && top < height - 1)
                        top++;
                    if (_keyInfo.Key == ConsoleKey.RightArrow && right < width - 1)
                        right++;
                    if (_keyInfo.Key == ConsoleKey.LeftArrow && right > 0)
                        right--;
                    _keyReaded = false;
                }

                // マップ生成
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        map[i, j] = ' ';
                    }
                }
                map[top, right] = '○';

                // マップを文字列に
                var str = "";
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        str += map[i, j];
                    }
                    str += "\n";
                }

                // コンソールをクリア
                Console.Clear();
                // 描画
                Console.Write(str);
                // 0.1秒待機
                Thread.Sleep(100);
            }
        }

        static void MyHandler(object userState)
        {
            _keyInfo = Console.ReadKey(true);
            _keyReaded = true;
            ThreadPool.QueueUserWorkItem(MyHandler, null);  
        }
    }
}
