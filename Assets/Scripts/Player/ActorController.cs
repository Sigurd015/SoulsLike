using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Sensor
    public void OnGroundSensor(bool isGround)
    {
        //anim.SetBool("isGround", isGround);
    }

    // RootMotion
    public void OnUpdateRM(Vector3 _deltaPos)
    {
        //if (CheckAnimatorStateWithName("attack1hC"))
        //    deltaPos += 0.8f * deltaPos + 0.2f * _deltaPos;
    }
}