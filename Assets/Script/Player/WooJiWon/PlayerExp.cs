using Unity.VisualScripting;
using UnityEngine;
using Update = UnityEngine.PlayerLoop.Update;

public class PlayerExp : MonoBehaviour
{
    private float playerExp;

    void Update()
    {
        expUp();
    }
    
    private void expUp()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerExp += 10.0f;
        }
    }
}
