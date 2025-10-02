using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Diagnostics;

namespace WormGame_1
{
    //키입력을 위한 열거형
    public enum Direction { Up, Down, Left, Right }

    //포지션값
    class Position
    {
        public int _positionX { get; set; }
        public int _positionY { get; set; }

        public Position(int x, int y)
        {
            _positionX = x;
            _positionY = y;
        }
    }

    //지렁이 클래스
    class Worm
    {
        //필드
        private List<Position> wormBody;
        public Direction Direction;

        //지렁이 생존에 대한 참 거짓
        public bool alive { get; private set; } = true;

        //프로퍼티
        public List<Position> WormBody
        {
            get { return wormBody; }
        }

        //지렁이 생성자
        public Worm()
        {
            wormBody = new List<Position>();
            WormDraw();

            //초반 지렁이 몸체 3개로 시작
            wormBody.Add(new Position(10, 10));
            wormBody.Add(new Position(9, 10));
            wormBody.Add(new Position(8, 10));
        

            //지렁이의 초기 진행 방향 설정
            Direction = Direction.Right;
        }


        //지렁이 움직임에 대한 매서드
        public void Move()
        {
            //기존 머리
            Position exisHead = wormBody[0];

            //새로운 머리
            Position newHead;

            //디렉션에 대한 스위치
            switch (Direction)
            {
                case Direction.Up:
                    //업이면 Y값 - 무한반복, 결과 위쪽으로 지속 이동
                    newHead = new Position(exisHead._positionX, exisHead._positionY - 1);
                    break;

                case Direction.Down:
                    //다운이면 Y값 + 무한반복, 결과 아래쪽으로 지속 이동
                    newHead = new Position(exisHead._positionX, exisHead._positionY + 1);
                    break;

                case Direction.Left:
                    //레프트면 X값 - 무한반복, 결과 왼쪽으로 지속 이동
                    newHead = new Position(exisHead._positionX - 1, exisHead._positionY);
                    break;

                case Direction.Right:
                    //라이트면 X값 + 무한반복, 결과 오른쪽으로 지속 이동
                    newHead = new Position(exisHead._positionX + 1, exisHead._positionY);
                    break;

                //디폴트 값
                default:
                    newHead = exisHead;
                    break;
            }

            //경계선 충돌 판정
            //만약 포인트 a가 0보다 크고 포인트 a가 가로폭 세로폭 보다 크거나 같을때 게임 오버
            if (newHead._positionX < 0 || newHead._positionX >= Console.WindowWidth
               || newHead._positionY < 0 || newHead._positionY >= Console.WindowHeight)
            {
                alive = false;
                return;
            }


            //자기 몸을 충돌하면 게임 오버

            // 모든 조건을 충족하는 지 확인, 만약에 포지션 xy와 지렁이 머리 포지션 xy가 같으면 죽음 판정
            if (wormBody.Any(posi => posi._positionX == newHead._positionX &&
            posi._positionY == newHead._positionY))
            {
                alive = false;
                return;

            }

            //인덱스 요소 추가
            wormBody.Insert(0, newHead);

            //인덱스 요소 제거
            wormBody.RemoveAt(wormBody.Count - 1);
        }

        //지렁이 출력 메소드
        public void WormDraw()
        {
            //지렁이 몸체 출력
            foreach (var point in wormBody)
            {
                //커서의 위치 설정 (포인트 X값, 포인트 Y값)
                Console.SetCursorPosition(point._positionX, point._positionY);

                //지렁이 생김새
                Console.Write("▣");
            }
        }

        //사과를 먹으면 몸이 길어지는 메소드 추가 예정
        public void EatingApple()
        {


        }
    }


    //사과 클래스
    class Apple
    {
        //필드
        private Position location;
        private Random random = new Random();

        //포지션에 대한 프로퍼티
        public Position Location
        {
            get { return location; }
            set { location = value; }
        }

        //사과 생성 매소드
        public Position AppleCreate(List<Position> wBody)
        {
            Position loca;
            bool pile = true;

            //사과 랜덤 효과
            //무조건 하라
            do
            {
                //cmd 너비와 높이 내에서 사과 랜덤 생성
                int x = random.Next(0, Console.WindowWidth);
                int y = random.Next(0, Console.WindowHeight);
                loca = new Position(x, y);


                //모든 값을 충족하는지 확인 (포지션 X, 로케이션 X가 같음 && 포지션 Y와 로케이션 Y가 같음)
                //해당 사항이 충족되면 트루
                pile = wBody.Any(posi => posi._positionX == loca._positionX &&
                posi._positionY == loca._positionY);

            } while (pile); //트루일 시 반복 //*Do While문*
            location = loca;
            return loca;
        }

        //사과 출력 메소드
        public void AppleDrew()
        {
            //커서의 위치 설정 (로케이션 X값, 로케이션 Y값)
            Console.SetCursorPosition(location._positionX, location._positionY);

            //사과의 생김새
            Console.Write("♥");
        }
    }


    //디스플레이 클래스
    class Display
    {
        //게임 플레이에 대한 메서드
        public void GamePlay()
        {
            Worm worm = new Worm();
            Apple apple = new Apple();
            Display display = new Display();
            apple.AppleCreate(worm.WormBody);

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
                        //반대 방향을 빠르게 누르면 바로 죽는 버그 발견)
                        //if 조건문으로 방지 
                        case ConsoleKey.UpArrow:
                            if (worm.Direction != Direction.Down)
                            {
                                worm.Direction = Direction.Up;
                            }
                            break;

                        //화살표 아래 입력시 디렉션 다운 (웜 > 무브 메소드에 있음)
                        case ConsoleKey.DownArrow:
                            if(worm.Direction != Direction.Up)
                            {
                                worm.Direction = Direction.Down;
                            }
                            break;

                        //화살표 왼쪽 입력시 디렉션 레프트 (웜 > 무브 메소드에 있음)
                        case ConsoleKey.LeftArrow:
                            if(worm.Direction != Direction.Right)
                            {
                                worm.Direction = Direction.Left;
                            }
                            break;

                        //화살표 오른쪽 입력시 디렉션 라이트 (웜 > 무브 메소드에 있음)
                        case ConsoleKey.RightArrow:
                            if(worm.Direction != Direction.Left)
                            {
                                worm.Direction = Direction.Right;
                            }
                            break;
                    }
                }
                Position head = worm.WormBody[0];

                //만약에 헤드 포시션과 에플 포지션이 같으면?
                if (head._positionX == apple.Location._positionX && head._positionY == apple.Location._positionY)
                {
                    //worm.EatingApple();  //기능 추가 예정

                    //사과 생성
                    apple.AppleCreate(worm.WormBody);
                }
                worm.Move();
                Console.Clear();
                worm.WormDraw();
                apple.AppleDrew();
                Thread.Sleep(110); //지렁이 속도
            }
            Console.Clear();
            display.GameOver(); //while 반복문에서 빠져나가면 게임오버
            Console.ReadKey();
        }

        public void StartTitle ()
        {
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

            while (true)
            {
                // 입력 처리
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    switch (key)
                    {
                        case ConsoleKey.Enter:
                            GamePlay();
                            break;
                        case ConsoleKey.Escape:
                            Console.Clear();
                            Console.WriteLine("게임을 종료합니다");
                            Thread.Sleep(100); // 100ms 대기
                            break;
                    }
                }
            }
        }


        //게임오버시 출력됨
        public void GameOver()
        {
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

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    switch (key)
                    {
                        case ConsoleKey.Enter:
                            GamePlay();
                            break;
                        case ConsoleKey.Backspace:
                            Console.Clear();
                            StartTitle();
                            Console.WriteLine("게임 타이틀로 돌아갑니다");
                            Thread.Sleep(100); // 100ms 대기
                            break;
                        case ConsoleKey.Escape:
                            Console.Clear();
                            Thread.Sleep(100); // 100ms 대기
                            Console.WriteLine("게임을 종료합니다");
                            break;

                    }
                }
            }
        }
    }

    //메인문
    class Programw
    {
        static void Main(string[] args)
        {
            Console.Title = "Warm Game";
            Console.CursorVisible = false;
            Display display = new Display();

            display.StartTitle();

            
        }
    }
}
















