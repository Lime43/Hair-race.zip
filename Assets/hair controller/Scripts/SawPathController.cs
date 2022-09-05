using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawPathController : MonoBehaviour
{
    [SerializeField]
    private Vector2 clamp;
    [SerializeField]
    private float speed=1;
    private int rightDirection;
    private bool isPositive;
    // Start is called before the first frame update
    void Start()
    {
        rightDirection = 1;
        isPositive = false;
    }

    // Update is called once per frame
    void Update()
    {
        move();  
    }
    private void move()
    {

        Vector3 currentPos = this.transform.localPosition;
        if(currentPos.x<clamp.x && isPositive)
        {
            isPositive = false;
            rightDirection = -rightDirection;
        }else if (currentPos.x > clamp.y && !isPositive)
        {
            isPositive = true;
            rightDirection = -rightDirection;
        }
        transform.localPosition += Vector3.right * Time.deltaTime * rightDirection * speed;
            
    }


}
