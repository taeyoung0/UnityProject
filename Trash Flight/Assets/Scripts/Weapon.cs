using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // 다른 클래스에서는 제어할 수 없게 유니티에서는 제어할 수 있게 해준거임
    [SerializeField]
    private float moveSpeed = 10f;

    public float damage = 1f;
    // Start is called before the first frame update
    void Start()
    {
        // 시작하자마자 1초뒤에 이 객체를 없앤다
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += Vector3.up * moveSpeed * Time.deltaTime;
    }
}
