using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketMoveRound : BasketController
{
    private float r = 6f;
    private float angle = 0;

    protected override void MoveBasket()
    {
        angle += moveSpeed;
        float rad = angle * Mathf.Deg2Rad;
        float translateX = (r * Mathf.Sin(rad));
        float translateZ = (r * Mathf.Cos(rad));

        transform.position = new Vector3(initPos.x + translateX, initPos.y, initPos.z + translateZ);
    }
}
