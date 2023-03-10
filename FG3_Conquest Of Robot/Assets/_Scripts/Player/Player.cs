using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    void Awake()
    {
        Instance = this;
    }

    public Animator anim;
    private bool moving;

    public float moveSpeed;
    Vector2 moveInput;

    PlayerController playerController;

    void Start()
    {
        this.playerController = GetComponent<PlayerController>();
        this.anim = GetComponent<Animator>();
    }

    void Update()
    {
        this.GetInput();
        this.Animate();
    }

    private void GetInput()
    {
        this.moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 moveVelocity = this.moveInput.normalized * this.moveSpeed;
        playerController.Move(moveVelocity); 
    }

    private void Animate()
    {
        this.moving = (Mathf.Abs(this.moveInput.normalized.magnitude) > .1f) ? true : false;
        if (this.moving)
        {
            this.anim.SetFloat("X", this.moveInput.x);
            this.anim.SetFloat("Y", this.moveInput.y);
        }
        this.anim.SetBool("Moving", this.moving);
    }
}
