using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float for_speed;

    public float side_speed;

    public float JumpForce;
    public Transform center_pos;
    public Transform left_pos;
    public Transform right_pos;

    private bool isPlay;
    public Animator playerAnimator;

    private int current_pos;

    public Rigidbody rb;
    void Start()
    {
        isPlay = false;

        current_pos = 0;
        Physics.IgnoreLayerCollision(3,6);

    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            isPlay = true;
            playerAnimator.SetFloat("isRunning", 1);
        }

        if (isPlay)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + for_speed * Time.deltaTime);


            if (current_pos == 0)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(center_pos.position.x, transform.position.y, transform.position.z), side_speed * Time.deltaTime);
            }
            else if (current_pos == 1)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(left_pos.position.x, transform.position.y, transform.position.z), side_speed * Time.deltaTime);
            }
            else if (current_pos == 2)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(right_pos.position.x, transform.position.y, transform.position.z), side_speed * Time.deltaTime);
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (current_pos == 0)
                {
                    current_pos = 1;
                }
                else if (current_pos == 2)
                {
                    current_pos = 0;
                }

                StartCoroutine(SideJump());
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (current_pos == 0)
                {
                    current_pos = 2;
                }
                else if (current_pos == 1)
                {
                    current_pos = 0;
                }
                StartCoroutine(SideJump());
            }

           
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            StartCoroutine(Flip_Jump());
        }
    }
    IEnumerator SideJump()
    {
        playerAnimator.SetFloat("isSideJump", 1);
        yield return new WaitForSeconds(0.5f);
        playerAnimator.SetFloat("isSideJump", 0);
    }

    IEnumerator Flip_Jump()
    {
        playerAnimator.SetFloat("isJumping", 1);
        yield return new WaitForSeconds(0.9f);
        playerAnimator.SetFloat("isJumping",0);
    }
}
