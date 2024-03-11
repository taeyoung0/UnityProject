using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 유니티 엔진에서 moveSpeed 값을 조정할 수있게 해줌
    [SerializeField]

    private GameObject weapon;

    [SerializeField]
    private float moveSpeed; 

    // player 머리 위에서 발사되는 위치값
    [SerializeField]
    private Transform shootTransform;
    
    [SerializeField]
    // 미사일 쏘는 간격
    private float shootInterval = 0.05f;
    // 마지막에 쏜 미사일 시간
    private float lastshotTime = 0f;
    void Update()
    {
        // // 키보드 방향에 따라 입력값을 줌
        // float horizontalInput = Input.GetAxisRaw("Horizontal");
        // float verticalInput = Input.GetAxisRaw("Vertical"); 좌우로만 움직일 수 있게 주석처리

        // // 위의 입력값에 따라 현재 플레이어의 포지션 값을 바꿔줌
        // Vector3 moveTO = new Vector3(horizontalInput, 0f, 0f);

        // // 움직이는 속도를 조절
        // transform.position += moveTO * moveSpeed * Time.deltaTime;

        // --------------------------------------------------------------------------------------------

        // // 키보드 제어 두번째 방법
        // // x기준으로만 움직이게 해줌
        // Vector3 moveTo = new Vector3(moveSpeed * Time.deltaTime, 0, 0); 

        // // 키보드 왼쪽을 누르면 transform.position 현재위치에서 moveTo 만큼 - 해서 x좌표 왼쪽으로 이동하게끔 만듬
        // if (Input.GetKey(KeyCode.LeftArrow)) {
        //     transform.position -= moveTo;
        // } 
        // else if (Input.GetKey(KeyCode.RightArrow)) {
        //     transform.position += moveTo;
        // }

        // 마우스로 제어하는 방법
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float toX = Mathf.Clamp(mousePos.x, -2.36f, 2.34f);

        // x값만 움직이게 설정
        transform.position = new Vector3(toX, transform.position.y, transform.position.z ); 
        Shoot();
    }

    void Shoot() {
        if (Time.time - lastshotTime > shootInterval){
            Instantiate(weapon, shootTransform.position, Quaternion.identity);
            lastshotTime = Time.time;
            }
        
    }
}
