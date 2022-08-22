using UnityEngine;

public class globalNeramenia : MonoBehaviour
{
    public static globalNeramenia sig;
    public bool fix;
    public bool debug;

    public Sprite[] SpriteLomat;


    private void Awake()
    {
        sig = this;
    }

    public void Update()
    {
        if (fix)
        {
            sig = this;
        }
    }
}
