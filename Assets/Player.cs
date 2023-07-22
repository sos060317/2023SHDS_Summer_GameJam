using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float dashSpeed; //

    Rigidbody rigid;

    Vector3 moveVec;
    Vector3 forwardVec;
    Vector3 targetPosition;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
        Dash();
    }

    void Move() // 플레이어 움직임 (wasd)
    { 
        moveVec.x = Input.GetAxisRaw("Horizontal");
        moveVec.z = Input.GetAxisRaw("Vertical");
        rigid.velocity = moveVec.normalized * moveSpeed;
    }

    void Dash() // 플레이어 발도술 (마우스 우클릭)
    {
        if(Input.GetMouseButtonDown(1))
        {
            
        }
    }

    IEnumerator _Dash()
    {
        yield return new WaitForSeconds(0.5f);

        //Vector3.MoveTowards(transform.position, );
    }

    void CheckMyForward() // 대시할 목표지점의 벡터를 구해주는 함수
    {
        forwardVec = transform.forward;
        //targetPosition = transform.position + forwardVec * 
    }
}
