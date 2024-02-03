using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : IPlayerInput
{
    private Button runBtn = new Button();
    private Button rightAtkBtn = new Button();
    private Button leftAtkBtn = new Button();
    private Button rightHAtkBtn = new Button();
    private Button leftHAtkBtn = new Button();
    private Button lockBtn = new Button();
    private Button actionBtn = new Button();
    private Button itemTopBtn = new Button();
    private Button itemDownBtn = new Button();
    private Button itemLeftBtn = new Button();
    private Button itemRightBtn = new Button();
    private Button itemUseBtn = new Button();

    private KeyMap Keymap => Settings.Instance.KeyMap;

    void Update()
    {
        runBtn.Tick(Input.GetKey(Keymap.Run), Time.deltaTime);
        leftAtkBtn.Tick(Input.GetKey(Keymap.LeftAtk), Time.deltaTime);
        rightAtkBtn.Tick(Input.GetKey(Keymap.RightAtk), Time.deltaTime);
        leftHAtkBtn.Tick(Input.GetKey(Keymap.LeftHAtk), Time.deltaTime);
        rightHAtkBtn.Tick(Input.GetKey(Keymap.RightHAtk), Time.deltaTime);
        lockBtn.Tick(Input.GetKey(Keymap.Lockon), Time.deltaTime);
        actionBtn.Tick(Input.GetKey(Keymap.Action), Time.deltaTime);
        itemLeftBtn.Tick(Input.GetKey(Keymap.ItemLeft), Time.deltaTime);
        itemRightBtn.Tick(Input.GetKey(Keymap.ItemRight), Time.deltaTime);
        itemTopBtn.Tick(Input.GetKey(Keymap.ItemUp), Time.deltaTime);
        itemDownBtn.Tick(Input.GetKey(Keymap.ItemDown), Time.deltaTime);
        itemUseBtn.Tick(Input.GetKey(Keymap.ItemUse), Time.deltaTime);

        Jup = (Input.GetKey(Keymap.UpArrow) ? 1.0f : 0) - (Input.GetKey(Keymap.DownArrow) ? 1.0f : 0);
        Jright = (Input.GetKey(Keymap.RightArrow) ? 1.0f : 0) - (Input.GetKey(Keymap.LeftArrow) ? 1.0f : 0);

        TargetDup = (Input.GetKey(Keymap.MoveForward) ? 1.0f : 0) - (Input.GetKey(Keymap.MoveBackward) ? 1.0f : 0);
        TargetDright = (Input.GetKey(Keymap.MoveRight) ? 1.0f : 0) - (Input.GetKey(Keymap.MoveLeft) ? 1.0f : 0);

        if (!InputEnabled)
        {
            TargetDup = 0;
            TargetDright = 0;
        }

        Dup = Mathf.SmoothDamp(Dup, TargetDup, ref DupVelocity, 0.1f);
        Dright = Mathf.SmoothDamp(Dright, TargetDright, ref DrightVelocity, 0.1f);

        UpdateDmagDvec(Dup, Dright);

        Running = (runBtn.IsPressing && !runBtn.IsDelaying) || runBtn.IsExtending;
        Jump = runBtn.OnPressed && Running;
        Roll = runBtn.OnReleased && runBtn.IsDelaying;
        LeftAtk = leftAtkBtn.OnReleased;
        RightAtk = rightAtkBtn.OnReleased;
        LeftHAtk = leftHAtkBtn.OnReleased;
        RightHAtk = rightHAtkBtn.OnReleased;
        Defense = leftAtkBtn.IsPressing;
        Lockon = lockBtn.OnPressed;
        Action = actionBtn.OnPressed;

        ShortcutLeftSelect = itemLeftBtn.OnReleased && itemLeftBtn.IsDelaying;
        ShortcutRightSelect = itemRightBtn.OnReleased && itemRightBtn.IsDelaying;
        ShortcutTopSelect = itemTopBtn.OnReleased && itemTopBtn.IsDelaying;
        ShortcutDownSelect = itemDownBtn.OnReleased && itemDownBtn.IsDelaying;

        ShortcutItemUse = itemUseBtn.OnReleased && itemUseBtn.IsDelaying;
    }
}