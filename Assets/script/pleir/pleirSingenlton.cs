using UnityEngine;

public class pleirSingenlton : MonoBehaviour
{
    public static pleirSingenlton signelton;
    public static GameObject pleirObgect;
    public static Transform pleirTransform;

    private void Awake()
    {
        upd();
    }

    private void FixedUpdate()
    {
        upd();
    }

    public void upd()
    {
        signelton = this;
        pleirObgect = gameObject;
        pleirTransform = gameObject.transform;
    }
}
