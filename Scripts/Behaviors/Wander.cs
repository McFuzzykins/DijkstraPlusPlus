using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : Seek
{
    public float wanderOffset = 5f;
    public float wanderRadius = 4f;

    public Vector3 circleCenter;
    public Vector3 wanderTarget;

    public Vector2 tempCircleTarget;
    public Transform characterTrans;

    public float timeDelay = 100f;

    protected override Vector3 getTargetPosition()
    {
        if (timeDelay >= 100f)
        {
            timeDelay = 0;
            circleCenter = characterTrans.position + characterTrans.forward * wanderOffset;

            tempCircleTarget = new Vector2(circleCenter.x, circleCenter.z) + Random.insideUnitCircle * wanderRadius;
            wanderTarget = new Vector3(tempCircleTarget.x, 0, tempCircleTarget.y);
        }

        timeDelay += 0.1f;
        return wanderTarget;
    }
}
