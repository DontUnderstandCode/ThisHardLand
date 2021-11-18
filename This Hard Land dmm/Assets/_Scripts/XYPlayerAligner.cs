using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XYPlayerAligner : MonoBehaviour
{
    Vector3 playerRotate; //Sets up space for the rotation of the player
    float alignment;
    float alx;
    float alz;

    // Start is called before the first frame update
    void Start()
    {
        playerRotate = transform.eulerAngles;   //Sets the Vector3 to the euler transform
        alignment = playerRotate.y;

    }

    void Align()
    {
;
 
        transform.eulerAngles.Set(alx, 0, alz);
    }

    void FixedUpdate()
    {
        playerRotate = transform.eulerAngles;
        alignment = playerRotate.y;
        alx = playerRotate.x;
        alz = playerRotate.z;

        if (alignment != 0 )
        {
            Align();
        }
    }
}
