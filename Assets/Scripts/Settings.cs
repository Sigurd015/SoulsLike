using System;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting;

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
    public KeyCode RightAtk = KeyCode.H;
    public KeyCode LeftAtk = KeyCode.LeftShift;
    public KeyCode RightHAtk = KeyCode.U;
    public KeyCode LeftHAtk = KeyCode.Tab;
    public KeyCode Lockon = KeyCode.V;
    public KeyCode Action = KeyCode.F;
    public KeyCode ItemUp = KeyCode.R;
    public KeyCode ItemDown = KeyCode.B;
    public KeyCode ItemLeft = KeyCode.Q;
    public KeyCode ItemRight = KeyCode.E;
    public KeyCode ItemUse = KeyCode.T;
}

[Serializable]
public struct SettingsData
{
    public KeyMap KeyMap;
}

public class Settings
{
    private SettingsData settingsData;
    public KeyMap KeyMap { get => settingsData.KeyMap; }

    private static Settings instance;
    public static Settings Instance { get => instance ??= new Settings(); }

    private static string path = "settings.dat";

    private Settings()
    {
        settingsData = DeSerialize<SettingsData>(path);
    }

    public bool Serialize<T>(T obj, string path)
    {
        try
        {
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, obj);
            }
            return true;
        }
        catch (Exception)
        {
            Debug.LogError("Failed to serialize settings data to " + path);
            return false;
        }
    }

    public T DeSerialize<T>(string path) where T : new()
    {
        T temp = new T();
        try
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                BinaryFormatter bf = new BinaryFormatter();
                temp = (T)bf.Deserialize(fs);
            }
            return temp;
        }
        catch (Exception)
        {
            Debug.LogError("Failed to deserialize settings data from " + path);
            return temp;
        }
    }
}
