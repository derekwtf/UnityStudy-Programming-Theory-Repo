using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawn : MonoBehaviour
{
    [SerializeField] BallController curBall;
    private Vector3 ballSpawnPos = new Vector3 (0,3.2f,0);

    private void Start()
    {
        SpawnNewBall();
        GameManager.singleton.UpdateDifficulty(0);
    }

    public void SpawnNewBall()
    {
        if (GameManager.singleton.IsGameOver) return;

        var balls = FindObjectsOfType<BallController>();
        Debug.Log("ball numb: " + balls.Length);
        if (balls.Length < 2)
        {
            Instantiate(curBall, ballSpawnPos, curBall.transform.rotation);
        }
    }
}
