using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    protected Text CounterText;
    protected Vector3 initPos;

    private int Count = 0;

    private void Start()
    {
        CounterText = FindObjectOfType<Text>();
        initPos = transform.position;
        Count = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        Count += 1;
        CounterText.text = "SCORE : " + Count;
    }
}
