using System;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public class KeyMap
{
    public KeyCode MoveForward = KeyCode.W;
    public KeyCode MoveBackward = KeyCode.S;
    public KeyCode MoveLeft = KeyCode.A;
    public KeyCode MoveRight = KeyCode.D;
    public KeyCode Run = KeyCode.Space;
    public KeyCode UpArrow = KeyCode.I;
    public KeyCode DownArrow = KeyCode.K;
    public KeyCode LeftArrow = KeyCode.J;
    public KeyCode RightArrow = KeyCode.L;
    public KeyCode RightAttack = KeyCode.H;
    public KeyCode LeftAttack = KeyCode.LeftShift;
    public KeyCode RightHeavyAttack = KeyCode.U;
    public KeyCode LeftHeavyAttack = KeyCode.Tab;
    public KeyCode Lockon = KeyCode.V;
    public KeyCode Action = KeyCode.F;
    public KeyCode ItemUp = KeyCode.R;
    public KeyCode ItemDown = KeyCode.B;
    public KeyCode ItemLeft = KeyCode.Q;
    public KeyCode ItemRight = KeyCode.E;
    public KeyCode ItemUse = KeyCode.T;
}
