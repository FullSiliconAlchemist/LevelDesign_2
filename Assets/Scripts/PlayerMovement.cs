using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script implemented thanks to Brackeys https://www.youtube.com/watch?v=_QajrabyTJc

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    public float speedIncrease = 12.0f;
    public float baseSpeed = 20.0f;
    public float gravity = 9.81f;
    public float jumpHeight = 20f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    public StaminaScript staminaControl;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // transform.right is the local x axis which follows some normalized direction. when multiplied by the x negative it will move left and positivbe will move right
        // this goes for vertical as well
        Vector3 movement = transform.right * x + transform.forward * z;

        // Movement function
        if (Input.GetButton("Fire3") && staminaControl.GetCurrentStamina() > 100)
        {
            controller.Move(movement * baseSpeed * speedIncrease * Time.deltaTime);
            staminaControl.UseStamina(25.0f);
        }
        else
        {
            controller.Move(movement * baseSpeed * Time.deltaTime);
            staminaControl.RecoverStamina();
        }

        // Jump function
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            float product = jumpHeight * 2f * gravity;
            velocity.y = Mathf.Sqrt(product);
        }

        // Have to decrement or else gravity ends up being reversed for some reason
        velocity.y -= gravity * Time.deltaTime;

        // Jump movement
        controller.Move(velocity * Time.deltaTime);
    }
}
