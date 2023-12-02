using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float for_speed;

    public float side_speed;

    public Transform center_pos;
    public Transform left_pos;
    public Transform right_pos;

    private int current_pos;
    void Start()
    {
        current_pos = 0;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + for_speed*Time.deltaTime);
        

        if(current_pos == 0)
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
                current_pos =0;
            }
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
        }
    }
}
