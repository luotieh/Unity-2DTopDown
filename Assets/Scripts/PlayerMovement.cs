using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    public InputActions inputActions;

    public Vector2 inputDirection;
    public float moveSpeed;
    private Rigidbody2D rb;

    private SpriteRenderer sr;

    private Animator anim;

    private void Awake(){
        inputActions = new InputActions();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void OnEnable(){
        inputActions.Enable();
    }

    private void OnDisable(){
        inputActions.Disable();
    }   

    // Update is called once per frame
    private void Update()
    {
        inputDirection = inputActions.Gameplay.Move.ReadValue<Vector2>();
        // Debug.Log(inputDirection);

        SetAnimation();
    }

    private void FixedUpdate(){
        Move();

        
    }
    void Move(){
        // rb's speed
        rb.velocity = inputDirection * moveSpeed;

        if (inputDirection.x <0){
            sr.flipX = true;
        }
        if (inputDirection.x >0){
            sr.flipX = false;
        }
    }

    void SetAnimation(){
        //获取刚体组件速度向量的数值大小
        anim.SetFloat("Speed", rb.velocity.magnitude);
    }
}
