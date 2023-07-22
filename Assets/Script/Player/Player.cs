using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float dashSpeed; //
    [SerializeField] private float dashDistance; // 대시할 목표지점의 거리\

    private float moveX;
    private float moveZ;


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
        CheckMyForward();
    }

    void Move() // 플레이어 움직임 (wasd)
    { 
        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");

        // moveVec = (moveX, 0, moveZ);
        rigid.velocity = moveVec.normalized * moveSpeed;
    }

    void Dash() // 플레이어 발도술 (마우스 우클릭)
    {
        if(Input.GetMouseButtonDown(1))
        {
            
            StartCoroutine(_Dash());
        }
    }

    IEnumerator _Dash()
    {
        yield return new WaitForSeconds(0.5f);

        Vector3.MoveTowards(transform.position, targetPosition, dashSpeed);
    }

    void CheckMyForward() // 대시할 목표지점의 벡터를 구해주는 함수
    {
        forwardVec = transform.forward;
        targetPosition = transform.position + forwardVec * dashDistance;
        Debug.Log(targetPosition);
    }
}
