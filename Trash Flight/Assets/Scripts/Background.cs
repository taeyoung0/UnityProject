using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // 속도 조절을 하기위해 변수 선언
    private float movespeed = 3f;

    // Update is called once per frame
    void Update()
    {
        // 구조체를 이용해 배경이 밑으로 움직이게 만든다.
        // Time.deltaTime은 모든 성능에서 동일하게 배경이 움직이게 하기위해 곱해줌
        transform.position += Vector3.down * movespeed * Time.deltaTime;

        if(transform.position.y < -10){
            transform.position += new Vector3(0, 20f, 0);   // 새로 선언해주고 y좌표를 20 더해서 -10에서 +10으로 바꿔줌


        }
    }
}
