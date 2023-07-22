using UnityEngine;

public class GaugeManager : MonoBehaviour
{
    public static GaugeManager Instance;
    public PlayerExp expGauge;
    public PlayerExp hpGauge;
    public PlayerExp manaGauge;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        expGauge.SetValue(0);
        
        hpGauge.SetValue(100);
        
        manaGauge.SetValue(100);
    }
}
