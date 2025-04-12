using UnityEngine;
using UnityEngine.SceneManagement;


public class PLay : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Main Game");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
