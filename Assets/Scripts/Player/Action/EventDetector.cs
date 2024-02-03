using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventType
{
    OpenBox, FrontStab, LeverUp, OpenDoor
}

public class EventDetector : MonoBehaviour
{
    public bool Enable;
    public EventType EventType;
    public Vector3 Offset;
    //public IItem ItemData;
    public int ItemCount;

    private IActorManager am;
    private void Start()
    {
        am = GetComponentInParent<IActorManager>();
#if UNITY_EDITOR
        MeshRenderer mr = gameObject.AddComponent<MeshRenderer>();
        mr.material.color = Color.red;
        mr.enabled = true;
#endif
    }
}