using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPlayerInput : MonoBehaviour
{
    public bool InputEnabled = true;
    public float Dmag { get; protected set; }
    public Vector3 Dvec { get; protected set; }
    public float Jup { get; protected set; }
    public float Jright { get; protected set; }
    public bool Running { get; protected set; }
    public bool Jump { get; protected set; }
    public bool Roll { get; protected set; }
    public bool Lockon { get; protected set; }
    public bool LeftAtk { get; protected set; }
    public bool RightAtk { get; protected set; }
    public bool LeftHAtk { get; protected set; }
    public bool RightHAtk { get; protected set; }
    public bool Defense { get; protected set; }
    public bool Action { get; protected set; }
    public bool ShortcutLeftSelect { get; protected set; }
    public bool ShortcutRightSelect { get; protected set; }
    public bool ShortcutTopSelect { get; protected set; }
    public bool ShortcutDownSelect { get; protected set; }
    public bool ShortcutItemUse { get; protected set; }

    protected float Dup;
    protected float TargetDup;
    protected float Dright;
    protected float TargetDright;
    protected float DupVelocity;
    protected float DrightVelocity;

    protected Vector2 SquareToCircle(Vector2 axis)
    {
        Vector2 output = Vector2.zero;
        output.x = axis.x * Mathf.Sqrt(1 - (axis.y * axis.y) / 2.0f);
        output.y = axis.y * Mathf.Sqrt(1 - (axis.x * axis.x) / 2.0f);
        return output;
    }

    protected void UpdateDmagDvec(float dup, float dright)
    {
        Vector2 axis = SquareToCircle(new Vector2(dright, dup));
        Dmag = Mathf.Sqrt((axis.x * axis.x) + (axis.y * axis.y));
        Dvec = axis.x * transform.right + axis.y * transform.forward;
    }
}