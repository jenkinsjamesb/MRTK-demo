using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourHandler : MonoBehaviour
{
    /*
         * initialize necessary variables. 
         * we want to have a check for if the conditions are met to pour, and a check for if we are currently pouring.
         * we want to minimize Update() tasks, so code called per frame should only execute if the pour state changes.
         * Pouring is handled through the particle effect on the Pitcher item, we just wanna know if we /should/ be pouring.
         * Pour should start when the local rotation of the Pitcher reaches a certain threshold, and stop once it's above that.
         * * i.e. the Pitcher is at a > 45 degree angle, start pouring. stop pouring once it returns < 45 degrees.
    */
    public bool isPouring = false;
    int pourCheck, pourThreshold = 45;
    public float pourAngle;
    double tilt;
    public ParticleSystem system;
    public GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        StopEmit();
        go = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        pourAngle = go.transform.localRotation.eulerAngles.x;
        isPouring = pourAngle < pourThreshold;
        if (isPouring)
        {
            DoEmit();
        }
        else
        {
            StopEmit();
        }
    }

    void DoEmit()
    {
        var emitParams = new ParticleSystem.EmitParams();
        emitParams.startColor = Color.blue;
        system.Emit(emitParams, 30);
        system.Play();
    }

    void StopEmit()
    {
        var emitParams = new ParticleSystem.EmitParams();
        system.Emit(emitParams, 0);
        system.Stop();
    }
}
