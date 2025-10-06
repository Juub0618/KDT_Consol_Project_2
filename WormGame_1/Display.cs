using System;
using System.Threading;
using System.Threading.Tasks;

namespace WormGame_1
{
    //디스플레이 클래스
    class Display
    {
        GamePlay gamePlay = new GamePlay();
  
        char tile1 = '━';
        char tile2 = '┃';

        //게임 타이틀 메소드
        public void Title()
        {
            //타이틀
            Console.ForegroundColor = ConsoleColor.White; //화이트
            Console.SetCursorPosition(11, 7);
            Console.WriteLine("┌┐      ┌┐   ┌───┐    ┌───┐    ┌─┐┌─┐");

            Console.ForegroundColor = ConsoleColor.DarkYellow; //다크 옐로우
            Console.SetCursorPosition(11, 8);
            Console.WriteLine("││  ┌┐  ││  ││   ││  ││   ││  ││ ││ ││");

            Console.ForegroundColor = ConsoleColor.Magenta; //마젠타
            Console.SetCursorPosition(11, 9);
            Console.WriteLine("││  ││  ││  ││   ││  ││  ─┘│  ││ ││ ││");

            Console.SetCursorPosition(11, 10);
            Console.WriteLine("││  ││  ││  ││   ││  │┌──┐│   ││ ││ ││");

            Console.ForegroundColor = ConsoleColor.DarkMagenta; //마크 마젠타
            Console.SetCursorPosition(11, 11);
            Console.WriteLine("││  ││  ││  ││   ││  ││   ││  ││ └┘ ││");

            Console.ForegroundColor = ConsoleColor.Cyan; //시안
            Console.SetCursorPosition(11, 12);
            Console.WriteLine(" └──┘└──┘    └────   └┘    └┘ └┘    └┘");
            Console.ResetColor(); // 리셋 컬러

            Console.SetCursorPosition(25, 14);
            Console.WriteLine("worm game");

            //게임 스타트, 종료 문구
            Console.SetCursorPosition(20, 19);
            Console.WriteLine("[Enter]  게임 시작");
            Console.SetCursorPosition(20, 21);
            Console.WriteLine("[ESC]        종료");

            //게임 규칙 안내문
            Console.SetCursorPosition(85, 10);
            Console.WriteLine("Game Rules");
            Console.SetCursorPosition(75, 17);
            Console.WriteLine("1. 랜덤하게 나오는 사과'♥' 먹기");
            Console.SetCursorPosition(75, 19);
            Console.WriteLine("2. 사과를 먹으면 지렁이 성장");
            Console.SetCursorPosition(75, 21);
            Console.WriteLine("3. 벽에 부딛히면 게임 오버");

            //입력값 처리, 테두리 출력
            while (true)
            {
                //테두리 출력
                DrawMap();

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
                            DrawMap();
                            Console.SetCursorPosition(21, 14);
                            Console.WriteLine("게임을 종료합니다");
                            Thread.Sleep(1000); //1초 대기
                            Console.Clear();
                            Environment.Exit(0); //종료
                            break;
                    }
                }
            }
        }

        //게임 오버시 출력됨
        public void GameOver()
        {
            //게임 오버 문구 출력
            Console.ForegroundColor = ConsoleColor.White; //폰트 화이트
            Console.SetCursorPosition(14, 5);
            Console.WriteLine(" ┌────┐  ┌───┐   ┌─┐┌─┐  ┌───── ");

            Console.ForegroundColor = ConsoleColor.Yellow; //폰트 옐로우
            Console.SetCursorPosition(14, 6);
            Console.WriteLine("│┌────┘ ││   ││ ││ ││ ││ │┌────┘");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(14, 7);
            Console.WriteLine("││ └─┐│ │└─── │ ││ ││ ││ │ ───┘");
            Console.SetCursorPosition(14, 8);
            Console.WriteLine("│└───┘│ │┌───┐│ ││ └┘ ││ │└─── ");

            Console.ForegroundColor = ConsoleColor.Cyan; //폰트 다크 옐로우
            Console.SetCursorPosition(14, 9);
            Console.WriteLine("└─────┘ └┘   └┘ └┘    └┘ └────┘");

            Console.ForegroundColor = ConsoleColor.White; //폰트 화이트
            Console.SetCursorPosition(14, 11);
            Console.WriteLine(" ┌───┐  ┌┐   ┌┐ ┌─────   ┌───┐");

            Console.ForegroundColor = ConsoleColor.Red; //폰트 레드
            Console.SetCursorPosition(14, 12);
            Console.WriteLine("││   ││ ││   ││ │┌────┘ ││   ││");

            Console.SetCursorPosition(14, 13);
            Console.WriteLine("││   ││ ││   ││ │ ───┘  ││ ─┘│");

            Console.ForegroundColor = ConsoleColor.DarkRed; //폰트 다크 레드
            Console.SetCursorPosition(14, 14);
            Console.WriteLine("││   ││  ││ ││  │└───   │┌───┐│ ");

            Console.ForegroundColor = ConsoleColor.Magenta; //폰트 마젠타
            Console.SetCursorPosition(14, 15);
            Console.WriteLine(" └────    └─┘   └────┘  └┘    └┘");
            Console.ResetColor(); // 리셋 컬러

            //게임 리스타트, 타이틀로 돌아가기, 종료 문구
            Console.SetCursorPosition(22, 19);
            Console.WriteLine("Restart :  Enter");
            Console.SetCursorPosition(22, 20);
            Console.WriteLine("Title   :  Backspace");
            Console.SetCursorPosition(22, 21);
            Console.WriteLine("Exit    :  ESC");

            //입력값 처리, 테두리 출력
            while (true)
            {
                //테두리 출력
                DrawMap();

                //입력값 처리
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
                            break;

                        //ESC버튼을 누르면 게임 종료
                        case ConsoleKey.Escape:
                            Console.Clear();
                            DrawMap();
                            Console.SetCursorPosition(21, 14);
                            Console.WriteLine("게임을 종료합니다");
                            Thread.Sleep(1000); //1초 대기
                            Console.Clear();
                            Environment.Exit(0); //종료
                            break;
                    }
                }
            }
        }

        //맵 테두리 출력 메소드
        public void DrawMap()
        {
            //모서리 부분 출력
            Console.SetCursorPosition(0, 0);
            Console.Write("┏");

            Console.SetCursorPosition(0, 27);
            Console.Write("┗");

            Console.SetCursorPosition(60, 0);
            Console.Write("┓");

            Console.SetCursorPosition(60, 27);
            Console.Write("┛");

            //윗 줄 출력
            Console.SetCursorPosition(1, 0);
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 59; j++)
                {
                    Console.Write(tile1);
                }
            }
            
            Console.SetCursorPosition(0, 0);

            //왼쪽 줄 출력
            for (int i = 1; i < 27; i++)
            {
                Console.SetCursorPosition(60, i);
                Console.WriteLine(tile2);
            }
            
            Console.SetCursorPosition(0, 0);

            //오른쪽 줄 출력
            Console.SetCursorPosition(0, 1);
            for (int i = 0; i < 26; i++)
            {
                Console.WriteLine(tile2);
            }
            
            Console.SetCursorPosition(0, 0);

            //아래쪽 줄 출력
            Console.SetCursorPosition(1, 27);
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 59; j++)
                {
                    Console.Write(tile1);
                }
            }

            Console.SetCursorPosition(0, 0);
        }
    }
}