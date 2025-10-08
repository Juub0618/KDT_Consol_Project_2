using System;
using System.Collections.Generic;
using System.Threading;

namespace WormGame_1
{
    class GamePlay
    {
        private Worm worm;
        private Display display = new Display();
        private List<SpeedUpItem> speedUps = new List<SpeedUpItem>();
        
        private int score = 0; // 점수
        private int speed = 100; // 지렁이 속도 (작을수록 빠름)
        private int minSpeed = 30; // 최소 속도

        //스피드업 아이템 관련
        private int spawnCount = 1; // 생성 카운트 (시간이 지날수록 누적)
        private DateTime spawnTime; // 생성 시간

        //스피드 누적을 위한 메소드
        public int GetSpeed()
        {
            return speed;
        }

        //게임플레이 관련
        public void Playing()
        {
            worm = new Worm();
            Apple apple = new Apple();

            apple.Create(worm.WormBody); //사과 아이템 추가
            spawnTime = DateTime.Now.AddSeconds(5); // 첫 스피드업 아이템 5초 후 추가

            Console.Clear();
            display.MapOutlineDraw(); //맵 테두리 출력

            while (worm.alive) //지렁이가 살아있으면 반복
            {
                worm.WormMovingKeyInput(); // 지렁이 방향 입력 처리
                worm.Move(); //지렁이 움직임 처리
                apple.Draw(); //사과 아이템 출력
                Position head = worm.WormBody[0];

                //스피드업 아이템 생성 처리
                //만약(현재 시간이 스폰타임보다 크거나 같을 경우)
                if (DateTime.Now >= spawnTime)
                {
                    for (int i = 0; i < spawnCount; i++) //i가 스폰 카운트보다 크면 반복
                    {
                        SpeedUpItem newItem = new SpeedUpItem();
                        newItem.Create(worm.WormBody, new List<Position> { apple.Location }); //아이템 생성
                        newItem.spawnTime = DateTime.Now; // 생성 시간 기록
                        speedUps.Add(newItem); //스피드업에 아이템 추가
                    }
                    spawnTime = DateTime.Now.AddSeconds(10); // 10초 후 다시 스폰
                }

                //스피드업 아이템 출력
                foreach (var sItem in speedUps)
                {
                    //생존시간 = 현재시간 - 스폰시간
                    double aliveTime = (DateTime.Now - sItem.spawnTime).TotalSeconds;

                    //만약 (생존시간이 5보다 크면?)
                    if (aliveTime < 5) //리스폰 출력 시간
                    {
                        sItem.Draw(); //스피드업 아이템 출력
                    }
                }

                //사과 아이템 충돌 처리
                //만약 (헤드 포지션과 사과 포지션이 같으면?)
                if (head._positionX == apple.Location._positionX &&
                    head._positionY == apple.Location._positionY)
                {
                    worm.Grow(1); //지렁이 성장
                    score++; //스코어 누적
                    apple.Create(worm.WormBody); //사과 추가
                    apple.Draw(); //사과 출력
                }

                //스피드업 아이템 충돌 처리
                for (int i = speedUps.Count - 1; i >= 0; i--)
                {
                    var sItem = speedUps[i];

                    //만약 (헤드 포지션과 스피드업 아이템 포지션이 같으면?)
                    if (head._positionX == sItem.Location._positionX &&
                        head._positionY == sItem.Location._positionY)
                    {
                        // 획득 시 속도 증가
                        if (speed > minSpeed)
                        {
                            speed = Math.Max(minSpeed, speed - 10);
                        }

                        // 획득 시 기존 별 제거
                        Console.SetCursorPosition(sItem.Location._positionX, sItem.Location._positionY);
                        Console.Write(" "); //공백으로 덮어씌우기
                        speedUps.RemoveAt(i); //인덱스 요소 제거
                    }
                }
                worm.WormDraw(); // 지렁이 출력
                display.StatusOutput(score,speed); //스코어, 스피드 현황, 게임중 키입력 안내문구 출력
                Thread.Sleep(speed); //지렁이 속도
            } 
            Console.Clear();
            display.ShowGameOver(score); //while문에 빠져나가면 게임 오버 처리
        }
    }
}
