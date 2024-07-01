using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingThings : MonoBehaviour
{
    [SerializeField] private float distance = 2f;
    [SerializeField] private float speed = 3f;
    [SerializeField] private bool movingRight = true;
    [SerializeField] private bool moveHorizontal = true;
    private float rightEdge;
    private float leftEdge;
    private void Start()
    {
        if(moveHorizontal)
        {
            rightEdge = transform.position.z + distance;
            leftEdge = transform.position.z - distance;
        } else
        {
            rightEdge = transform.position.y + distance;
            leftEdge = transform.position.y - distance;
        }
        
    }
    void Update()
    {
        if (moveHorizontal)
        {
            if (transform.position.z > rightEdge)
            {
                movingRight = true;
            }
            else if (transform.position.z < leftEdge)
            {
                movingRight = false;
            }

            if (movingRight)
            {
                transform.position += transform.up * speed * Time.deltaTime;
            }
            else
            {
                transform.position += transform.up * -speed * Time.deltaTime;
            }
        }
        else
        {
            if (transform.position.y > rightEdge)
            {
                movingRight = false;
            }
            else if (transform.position.y < leftEdge)
            {
                movingRight = true;
            }

            if (movingRight)
            {
                transform.position += transform.forward * speed * Time.deltaTime;
            }
            else
            {
                transform.position += transform.forward * -speed * Time.deltaTime;
            }
        }
       
    }
}
