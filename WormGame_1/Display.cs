using System;
using System.Threading;

namespace WormGame_1
{
    //디스플레이 클래스
    class Display
    {
        private GamePlay gamePlay;
        private char tile1 = '━';
        private char tile2 = '┃';

        //게임 타이틀 
        public void ShowTitle()
        {
            Console.Clear();
            gamePlay = new GamePlay();

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
            Console.SetCursorPosition(85, 7);
            Console.WriteLine("Game Rules");
            Console.SetCursorPosition(75, 10);
            Console.WriteLine("아이템 종류");
            Console.SetCursorPosition(75, 12);
            Console.WriteLine("♥ : 지렁이 성장, 점수 누적");
            Console.SetCursorPosition(75, 14);
            Console.WriteLine("★ : 지렁이 속도 증가");
            Console.SetCursorPosition(75, 19);
            Console.WriteLine("게임 오버 조건");
            Console.SetCursorPosition(75, 21);
            Console.WriteLine("1. 벽에 부딛히면 게임 오버");
            Console.SetCursorPosition(75, 23);
            Console.WriteLine("2. 자기 몸에 부딛히면 게임 오버");
            
            //키 입력 처리
            while (true)
            {
                MapOutlineDraw(); //테두리 출력
                if (Console.KeyAvailable) // 입력 처리
                {
                    var key = Console.ReadKey(true).Key;
                    switch (key)
                    {
                        //엔터를 누르면 게임시작
                        case ConsoleKey.Enter:
                            gamePlay.Playing(); //게임플레이
                            break;
                     
                        //ESC키를 누르면 게임종료
                        case ConsoleKey.Escape:
                            Console.Clear();
                            MapOutlineDraw(); //콘솔 클리어로 인한 테두리 재출력
                            Console.SetCursorPosition(21, 14); //위치
                            Console.WriteLine("게임을 종료합니다"); 
                            Thread.Sleep(1000); //1초 대기
                            Console.Clear();
                            Environment.Exit(0); //종료
                            break;
                    }
                }
            }
        }

        //게임 오버시 출력
        public void ShowGameOver(int score)
        {
            gamePlay = new GamePlay();

            //게임 오버 문구 출력
            Console.ForegroundColor = ConsoleColor.White; //폰트 화이트
            Console.SetCursorPosition(14, 5);
            Console.WriteLine(" ┌────┐  ┌───┐   ┌─┐┌─┐  ┌───── ");

            Console.ForegroundColor = ConsoleColor.Yellow; //폰트 옐로우
            Console.SetCursorPosition(14, 6);
            Console.WriteLine("│┌────┘ ││   ││ ││ ││ ││ │┌────┘");

            Console.ForegroundColor = ConsoleColor.DarkYellow; //폰트 다크 옐로우
            Console.SetCursorPosition(14, 7);
            Console.WriteLine("││ └─┐│ │└─── │ ││ ││ ││ │ ───┘");
            Console.SetCursorPosition(14, 8);
            Console.WriteLine("│└───┘│ │┌───┐│ ││ └┘ ││ │└─── ");

            Console.ForegroundColor = ConsoleColor.Cyan; //폰트 시안
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

            //최종 점수 출력
            Console.SetCursorPosition(25, 20);
            Console.WriteLine("최종 점수");
            Console.SetCursorPosition(27, 22);
            Console.WriteLine($"♥ : {score}");
            
            //게임 리스타트, 타이틀로 돌아가기, 종료 문구 출력
            Console.SetCursorPosition(45, 28);
            Console.WriteLine("[Enter] 다시시작");
            Console.SetCursorPosition(0, 28);
            Console.WriteLine("[Backspace] 타이틀로");
            Console.SetCursorPosition(25, 28);
            Console.WriteLine("[ESC] 종료하기");

            //키 입력 처리
            while (true)
            {
                MapOutlineDraw(); //테두리 출력

                if (Console.KeyAvailable)  // 입력 처리
                {
                    var key = Console.ReadKey(true).Key;
                    switch (key)
                    {
                        //엔터를 누르면 게임시작
                        case ConsoleKey.Enter:
                            gamePlay.Playing();
                            break;
                     
                        //백스페이스를 누르면 타이틀 화면으로 돌아가기
                        case ConsoleKey.Backspace:
                            Console.Clear();
                            ShowTitle();
                            break;

                        //ESC키를 누르면 게임종료
                        case ConsoleKey.Escape:
                            Console.Clear();
                            MapOutlineDraw(); //콘솔 클리어로 인한 테두리 재출력
                            Console.SetCursorPosition(21, 14); //위치
                            Console.WriteLine("게임을 종료합니다"); 
                            Thread.Sleep(1000); //1초 대기
                            Console.Clear();
                            Environment.Exit(0); //종료
                            break;
                    }
                }
            }
        }


        //맵 테두리 출력
        public void MapOutlineDraw()
        {
            //모서리 부분 출력
            Console.SetCursorPosition(0, 2);
            Console.Write("┏");

            Console.SetCursorPosition(0, 27);
            Console.Write("┗");

            Console.SetCursorPosition(60, 2);
            Console.Write("┓");

            Console.SetCursorPosition(60, 27);
            Console.Write("┛");

            //윗 줄 출력
            Console.SetCursorPosition(1, 2);
            for (int i = 0; i < 59; i++)
            {
                Console.Write(tile1);
            }

            //아래쪽 줄 출력
            Console.SetCursorPosition(1, 27);

            for (int i = 0; i < 59; i++)
            {
                Console.Write(tile1);
            }

            //오른쪽 줄 출력
            Console.SetCursorPosition(0, 3);
            for (int i = 1; i < 24; i++)
            {
                Console.WriteLine(tile2);
            }

            //왼쪽 줄 출력
            for (int i = 1; i < 26; i++)
            {
                Console.WriteLine(tile2);
                Console.SetCursorPosition(60, 2+i);
            }
        }

        //게임중 스코어, 스피드 현황 출력, 타이틀 돌아가기, 즉시 종료 안내 출력
        public void StatusOutput(int score, int speed)
        {
            // 스코어 현황 출력
            Console.ForegroundColor = ConsoleColor.Red; //레드
            Console.SetCursorPosition(27, 1); //위치
            Console.Write($"♥ x {score}"); //점수 출력
            Console.ResetColor(); //리셋 컬러

            //스피드 현황 출력
            Console.ForegroundColor = ConsoleColor.DarkYellow; //다크 옐로우
            Console.SetCursorPosition(45, 1); //위치
            Console.Write($"Speed + {100 - speed}"); //스피드 출력
            Console.ResetColor(); //리셋 컬러

            //타이틀 돌아가기, 즉시 종료 키입력 안내문구 출력
            Console.ForegroundColor = ConsoleColor.DarkGray; //다크 그레이
            Console.SetCursorPosition(0, 28);
            Console.Write("[Backspace] 타이틀로");
            Console.SetCursorPosition(25, 28);
            Console.Write("[ESC] 종료하기");
            Console.ResetColor(); //리셋 컬러
        }
    }
}