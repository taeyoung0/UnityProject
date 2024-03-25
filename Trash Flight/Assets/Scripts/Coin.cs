using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private float minY = -7f;
    // Start is called before the first frame update
    void Start()
    {
        Jump();
    }


    void Jump() {
        Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();
        
        float randomJumpForce = Random.Range(4f, 8f);       // 점프 랜덤으로 뽑기, 좀 더 다양한 높이를 얻기위해 실수 사용
        Vector2 jumpVelocity = Vector2.up * randomJumpForce;
        jumpVelocity.x = Random.Range(-2f, 2f);                     // 
        rigidBody.AddForce(jumpVelocity, ForceMode2D.Impulse);
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < minY) {
            Destroy(gameObject);
    }
    }
}