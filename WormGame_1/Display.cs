using System;

namespace WormGame_1
{
    //디스플레이 클래스
    class Display
    {
        GamePlay gamePlay = new GamePlay();

        //게임 타이틀 메소드
        public void Title()
        {
            //출력 화면
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("                           ┌───────────────────────────────────────────────────────────┐");
            Console.WriteLine("                           │                                                           │");
            Console.WriteLine("                           │      ■■■     ■■■   ■■■■■■■■■   ■■■■■■■■■■■   ■■■■  ■■■■   │");
            Console.WriteLine("                           │     ■■■■ ■■ ■■■  ■■■     ■■■  ■■■     ■■■   ■■■■■■■■■■    │");
            Console.WriteLine("                           │     ■■■■■■■■■■■  ■■■     ■■■  ■■■     ■■■  ■■■■■■■■■■■    │");
            Console.WriteLine("                           │     ■■■■■■■■■■■  ■■■     ■■■  ■■■■■■■■■    ■■■■ ■■ ■■■    │");
            Console.WriteLine("                           │     ■■■■  ■■■■    ■■■■■■■■■   ■■■    ■■■■■ ■■■     ■■■    │");
            Console.WriteLine("                           │                                                           │");
            Console.WriteLine("                           │       ■■■■■■■■■■    ■■■■■■■    ■■■■  ■■■■   ■■■■■■■■■■    │");
            Console.WriteLine("                           │      ■■■         ■■■    ■■■   ■■■■■■■■■■  ■■■■            │");
            Console.WriteLine("                           │      ■■    ■■■■ ■■■■    ■■■■ ■■■■■■■■■■■  ■■■■■■■■■       │");
            Console.WriteLine("                           │      ■■■    ■■■ ■■■■■■■ ■■■■ ■■■■ ■■ ■■■  ■■■■            │");
            Console.WriteLine("                           │        ■■■■■■■  ■■■■    ■■■■ ■■■     ■■■   ■■■■■■■■■■     │");
            Console.WriteLine("                           │                                                           │");
            Console.WriteLine("                           └───────────────────────────────────────────────────────────┘");
            Console.WriteLine("");
            Console.WriteLine("                                            ┌─────────────────────────┐");
            Console.WriteLine("                                            │  Enter key : Game Start │");
            Console.WriteLine("                                            │                         │");
            Console.WriteLine("                                            │  Enter key :    Exit    │");
            Console.WriteLine("                                            └─────────────────────────┘");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");

            //안내문에 따른 키입력 처리
            while (true)
            {
                // 입력 처리
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    switch (key)
                    {
                        //엔터를 누르면 게임 시작
                        case ConsoleKey.Enter:
                            gamePlay.Playing(); //게임 플레잉 메소드
                            break;

                        //ESC버튼을 누르면 게임 종료
                        case ConsoleKey.Escape:
                            Console.Clear();
                            Console.WriteLine("게임을 종료합니다");
                            break;
                    }
                }
            }
        }

        //게임오버시 출력됨
        public void GameOver()
        {
            //출력 화면
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("                           ┌───────────────────────────────────────────────────────────┐");
            Console.WriteLine("                           │                                                           │");
            Console.WriteLine("                           │       ■■■■■■■■■■    ■■■■■■■    ■■■■  ■■■■   ■■■■■■■■■■    │");
            Console.WriteLine("                           │      ■■■         ■■■    ■■■   ■■■■■■■■■■  ■■■■            │");
            Console.WriteLine("                           │      ■■    ■■■■ ■■■■    ■■■■ ■■■■■■■■■■■  ■■■■■■■■■       │");
            Console.WriteLine("                           │      ■■■    ■■■ ■■■■■■■ ■■■■ ■■■■ ■■ ■■■  ■■■■            │");
            Console.WriteLine("                           │        ■■■■■■■  ■■■■    ■■■■ ■■■     ■■■   ■■■■■■■■■■     │");
            Console.WriteLine("                           │                                                           │");
            Console.WriteLine("                           │       ■■■■■■■■■  ■■■■    ■■■■  ■■■■■■■■■■  ■■■■■■■■■■■    │");
            Console.WriteLine("                           │     ■■■     ■■■ ■■■■    ■■■■ ■■■■         ■■■     ■■■     │");
            Console.WriteLine("                           │     ■■■     ■■■  ■■■■  ■■■■  ■■■■■■■■■    ■■■     ■■■     │");
            Console.WriteLine("                           │     ■■■     ■■■    ■■■■■■    ■■■■         ■■■■■■■■■       │");
            Console.WriteLine("                           │      ■■■■■■■■■       ■■       ■■■■■■■■■■  ■■■    ■■■■■    │");
            Console.WriteLine("                           │                                                           │");
            Console.WriteLine("                           └───────────────────────────────────────────────────────────┘");
            Console.WriteLine("");
            Console.WriteLine("                                            ┌─────────────────────────┐");
            Console.WriteLine("                                            │  Enter key :  Restart   │");
            Console.WriteLine("                                            │                         │");
            Console.WriteLine("                                            │  BackSpace :   Title    │");
            Console.WriteLine("                                            │                         │");
            Console.WriteLine("                                            │     ESC    :   Exit     │");
            Console.WriteLine("                                            └─────────────────────────┘");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");

            //안내문에 따른 키입력 처리
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    switch (key)
                    {
                        //엔터를 누르면 게임 재시작
                        case ConsoleKey.Enter:
                            gamePlay.Playing();
                            break;

                        //백스페이스를 누르면 게임타이틀로 돌아가기
                        case ConsoleKey.Backspace:
                            Console.Clear();
                            Title();
                            Console.WriteLine("게임 타이틀로 돌아갑니다");
                            break;

                        //ESC를 누르면 게임 종료
                        case ConsoleKey.Escape:
                            Console.Clear();
                            Console.WriteLine("게임을 종료합니다");
                            break;
                    }
                }
            }
        }
    }
}
