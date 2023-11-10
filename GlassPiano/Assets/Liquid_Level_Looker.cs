using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liquid_Level_Looker : MonoBehaviour
{
    int lvlact = 0,lvlnow = 0, LVLMAX = 7;
    public GameObject go, filler;
    public AudioSource ding;
    ParticleSystem liquid;
    public double dong;
    double doh = 1.115, rey = 1.185, mee = 1.327, fah = 1.41, soh = 1.579, lah = 1.77, tee = 1.99, doe = 2.105;
    private float timer, start, end, interval = 3.0f;

    /*
     * purpose: respond to particle effect from Pitcher. adjust pitch of glass after 3 seconds of pouring. display new pitch.
     */
    // Start is called before the first frame update
    void Start()
    {
        go = this.gameObject;
        ding = go.GetComponent<AudioSource>();
        liquid = filler.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if ( lvlact != lvlnow)
        {
            lvlact = lvlnow;
            switch (lvlact)
            {
                case 0:
                    dong = doh;
                    break;
                case 1:
                    dong = rey;
                    break;
                case 2:
                    dong = mee;
                    break;
                case 3:
                    dong = fah;
                    break;
                case 4:
                    dong = soh;
                    break;
                case 5:
                    dong = lah;
                    break;
                case 6:
                    dong = tee;
                    break;
                case 7:
                    dong = doe;
                    break;
                default: break;

            }
            ding.pitch = ((float)dong);
        }
    }

    //called on particle collision
    void OnParticleCollision (GameObject giver)
    {
        start = timer;
        timer += Time.deltaTime;
        if( (timer > interval) & (lvlnow < LVLMAX) )
        {
            timer = timer - interval;
            lvlnow++;
        }
    }
}
