using System;

namespace WormGame_1
{
    //키입력을 위한 열거형
    public enum Direction { Up, Down, Left, Right }

    //메인문
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Warm Game";
            Console.CursorVisible = false;
            Display display = new Display();
            display.Title();
        }
    }
}