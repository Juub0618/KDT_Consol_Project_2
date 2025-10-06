using System;

namespace WormGame_1
{
    //메인문
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Worm Game"; //CMD 네임
            Console.CursorVisible = false; //
         
            Display display = new Display();
            display.Title();
        }
    }
}