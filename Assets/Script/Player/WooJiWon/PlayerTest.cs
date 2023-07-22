using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    public float radius;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Hit();
    }

    void Hit()
    {
        if(Input.GetKeyDown(KeyCode.Q))
            GaugeManager.Instance.expGauge.SetValue(-10);
        
        if(Input.GetKeyDown(KeyCode.W))
            GaugeManager.Instance.expGauge.SetValue(10);
        
        if(Input.GetKeyDown(KeyCode.A))
            GaugeManager.Instance.hpGauge.SetValue(-10);
        
        if(Input.GetKeyDown(KeyCode.S))
            GaugeManager.Instance.hpGauge.SetValue(10);
        
        if(Input.GetKeyDown(KeyCode.Z))
            GaugeManager.Instance.manaGauge.SetValue(-10);
        
        if(Input.GetKeyDown(KeyCode.X))
            GaugeManager.Instance.manaGauge.SetValue(10);
    }
}
