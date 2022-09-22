using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public float aiMovementSpeed;

    public GameObject ballTarget;

    private void FixedUpdate()
    {
        //If the difference in height compared to the ball and the racket
        //is more than 50 units, than it should move to get it.
        if (Mathf.Abs(this.transform.position.y - ballTarget.transform.position.y) > 50)
        {
            //If the ball is higher than 50 units than our racket
            //then move it up
            if(transform.position.y < ballTarget.transform.position.y)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1) * aiMovementSpeed;
            }
            //If there is a difference in height between the two objects
            //that is 50 units or more, and the ball is not up.
            //Then it means that it is down, and it should go down
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1) * aiMovementSpeed;
            }
        }
        //If the difference in height between the two is not too
        //great, than the velocity should be zero
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }        
    }
}
