using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace WormGame_1
{
    //키입력을 위한 열거형
    public enum Direction { Up, Down, Left, Right }

    //지렁이 클래스
    class Worm
    {
        //필드
        private List<Position> wormBody;
        public Direction Direction;
        private bool _grow = false;

        //지렁이 생존에 대한 참 거짓
        public bool alive { get; private set; } = true;

        //프로퍼티
        public List<Position> WormBody
        {
            get { return wormBody; }
            set { wormBody = value; }
        }

        //지렁이 생성자
        public Worm()
        {
            wormBody = new List<Position>();
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
                    //업이면 Y값 - 무한반복, ([결과] 위쪽으로 지속 이동)
                    newHead = new Position(exisHead._positionX, exisHead._positionY - 1);
                    break;

                case Direction.Down:
                    //다운이면 Y값 + 무한반복, ([결과] 아래쪽으로 지속 이동)
                    newHead = new Position(exisHead._positionX, exisHead._positionY + 1);
                    break;

                case Direction.Left:
                    //레프트면 X값 - 무한반복, ([결과] 왼쪽으로 지속 이동)
                    newHead = new Position(exisHead._positionX - 1, exisHead._positionY);
                    break;

                case Direction.Right:
                    //라이트면 X값 + 무한반복, ([결과] 오른쪽으로 지속 이동)
                    newHead = new Position(exisHead._positionX + 1, exisHead._positionY);
                    break;

                //디폴트 값
                default:
                    newHead = exisHead;
                    break;
            }

            //테두리에 충돌하면 게임 오버
            if (newHead._positionX <= 0 || newHead._positionX >= 30 || //맵 영역 X 값
                newHead._positionY <= 2 || newHead._positionY >= 27)   //맵 영역 Y 값
            {
                alive = false;
                return;
            }

            //자기 몸을 충돌하면 게임 오버
            if (wormBody.Any(posi => posi._positionX == newHead._positionX &&
            posi._positionY == newHead._positionY))
            {
                alive = false;
                return;
            }

            //새로운 머리를 몸통 리스트에 추가
            wormBody.Insert(0, newHead);


            //꼬리의 출력이 길어지지 않게 조절
            var tail = wormBody.Last();
            Console.SetCursorPosition(tail._positionX * 2, tail._positionY);
            Console.Write(" ");


            //성장하지 않는 경우 몸 조절
            if (!_grow)
            {
                //지렁이의 카운트를 1씩 감소 시켜 계속 증가하는것을 방지
                wormBody.RemoveAt(wormBody.Count - 1);
            }
            else
            {
                _grow = false;
            }
        }

        // 지렁이 방향 입력 처리 (조건문으로 반대 방향 입력 방지)
        public void WormMovingKeyInput()
        {
            Display display = new Display();

            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if (Direction != Direction.Down)
                        {
                            Direction = Direction.Up;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (Direction != Direction.Up)
                        {
                            Direction = Direction.Down;
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        if (Direction != Direction.Right)
                        {
                            Direction = Direction.Left;
                        }
                        break;

                    case ConsoleKey.RightArrow:
                        if (Direction != Direction.Left)
                        {
                            Direction = Direction.Right;
                        }
                        break;


                    //게임 중 타이틀 화면으로 돌아가는 키
                    case ConsoleKey.Backspace:
                        Console.Clear();
                        display.ShowTitle();
                        break;


                    //게임 중 게임 종료하는 키
                    case ConsoleKey.Escape:
                        Console.Clear();
                        display.MapOutlineDraw();
                        Console.SetCursorPosition(21, 14);
                        Console.WriteLine("게임을 종료합니다");
                        Thread.Sleep(1000);
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                }
            }
        }

        //지렁이 성장 메소드
        public void Grow(int Count)
        {
            _grow = true;
        }

        //지렁이 출력 메소드
        public void WormDraw()
        {
            //지렁이 몸체 출력
            foreach (var point in wormBody)
            {
                //커서의 위치 설정 (포인트 X값 (폰트의 크기에 맞게 *2, 포인트 Y값)
                Console.SetCursorPosition(point._positionX * 2, point._positionY);

                //지렁이 생김새
                Console.Write("▣");
            }
        }
    }
}