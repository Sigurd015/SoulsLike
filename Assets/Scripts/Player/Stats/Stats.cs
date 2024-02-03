using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/Player Stats")]
public class Stats : ScriptableObject
{
    [SerializeField]
    private int Level;

    [SerializeField]
    private float MaxHP;
    public float HP { get => HP; set => HP = Mathf.Clamp(value, 0, MaxHP); }

    [SerializeField]
    private float MaxStamina;
    public float Stamina { get => Stamina; set => Stamina = Mathf.Clamp(value, 0, MaxStamina); }

    [SerializeField]
    private float MaxMP;
    public float MP { get => MP; set => MP = Mathf.Clamp(value, 0, MaxMP); }

    [SerializeField]
    private float BaseDamage;

    [Tooltip("Modifier for the max hp, depends on HP increment")]

    [SerializeField]
    private float HpIncrement;
    [Range(0, 99)]
    [SerializeField]
    private int vitality;
    public int Vitality { get => vitality; set => vitality = Mathf.Clamp(value, 0, 99); }

    [Tooltip("Modifier for the max stamina, depends on Stamina increment")]
    [SerializeField]
    private float StaminaIncrement;
    [Range(0, 99)]
    [SerializeField]
    private int endurance;
    public int Endurance { get => endurance; set => endurance = Mathf.Clamp(value, 0, 99); }

    [Tooltip("Modifier for the max mp, depends on MP increment")]
    [SerializeField]
    private float MpIncrement;
    [Range(0, 99)]
    [SerializeField]
    private int intelligence;
    public int Intelligence { get => intelligence; set => intelligence = Mathf.Clamp(value, 0, 99); }

    public long Souls;
    [SerializeField]
    private long UpgradeRequiredSoulsMultiplier;
    private long RequiredForUpgrade { get { return Level * UpgradeRequiredSoulsMultiplier; } }
    private long LastUpgradeSouls { get { return (Level - 1) * UpgradeRequiredSoulsMultiplier; } }

    public float RunCost = 1.0f;
    public float RollCost = 15.0f;
    public float AttackCost = 5.0f;
    public float HeavyAttackCost = 15.0f;
    public float BlockCost = 20.0f;

    public float StaminaAutoRecoverDelayTime = 1.0f;
    public float StaminaAutoRecoverAmount = 0.3f;

    public void Init()
    {
        Calculate();

        HP = MaxHP;
        Stamina = MaxStamina;
        MP = MaxMP;
    }

    public void Calculate()
    {
        MaxHP = Vitality * HpIncrement;
        MaxStamina = Endurance * StaminaIncrement;
        MaxMP = Intelligence * MpIncrement;
        Level = (Vitality + Endurance + Intelligence) - 45 + 1;
    }

    public void UpgradeOrDowngrade(bool upgrade)
    {
        if (!upgrade)
        {
            Souls += LastUpgradeSouls;
        }
        else
        {
            if (!(Souls >= RequiredForUpgrade))
                return;
            Souls -= RequiredForUpgrade;
        }
    }

    public void ModifyVitality(int amount)
    {
        if (amount == 0)
            return;

        UpgradeOrDowngrade(amount > 0);
        Vitality += amount;
    }

    public void ModifyStamina(int amount)
    {
        if (amount == 0)
            return;

        UpgradeOrDowngrade(amount > 0);
        Stamina += amount;
    }

    public void ModifyIntelligence(int amount)
    {
        if (amount == 0)
            return;

        UpgradeOrDowngrade(amount > 0);
        Intelligence += amount;
    }
}