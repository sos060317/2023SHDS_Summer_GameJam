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

    void Move() // �÷��̾� ������ (wasd)
    { 
        moveVec.x = Input.GetAxisRaw("Horizontal");
        moveVec.z = Input.GetAxisRaw("Vertical");
        rigid.velocity = moveVec.normalized * moveSpeed;
    }

    void Dash() // �÷��̾� �ߵ��� (���콺 ��Ŭ��)
    {
        if(Input.GetMouseButtonDown(1))
        {
            
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
        //targetPosition = transform.position + forwardVec * ;
    }
}
