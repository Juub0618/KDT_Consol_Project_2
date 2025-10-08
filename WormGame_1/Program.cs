using System;

namespace WormGame_1
{
    //메인문
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Worm Game"; //CMD 네임
            Console.CursorVisible = false; //커서 숨기기
            
            Display display = new Display();
            display.ShowTitle();
        }
    }
}