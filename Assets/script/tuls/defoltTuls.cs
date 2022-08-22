using UnityEngine;

public abstract class defoltTuls : MonoBehaviour
{
    private void Awake()
    {
        videmost(false);
    }

    public void videmost(bool b)
    {
        gameObject.SetActive(b);
    }
}
