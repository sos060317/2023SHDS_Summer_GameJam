using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float dashSpeed; //
    [SerializeField] private float dashDistance; // ����� ��ǥ������ �Ÿ�\

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

    void Move() // �÷��̾� ������ (wasd)
    { 
        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");

        // moveVec = (moveX, 0, moveZ);
        rigid.velocity = moveVec.normalized * moveSpeed;
    }

    void Dash() // �÷��̾� �ߵ��� (���콺 ��Ŭ��)
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

    void CheckMyForward() // ����� ��ǥ������ ���͸� �����ִ� �Լ�
    {
        forwardVec = transform.forward;
        targetPosition = transform.position + forwardVec * dashDistance;
        Debug.Log(targetPosition);
    }
}
