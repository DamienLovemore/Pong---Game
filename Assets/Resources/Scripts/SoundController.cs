using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource wallSound;
    public AudioSource racketSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If what the ball hitted was a racket, then
        //play racketsound
        if(collision.gameObject.name.IndexOf("RacketPlayer") != -1)
        {
            this.racketSound.Play();
        }
        else if(collision.gameObject.name.IndexOf("Wall") != -1)
        {
            this.wallSound.Play();
        }
    }
}
