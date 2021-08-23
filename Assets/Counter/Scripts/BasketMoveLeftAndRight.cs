using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketMoveLeftAndRight : BasketController
{
    private float boundX = 6;
    protected override void MoveBasket()
    {
        if (Mathf.Abs(transform.position.x) > boundX)
        {
            moveSpeed *= -1;
            transform.Translate(Vector3.forward * moveSpeed);
        }
        else
        {
            transform.Translate(Vector3.forward * moveSpeed);
        }
    }
}
