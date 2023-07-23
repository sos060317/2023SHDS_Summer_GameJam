using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float dashSpeed; //
    [SerializeField] private float dashDistance; // 대시할 목표지점의 거리
    [SerializeField] private float attackDamage;
    [SerializeField] private Collider collider;
    
    private float moveX;
    private float moveZ;
    
    public bool dashReady = false;
    public bool isDash = false;
    public bool isAttack = false;

    public float radius;

    Rigidbody rigid;
    Animator animator;


    public GameObject attackRange;
    [Header("Effect")]
    public GameObject dashEffect;
    public GameObject dashReadyEffect;



    Vector3 moveVec;
    Vector3 dashDir;

    Quaternion dashQuaternion;

    public SwordTrigger sword;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();

        sword.GetTriggered().AddListener(SwordTriggerd);
    }

    private void SwordTriggerd()
    {
        GaugeManager.Instance.expGauge.SetValue(10);
        Debug.Log("Triggerd!");
    }

    private void Update()
    {
        Move();
        Dash();
        LookMouseCursor();
        Time.timeScale += (1f / 2f) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale , 0f, 1f);

        if (dashReady)
        {
            rigid.velocity = dashDir * dashSpeed;
        }
    }

    void Move() // 플레이어 움직임 (wasd)
    { 
        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");

        // 가만히 있지 않는 상태를 확인해주기위함
        bool hasHorizontalInput = !Mathf.Approximately(moveX, 0f);
        bool hasVerticalInput = !Mathf.Approximately(moveZ, 0f);
        bool isRunning = hasHorizontalInput || hasVerticalInput;
        animator.SetBool("running", isRunning);

        moveVec = new Vector3(moveX, 0, moveZ);
        rigid.velocity = moveVec.normalized * moveSpeed;
    }

    void Dash() // 플레이어 발도술 (마우스 우클릭)
    {
        if (Input.GetMouseButtonDown(0) && !isAttack)
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
        dashDir = transform.forward;
        dashQuaternion = transform.rotation * Quaternion.Euler(45, 0, 0);
        isDash = true;
        var dash02 = Instantiate(dashEffect, transform.position, dashQuaternion);
        Destroy(dash02, 0.5f);
        animator.SetBool("attackReady", true);
        SlowMotion();
        yield return new WaitForSeconds(0.05f);
        animator.SetBool("attackReady", false);
        dashReady = true;
        yield return new WaitForSeconds(0.01f);
        
        dashReady = false;
        yield return new WaitForSeconds(1f);
        isDash = false;
    }

    IEnumerator _Attack()
    {
        isAttack = true;
        attackRange.SetActive(true);

        animator.SetBool("slash", true);
        collider.enabled = true;
        yield return new WaitForSeconds(0.1f);
        attackRange.SetActive(false);
        yield return new WaitForSeconds(0.1f);

        animator.SetBool("slash", false);
        yield return new WaitForSeconds(0.1f);
        collider.enabled = false;
        isAttack = false;
    }
    void LookMouseCursor() // 마우스커서를 화면밖으로 나가지 않게 제어하고 마우스커서 방향쪽으로 플레이어가 바라보게 하는함수
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

    void SlowMotion() // 슬로우모션
    {
        Time.timeScale = 0.05f;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemy") && attackRange)
        {
            other.gameObject.GetComponent<Enemy>().OnDamaged(attackDamage);
            Debug.Log("피해를 입음");
        }
    }
}
