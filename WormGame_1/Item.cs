using System;
using System.Collections.Generic;
using System.Linq;

namespace WormGame_1
{

    //아이템 추상클레스
    abstract class Item
    {
        public Position Location { get; protected set; }
        protected Random random = new Random();
        protected Worm worm;

        //아이템 생성 위치
        //block = 겹침 값
        protected Position GetRandomLocation(List<Position> wormBody, List<Position> block = null)
        {
            Position loca;
            bool pile;
            //무조건 하라
            //아이템 생성 랜덤 효과
            do
            {
                //설정한 너비와 높이 값 내에서 아이템 생성
                int x = random.Next(3, 27);
                int y = random.Next(3, 27);
                loca = new Position(x, y);

                //모든 값을 충족하는지 확인 (포지션XY와 로케이션XY가 같음)||(블록이 널이 아님 && 모든값을 충족하는지 확인(블록 XY와 로케이션XY가 같음))
                pile = wormBody.Any(p => p._positionX == loca._positionX && p._positionY == loca._positionY)
                        || (block != null && block.Any(b => b._positionX == loca._positionX && b._positionY == loca._positionY));

            } while (pile); //트루일시 반복 //*Do While문*

            return loca;
        }

        //아이템 생성 추상 메소드
        public abstract void Create(List<Position> wormBody, List<Position> block = null);

        //아이템 출력 추상 메소드
        public abstract void Draw();
    }


    //사과 클래스
    class Apple : Item
    {
        //사과 생성 메소드
        public override void Create(List<Position> wormBody, List<Position> block = null)
        {
            Location = GetRandomLocation(wormBody, block);
        }

        //사과 출력 메소드
        public override void Draw()
        {
            //위치 설정 (로케이션 X값, 로케이션 Y값)
            //*2는 지렁이 헤드 포지션과 맞추기 위해서 지정
            Console.SetCursorPosition(Location._positionX * 2, Location._positionY);

            Console.ForegroundColor = ConsoleColor.Red; //폰트 레드
            Console.Write("♥"); //사과 모양 출력
            Console.ResetColor(); //리셋 컬러
        }
    }

    //스피드업 클래스
    class SpeedUpItem : Item
    {
        public DateTime spawnTime; // 생성 시간

        //스피드업 생성 메소드
        public override void Create(List<Position> wormBody, List<Position> block = null)
        {
            Location = GetRandomLocation(wormBody, block);
        }

        //스피드업 출력 메소드
        public override void Draw()
        {
            //위치 설정 (로케이션 X값, 로케이션 Y값)
            //*2는 지렁이 헤드 포지션과 맞추기 위해서 지정
            Console.SetCursorPosition(Location._positionX * 2, Location._positionY);
            Console.ForegroundColor = ConsoleColor.Yellow; //폰트 옐로우
            Console.Write("★"); //스피드 업 아이템 출력
            Console.ResetColor(); //리셋 컬러
        }
    }
}
