using System;
using System.Collections.Generic;
using System.Linq;

namespace WormGame_1
{
    //사과 클래스
    class Apple
    {
        //필드
        private Position location;
        private Random random = new Random();
        
        //프로퍼티
        public Position Location
        {
            get { return location; }
            private set { location = value; }
        }

        //사과 생성 매소드
        public Position AppleCreate(List<Position> wBody)
        {
            Position loca;
            bool pile;

            //사과 생성 랜덤 효과
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

            Console.ForegroundColor = ConsoleColor.Red; //폰트 색상 빨간색으로 변경\
            Console.Write("♥"); //사과의 생김새
            Console.ResetColor(); //폰트 색상 초기화
        }

        //사과 누적 스코어 출력 메소드
        public void AppleScore(int Count)
        {
                Console.ForegroundColor = ConsoleColor.Red; //폰트색 빨간색
                Console.SetCursorPosition(50, 0); //폰트 위치
                Console.WriteLine($" ♥ x {Count}"); //출력
                Console.ResetColor(); //폰트 색상 초기화
        }
    }
}
