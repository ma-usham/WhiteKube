using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawRotate : MonoBehaviour
{
    public bool rotationInStart = false;
    public float speed_rotation = -5;
    MovingObstacle movingObstacle;
    bool directionChanged=true;
    private void Awake()
    {
        movingObstacle = GetComponent<MovingObstacle>();
        if(movingObstacle==null)
        {
            Debug.Log("NULL");
        }
    }

    void Start()
    {
        if (speed_rotation > 0)
        {
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, -gameObject.transform.localScale.y, 1);
        }
    }


    void FixedUpdate()
    {
        if (rotationInStart)
        {
            gameObject.transform.Rotate(0, 0, speed_rotation*Time.fixedDeltaTime);
        }
        ChangeDirection();
        
    }

    void ChangeDirection()
    {
        if (Vector2.Distance(movingObstacle.transform.position, movingObstacle.posA.position) < 0.1f && !directionChanged)
        {
            speed_rotation *= -1;
            directionChanged = true;
        }


        if (Vector2.Distance(movingObstacle.transform.position, movingObstacle.posB.position) < 0.1f && directionChanged)
        {
            speed_rotation *= -1;
            directionChanged = false;
        }
    }
    


}
