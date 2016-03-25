using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public Transform centerOfMass;

    public float movementSpeed = 5f;
    public float sprintSpeed = 15f;
    public float jumpForce = 10f;

    public AnimationClip idle;
    public AnimationClip run;

    private Animation anim;
    private Rigidbody rigidBody;

    private bool grounded = true;
    private bool sprinting = true;
    


    private void ControlPlayer()
    {
        if( Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), Vector3.up * -1, 1.5f))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }

        if (Input.GetAxis("Fire1") != 0)
        {
            sprinting = true;
        }
        else
        {
            sprinting = false;
        }

        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (grounded && Input.GetAxis("Jump") != 0)
        {
            Debug.Log("jumping!");
            rigidBody.AddForce(Vector3.up * jumpForce);
        }

        if(movement != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(movement);
            anim.Play("Run");
            if (sprinting)
            {
                transform.Translate(movement * sprintSpeed * Time.deltaTime, Space.World);
            }
            else
            {
                transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);
            }
            
        }
        else
        {
            anim.Play("Idle01");
        }
        
    }


    private void Update()
    {

        ControlPlayer();
    }


    private void Awake()
    {
        rigidBody = gameObject.GetComponent<Rigidbody>();
        rigidBody.centerOfMass = centerOfMass.position;

        anim = gameObject.GetComponentInChildren<Animation>();
    }
}