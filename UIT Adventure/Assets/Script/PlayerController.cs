using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    private bool isMoving;
    private Vector2 input;
    private Animator animator;
    public LayerMask solibObjectsLayer;

    //shot
    public Transform gunTip;
    public GameObject bullet;
    float firerate = 0.2f;
    float nextFire = 0;
    

    private void Start()
    {

    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            Debug.Log("Input x: " + input.x);
            Debug.Log("input y: " + input.y);




            if (input.x != 0) input.y = 0;
            if (input.y != 0) input.x = 0;

            if (input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                if(isWalkable(targetPos))
                    StartCoroutine(Move(targetPos));
            }
        }
        animator.SetBool("isMoving", isMoving);

        //shoot form mouse
        if (Input.GetAxisRaw("Fire1") > 0)
            fireBullet();
    }
    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
    }
    private bool isWalkable(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.2f, solibObjectsLayer) != null)
        { return false; }
        return true;
    }

    //shot
    void fireBullet(){
    if (Time.time > nextFire){
        nextFire = Time.time + firerate;

        // Tính toán hướng bắn
        Vector4 mousePos = Input.mousePosition;
        mousePos.z = 10; // Khoảng cách từ camera đến màn hình
        Vector4 objectPos = Camera.main.WorldToScreenPoint(gunTip.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        // Xoay súng
        gunTip.rotation = Quaternion.Euler(new Vector4(0, 0, angle));

        // Bắn đạn
        Instantiate(bullet, gunTip.position, gunTip.rotation);
        }
    }

    
}