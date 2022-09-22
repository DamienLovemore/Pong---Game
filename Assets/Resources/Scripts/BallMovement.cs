using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float movementSpeed;
    public float extraSpeedPerHit;
    public float maxExtraSpeed;

    int hitCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Starts the function asynchronously.
        StartCoroutine(StartBall());
    }

    void PositionBall(bool isStartingPlayer1)
    {
        //Reset the ball position
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        //If is player 1 turn
        if (isStartingPlayer1)
        {
            //Position the ball at the left of the center.
            this.gameObject.transform.localPosition = new Vector3(-334, -177, 10);
        }
        else
        {
            //Position the ball at the right of the center.
            this.gameObject.transform.localPosition = new Vector3(-133, -177, 10);
        }
    }

    public IEnumerator StartBall(bool isStartingPlayer1 = true)
    {
        this.PositionBall(isStartingPlayer1);

        //When the game starts after it sets the
        //hitCounter to 0, it waits for 2 seconds
        //to start moving the ball
        this.hitCounter = 0;
        yield return new WaitForSeconds(2);

        //If the value is true, it should
        //move to the left
        if (isStartingPlayer1)
            this.MoveBall(new Vector2(-1, 0));
        //otherwise it should go the right
        else
            this.MoveBall(new Vector2(1, 0));
    }

    public void MoveBall(Vector2 dir)
    {
        //Sometimes the value could come with very
        //weird numbers, and this method normalizes
        //them
        dir = dir.normalized;

        //Each sucessful hit, increases the speed of
        //the ball.
        float speed = this.movementSpeed + (this.hitCounter * this.extraSpeedPerHit);

        //this.gameObject always refer to the object
        //that was called.
        //GetComponent gets one the components that
        // is added to that Game Object.
        Rigidbody2D rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();

        //Makes the Game Object moves in that vector
        //direction without considering drag, and
        //other physics.
        rigidbody2D.velocity = dir * speed;
    }

    public void IncreaseHitCounter()
    {
        //If the ball has not reached the maximum speed,
        //it still can be increased.
        if ((this.hitCounter * this.extraSpeedPerHit) < maxExtraSpeed)
            this.hitCounter++;
    }
}
