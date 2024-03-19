using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    // enemies는 게임 오브젝트 배열로, 인스펙터 창에서 설정할 수 있도록 함, 이 배열은 소환할 적 캐릭터의 종류를 나타냄
    [SerializeField]
    private GameObject[] enemies;

    // 적 캐릭터가 생성될 x좌표를 배열에 넣어줌
    private float[] arrPosX = {-2.2f, -1.1f, 0f, 1.1f, 2.2f};


    // spawnInterval은 각 적이 생성되는 간격
    [SerializeField]
    private float spawnInterval = 1.5f;

    void Start()
    {
        // 여기서 StartEnemyRoutine()을 호출하여 각 적을 생성하는 루틴을 시작
        StartEnemyRoutine();
    }

    void StartEnemyRoutine() {
        // StartEnemyRoutine() 메서드는 EnemyRoutine 코루틴을 시작
        StartCoroutine("EnemyRoutine");
    }

    // EnemyRoutine() 코루틴은 3초 동안 대기한 후 반복문을 실행
    IEnumerator EnemyRoutine() {
        yield return new WaitForSeconds(3f);
        
        float moveSpeed = 5f;       // 적이 나오는 속도 조절을 위한 변수
        int spawnCount = 0;          // 적이 몇번 나오는지 카운트 하는 변수
        int enemyIndex = 0;
        // 무한루프 실행
        while (true){
            foreach(float posX in arrPosX){         //  arrPosX 배열에 있는 각 위치에 대해 적을 생성
                SpwanEnemy(posX, enemyIndex, moveSpeed);
            }
            spawnCount++;

            if(spawnCount % 10 == 0) {
                enemyIndex += 1;                // 적이 10번 나오면 다음단계 다음 단계 적이 나오게 함
                moveSpeed +=2;              // 난이도에 따라 속도를 2씩 증가
            }

            yield return new WaitForSeconds(spawnInterval);     // spawnInterval만큼 대기한 후에 다시 반복
        }
    }

    void SpwanEnemy(float posX, int index, float moveSpeed)      // SpawnEnemy() 메서드는 적을 실제로 생성
    {
        Vector3 spawnPos = new Vector3(posX, transform.position.y, transform.position.z);       // posX로 지정된 x좌표와 현재 게임 오브젝트의 y, z좌표를 사용하여 생성 위치를 계산
        
        if(Random.Range(0, 5) == 0) {       // 0, 1, 2, 3, 4  -> 0 일 확률 20%
            index += 1;         // 20% 확률로 enemies 배열의 다음 인덱스값이 나온다

        }

        if(index >= enemies.Length) {
            index = enemies.Length - 1;             // 인덱스 범위가 초과했을때 오류가 나지 않게 Enemies 배열의 마지막 인덱스 값으로 초기화
        }
        
        GameObject enemyObject = Instantiate(enemies[index], spawnPos, Quaternion.identity);     // Instantiate() 함수를 사용하여 해당 위치에 적 오브젝트를 생성
        Enemy enemy = enemyObject.GetComponent<Enemy>();        // 
        enemy.SetMoveSpeed(moveSpeed);      // +2된 movesSpeed 매개변수를 enemy클래스의 스피드 업데이트 메서드에 전달
    }
  
}
