using System;
using UnityEngine;

public class GaugeManager : MonoBehaviour
{
    public static GaugeManager instance = null;
    
    public static GaugeManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }

            return instance;
        }
    }
    
    public PlayerExp expGauge;
    public PlayerExp hpGauge;
    public PlayerExp manaGauge;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        expGauge.SetValue(0);
        
        hpGauge.SetValue(100);
        
        manaGauge.SetValue(100);
    }

    private void Update()
    {
        CheckExp();
    }

    private void CheckExp()
    {
        if (expGauge.currentValue >= expGauge.GetComponent<PlayerExp>().maxValue)
        {
            LevelUpManager.Instance.ChoiceAbility();
            expGauge.currentValue = 0;
        }
    }
}
