using UnityEngine;
using UnityEngine.SceneManagement;

public class kill : MonoBehaviour
{
    public static kill sig;
    public GameObject canv;
    public GameObject kilsGameObject;

    private void Awake()
    {
        sig = this;
    }

    public void kils() 
    {
        pleirSingenlton.signelton.gameObject.SetActive(false);
        canv.SetActive(false);
        kilsGameObject.SetActive(true);
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

