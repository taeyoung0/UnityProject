    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f;

    private float minY = -7;

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
}
