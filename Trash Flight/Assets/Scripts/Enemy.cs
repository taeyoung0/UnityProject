using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject coin;

    [SerializeField]
    private float moveSpeed = 10f;

    private float minY = -7f;

    [SerializeField]
    private float hp = 1f;

    public void SetMoveSpeed(float moveSpeed) {
        this.moveSpeed = moveSpeed;             // 적의 스피드 업데이트 메서드
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;

        if (transform.position.y < minY) {
            Destroy(gameObject);

        }
    }

    private void OnTriggerEnter2D(Collider2D other) {           // IsTrigger 체크 했을때 사용
            if (other.gameObject.tag == "Weapon") {
            Weapon weapon = other.gameObject.GetComponent<Weapon>();        // 충돌한 대상의 게임오브젝트로 부터 Weapon컴포넌트를 받아옴
            hp -= weapon.damage;
            if (hp <= 0) {
                if(gameObject.tag == "Boss"){
                    GameManager.instance.SetGameOver();
                }
                Destroy(gameObject);
                Instantiate(coin, transform.position, Quaternion.identity);

            }
            Destroy(other.gameObject);      // 미사일은 항상 사라지게 함

        }
    }
        
}
