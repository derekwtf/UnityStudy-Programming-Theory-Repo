using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasketController : Counter
{
    [SerializeField] protected float moveSpeed;

    private void Update()
    {
        MoveBasket();
    }

    protected virtual void MoveBasket(){}
    
}
