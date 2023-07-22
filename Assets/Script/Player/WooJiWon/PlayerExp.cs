using UnityEngine;
using UnityEngine.UI;

public class PlayerExp : MonoBehaviour
{
    [SerializeField] private Image valueBar;
    
    public float maxValue = 100.0f;
    public float currentValue = 0;

    void Update()
    {
        ValueUp();
        UpdateValue();
    }
    
    // 1. Value를 Set해주는 함수
    public void SetValue(float value)
    {
        currentValue += value;
        valueBar.fillAmount = currentValue / maxValue;
    }


    private void UpdateValue()
    {
        valueBar.fillAmount = currentValue / maxValue;
    }
    
    private void ValueUp()
    {
        if (currentValue >= maxValue)
            currentValue = maxValue;
        
        if (currentValue <= 0)
            currentValue = 0;
    }
}
