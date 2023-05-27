using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;


public class PlayerController : NetworkBehaviour
{
    // Start is called before the first frame update
    [SerializeField]public float moveSpeed;
    private bool isMoving;
    private bool isUp;
    private bool isDown;
    private bool isRight;
    private bool isLeft;
    private bool isShooting;
    private Vector2 input;
    private Animator animator;
    public LayerMask solibObjectsLayer;

    //shot
    [SerializeField]public Transform gunTip;
    [SerializeField]public GameObject bullet;
    [SerializeField]float firerate = 0.2f;
    [SerializeField]float nextFire = 0;

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
            if (!IsOwner) return;

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
        {
            fireBullet();
            isShooting = true;
            animator.SetBool("isShooting", isShooting);

        }
        else
        {
            isShooting = false;
            animator.SetBool("isShooting", isShooting);
        }

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
    private void fireBullet()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + firerate;

            // Calculate the shooting direction
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = -Camera.main.transform.position.z; // Distance from the camera to the desired plane
            Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector3 shootingDirection = targetPosition - gunTip.position;
            shootingDirection.Normalize();

            // Set the rotation to face the shooting direction
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, shootingDirection);
            gunTip.rotation = rotation;

            // Spawn the bullet
            Instantiate(bullet, gunTip.position, rotation);
        }
    }

    
}
