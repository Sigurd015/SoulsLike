using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGroundSensor : MonoBehaviour
{
    public float Offset = 0.1f;
    public LayerMask CheckLayer;

    [SerializeField]
    private float radiusOffset = 0.05f;
    private CapsuleCollider capcol;
    private ActorController ac;
    private float radius;

    void Awake()
    {
        capcol = transform.parent.GetComponent<CapsuleCollider>();
        radius = capcol.radius - radiusOffset;
        ac = transform.parent.GetComponent<ActorController>();
    }

    void FixedUpdate()
    {
        Collider[] outputCols = Physics.OverlapCapsule(
            transform.position + transform.up * (radius - Offset),  // Top center
            transform.position + transform.up * (capcol.height - Offset) - transform.up * radius,  // Bottom center
            radius, CheckLayer);
        ac.OnGroundSensor(outputCols.Length != 0);
    }
}