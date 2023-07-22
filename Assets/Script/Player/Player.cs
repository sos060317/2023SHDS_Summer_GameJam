using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float dashSpeed; //
    [SerializeField] private float dashDistance; // ����� ��ǥ������ �Ÿ�

    private float moveX;
    private float moveZ;

    bool isDash = false;
    bool isAttack = false;

    Rigidbody rigid;

    public GameObject attackRange;

    Vector3 moveVec;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
        Dash();
        LookMouseCursor();
        Time.timeScale += (1f / 2f) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale , 0f, 1f);
    }

    void Move() // �÷��̾� ������ (wasd)
    { 
        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");

        // ������ ���� �ʴ� ���¸� Ȯ�����ֱ�����
        bool hasHorizontalInput = !Mathf.Approximately(moveX, 0f);
        bool hasVerticalInput = !Mathf.Approximately(moveZ, 0f);

        moveVec = new Vector3(moveX, 0, moveZ);
        rigid.velocity = moveVec.normalized * moveSpeed;
    }

    void Dash() // �÷��̾� �ߵ��� (���콺 ��Ŭ��)
    {
        if (Input.GetMouseButtonDown(0) && !isDash && !isAttack)
        {
            StartCoroutine(_Attack());
        }

        if(Input.GetMouseButtonDown(1) && !isDash && !isAttack)
        {
            StartCoroutine(_Dash());
        }
    }

    IEnumerator _Dash()
    {
        isDash = true;
        SlowMotion();
        yield return new WaitForSeconds(0.05f);
        isDash = false;
        rigid.AddForce(transform.forward * dashSpeed * 1000f, ForceMode.Impulse);
    }

    IEnumerator _Attack()
    {
        isAttack = true;
        attackRange.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        attackRange.SetActive(false);
        isAttack = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && isDash)
        {

        }
    }

    void LookMouseCursor() // ���콺Ŀ���� ȭ������� ������ �ʰ� �����ϰ� ���콺Ŀ�� ���������� �÷��̾ �ٶ󺸰� �ϴ��Լ�
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

    void SlowMotion() // ���ο���
    {
        Time.timeScale = 0.05f;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }
    
}
