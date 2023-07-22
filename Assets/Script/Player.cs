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
    private float lastTurnSpeed = 100f;

    Rigidbody rigid;
    Animator animator;

    Vector3 moveVec;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
        Dash();
        MouseCursor();
    }

    void Move() // 플레이어 움직임 (wasd)
    { 
        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");

        // 가만히 있지 않는 상태를 확인해주기위함
        bool hasHorizontalInput = !Mathf.Approximately(moveX, 0f);
        bool hasVerticalInput = !Mathf.Approximately(moveZ, 0f);

        moveVec = new Vector3(moveX, 0, moveZ);
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
        Time.timeScale = 0.05f;
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 1f;
        Vector3.MoveTowards(transform.position, transform.forward, dashSpeed);
    }

    void MouseCursor()
    {
        Cursor.lockState = CursorLockMode.Confined;

        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane GroupPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (GroupPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointTolook = cameraRay.GetPoint(rayLength);
            transform.LookAt(new Vector3(pointTolook.x, transform.position.y, pointTolook.z));
        }
    }
}
