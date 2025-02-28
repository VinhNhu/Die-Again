using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] protected float speedMovement;
    [SerializeField] protected float speedRotation;
    [SerializeField] private float jumpForce;

    [HideInInspector] public Vector3 movementDirection;
    [SerializeField] private VariableJoystick joystick;

    [SerializeField] private LayerMask groundLayer;
    private bool isGrounded;

    protected Animator animator;
    private Rigidbody rb;

    private void OnEnable()
    {
       
        GameObject joystickObject = GameObject.Find("Joystick");
        joystick = joystickObject.GetComponent<VariableJoystick>();
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
       
    }

    private void FixedUpdate()
    {
        if (!GameManager.Instance.isLose && !GameManager.Instance.isWin)
        {
            handleMovement();
        }
        
    }

    private void handleMovement()
    {
        movementDirection = new Vector3(joystick.Direction.x, 0f, joystick.Direction.y);

        if (IsMoving)
        {
            animator.SetBool(AnimationString.IsIdle, false);
            handleRoration(movementDirection);
            Vector3 newPosition = movementDirection + transform.position;

            transform.position = Vector3.Lerp(transform.position, newPosition, speedMovement * Time.deltaTime);
        }
        else
        {
            animator.SetBool(AnimationString.IsIdle, true);
        }
    }

    public void handleRoration(Vector3 direction)
    {
        Vector3 targetDirection = Vector3.RotateTowards(transform.forward, direction, speedRotation * Time.deltaTime, 0f);
        transform.rotation = Quaternion.LookRotation(targetDirection);
    }

    public void Jump()
    {
        if (isGrounded && !GameManager.Instance.isLose && !GameManager.Instance.isWin)
        {
            isGrounded = false;
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetBool(AnimationString.IsJump, true);
            AudioController.Instance.PlaySound(AudioController.Instance.jump);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if ((groundLayer & (1 << collision.gameObject.layer)) != 0)
        {
            isGrounded = true;
            animator.SetBool(AnimationString.IsJump, false);
        }
    }


    public bool IsMoving
    {
        get { return movementDirection.magnitude > 0; }
    }

}
