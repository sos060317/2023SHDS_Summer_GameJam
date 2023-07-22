using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void GoInGame()
    {
        SceneManager.LoadScene("InGame");
    }
}
