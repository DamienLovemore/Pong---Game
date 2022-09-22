using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    //How to prevent objects that are too fast
    //from passing through other objects
    //https://forum.unity.com/threads/what-are-the-necessary-settings-to-prevent-objects-passing-through-each-other-at-high-speeds.384519/

    //Our script that controls the
    //ball movement
    public BallMovement ballMovement;
    //Our Script that constrols the
    //score, and check if one has
    //won
    public ScoreController scoreController;

    void BounceFromRacket(Collider2D c)
    {
        //The actual positon of this Game Object
        Vector3 ballPosition = this.transform.position;
        Vector3 racketPosition = c.gameObject.transform.position;

        //To be able to know if it has hit the
        //up or lower part of the racket
        float racketHeight = c.bounds.size.y;

        float x;
                 
        //If it has collid with the left racket,
        //it should bounce to the right
        if(c.gameObject.name == "RacketPlayer1")
        {
            //Fly to the right
            x = 1;
        }
        //otherwise it should bounce to the
        //right
        else
        {
            //Fly to the left
            x = -1;
        }

        //Calculate the direction that it should go up,
        //based on the position of the ball, the racket
        //and which part it has hit the racket.
        //(Up or bottom)
        float y = (ballPosition.y - racketPosition.y) / racketHeight;

        //Increases the hit count (and consequently the
        //speed) with it has not reach yet the max
        //velocity
        this.ballMovement.IncreaseHitCounter();
        //Move the ball in the calculated direction
        this.ballMovement.MoveBall(new Vector2(x, y));
    }

    //Method called when the collider has begun
    //touching another game object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //collision.collider represents the target
        //here.

        //Gets the name of the object that hited
        //it
        string objectName = collision.collider.name;

        //Discover with the object that it has collid is
        //one of the two rackets
        if (objectName.IndexOf("RacketPlayer") != -1)
        {
            this.BounceFromRacket(collision.collider);
        }
        else if (objectName == "WallLeft")
        {
            //Player 2 has scored
            this.scoreController.GoalPlayer2();
            //Restart the ball position, if it has hitted
            //StartCoroutine starts the function asynchronously.
            StartCoroutine(this.ballMovement.StartBall(true));
        }
        else if (objectName == "WallRight")
        {
            //Player 1 has scored
            this.scoreController.GoalPlayer1();
            StartCoroutine(this.ballMovement.StartBall(false));
        }
    }
}
