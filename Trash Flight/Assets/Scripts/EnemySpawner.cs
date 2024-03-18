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
        
        // 무한루프 실행
        while (true){
            foreach(float posX in arrPosX){         //  arrPosX 배열에 있는 각 위치에 대해 적을 생성
                int index = Random.Range(0, enemies.Length);    // 적은 enemies 배열에서 랜덤하게 선택
                SpwanEnemy(posX, index);
            }

            yield return new WaitForSeconds(spawnInterval);     // spawnInterval만큼 대기한 후에 다시 반복
        }
    }

    void SpwanEnemy(float posX, int index)      // SpawnEnemy() 메서드는 적을 실제로 생성
    {
        Vector3 spawnPos = new Vector3(posX, transform.position.y, transform.position.z);       // posX로 지정된 x좌표와 현재 게임 오브젝트의 y, z좌표를 사용하여 생성 위치를 계산
        Instantiate(enemies[index], spawnPos, Quaternion.identity);     // Instantiate() 함수를 사용하여 해당 위치에 적 오브젝트를 생성
    }
  
}
