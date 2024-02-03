using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    private List<EventDetector> overlapEDetectors = new List<EventDetector>();
    private ActorManager am;
    void Start()
    {
        am = GetComponentInParent<ActorManager>();
    }

    private void OnTriggerStay(Collider other)
    {
        EventDetector[] ecastms = other.GetComponents<EventDetector>();
        foreach (var ecastm in ecastms)
        {
            if (!overlapEDetectors.Contains(ecastm) && ecastm.Enable)
            {
                overlapEDetectors.Add(ecastm);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        EventDetector[] ecastms = other.GetComponents<EventDetector>();
        foreach (var ecastm in ecastms)
        {
            if (overlapEDetectors.Contains(ecastm))
            {
                overlapEDetectors.Remove(ecastm);
            }
        }
    }
}