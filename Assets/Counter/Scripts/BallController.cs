using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody ballRig;
    private bool isDrag;
    private bool actived = true;
    private Vector3 dragStartPos;
    private Vector3 dragReleasePos;
    private BallSpawn ballSpawner;
    [SerializeField] float speed = 15;

    // Start is called before the first frame update
    void Start()
    {
        ballRig = GetComponent<Rigidbody>();
        ballSpawner = FindObjectOfType<BallSpawn>();
    }

    
    private void OnMouseDown()
    {
        isDrag = true;
        dragStartPos = Input.mousePosition;
    }

    private void OnMouseUp()
    {
        if (isDrag && actived)
        {
            dragReleasePos = Input.mousePosition;
            Vector3 dragDir = (dragReleasePos - dragStartPos).normalized;
            //Debug.Log("the result: " +dragDir.x + "," + dragDir.y + "," + dragDir.z);
            Vector3 dragForce = new Vector3(dragDir.x, 1.0f, dragDir.y);

            //ÈÓ³öÈ¥
            ballRig.AddForce(dragForce * speed, ForceMode.Impulse);

        }
        dragStartPos = Vector3.zero;
        isDrag = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            ballSpawner.SpawnNewBall();
            //Invoke("DestroyBall", 3.0f);
            GameManager.singleton.LifeCheck();
            Destroy(gameObject.GetComponent<BallController>());            
        }
    }
}
