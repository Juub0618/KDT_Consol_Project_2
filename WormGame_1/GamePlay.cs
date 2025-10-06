using System;
using System.Threading;

namespace WormGame_1
{
    class GamePlay
    {

        //게임 플레이에 대한 메서드
        public void Playing()
        {
            Worm worm = new Worm();
            Apple apple = new Apple();
            Display display = new Display();
            
            int mapX = 0;  //랜덤 범위 x값
            int mapY = 50; //랜덤 범위 y값

            int Count = 0; //사과 누적 카운트
            int speed = 100; //지렁이 기본속도
            
            apple.AppleCreate(worm.WormBody, mapX, mapY);
             
             //지렁이가 살아있을 경우 반복
             while (worm.alive)
             {
                //키입력에 관한 조건문
                if (Console.KeyAvailable)
                {
                    //키입력 받기
                    var key = Console.ReadKey().Key;

                    switch (key)
                    {
                        //화살표 위 입력시 디렉션 업 (웜 > 무브 메소드에 있음)
                        //반대방향을 누르면 바로 게임오버되는 것을 방지하기 위한 if 조건문 
                        case ConsoleKey.UpArrow:
                            if (worm.Direction != Direction.Down)
                            {
                                worm.Direction = Direction.Up;
                            }
                            break;

                        //화살표 아래 입력시 디렉션 다운 (웜 > 무브 메소드에 있음)
                        case ConsoleKey.DownArrow:
                            if (worm.Direction != Direction.Up)
                            {
                                worm.Direction = Direction.Down;
                            }
                            break;

                        //화살표 왼쪽 입력시 디렉션 레프트 (웜 > 무브 메소드에 있음)
                        case ConsoleKey.LeftArrow:
                            if (worm.Direction != Direction.Right)
                            {
                                worm.Direction = Direction.Left;
                            }
                            break;

                        //화살표 오른쪽 입력시 디렉션 라이트 (웜 > 무브 메소드에 있음)
                        case ConsoleKey.RightArrow:
                            if (worm.Direction != Direction.Left)
                            {
                                worm.Direction = Direction.Right;
                            }
                            break;
                        case ConsoleKey.Escape:
                            Console.Clear();
                            display.DrawMap();
                            Console.SetCursorPosition(21, 14);
                            Console.WriteLine("게임을 종료합니다");
                            Thread.Sleep(1000); //1초 대기
                            Console.Clear();
                            Environment.Exit(0); //종료
                            break;
                        case ConsoleKey.Backspace:
                            Console.Clear();
                            display.DrawMap();
                            Console.SetCursorPosition(17, 14);
                            Console.WriteLine("타이틀 화면으로 돌아갑니다");
                            Thread.Sleep(1000);
                            Console.Clear();
                            display.Title();
                            break;
                    }
                }
                Console.Clear();
                Position head = worm.WormBody[0];

                //사과를 먹으면 다시생성
                //만약에 (헤드 포시션과 애플 포지션이 같다면?)
                if (head._positionX == apple.Location._positionX &&
                    head._positionY == apple.Location._positionY)
                {
                    worm.Grow(+1); //사과를 먹으면 지렁이 1만큼 성장
                    apple.AppleCreate(worm.WormBody, mapX, mapY); //사과 생성

                   ++Count; //사과 카운트 누적
                }
                Console.Clear(); //화면 리셋

                worm.Move(); //지렁이 움직임에 대한 메서드
                worm.WormDraw(); //지렁이 출력
                apple.AppleDrew(); //사과 출력
                display.DrawMap(); //테두리 출력

                Console.SetCursorPosition(1, 28);
                Console.WriteLine("[Backspace] 타이틀 화면");

                Console.SetCursorPosition(27, 28);
                Console.WriteLine("[ESC] 종료");

                apple.AppleScore(Count); //사과 누적점수 출력
                Thread.Sleep(speed); //지렁이 속도 조절
            }
            Console.Clear();
            display.GameOver(); //while 반복문에서 빠져나가면 게임오버
        }
    }
}