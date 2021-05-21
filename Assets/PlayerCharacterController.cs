using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    public float walkingSpeed = 5f;

    // Option 3: read values anywhere else
    void FixedUpdate()
    {
        var movementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        var movement = movementInput * walkingSpeed * Time.fixedDeltaTime;
        if (movement.y < 0f)
            movement.y *= 0.9f;
        movement.x *= 0.95f;
        var rigidBody = GetComponent<Rigidbody>();
        rigidBody.AddForce(movement.x, 0f, movement.y, ForceMode.VelocityChange);
        var animator = GetComponent<Animator>();
        animator.SetFloat("X", rigidBody.velocity.x);
        animator.SetFloat("Y", rigidBody.velocity.z);
        //Debug.Log(movement);
    }
}