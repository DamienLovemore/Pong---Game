using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketPlayer1 : MonoBehaviour
{
    public float movementSpeed;

    private void FixedUpdate()
    {
        //Input.GetAxis strength increases by
        //how much the key is pressed.
        //(Shortly, or by long periods)
        //GetAxisRaw does not care about
        //intensity of the press.
        float v = Input.GetAxisRaw("Vertical");

        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * movementSpeed;
    }
}
