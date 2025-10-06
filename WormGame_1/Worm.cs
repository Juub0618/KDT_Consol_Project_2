using System;
using System.Collections.Generic;
using System.Linq;

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

            //경계선에 몸을 충돌하면 게임 오버
            if (newHead._positionX < 0 || newHead._positionX >= 31 // 테두리 위 아래 넓이
               || newHead._positionY < 0 || newHead._positionY >= 28) // 테두리 좌우 넓이
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

            //성장 중이 아니면 꼬리 제거
            if (!_grow)
            {
                //앞으로 나아가도록 보여야하니까 인덱스 카운트 -1로 제거
                wormBody.RemoveAt(wormBody.Count - 1);
            }
            else
            {
                _grow = false;
            }
        }

        //몸이 성장하는 메소드
        public void Grow(int Count)
        {
            //만약에 (논리 부정, 즉, _grow trou면?)
            if (!_grow)
            {
                _grow = true;
            }
            else
            {
                _grow = false;
            }
        }

        //지렁이 출력 메소드
        public void WormDraw()
        {
            //지렁이 몸체 출력
            foreach (var point in wormBody)
            {
                //커서의 위치 설정 (포인트 X값, 포인트 Y값)
                Console.SetCursorPosition(point._positionX*2, point._positionY);

                //지렁이 생김새
                Console.Write("▣");
            }
        }
    }
}