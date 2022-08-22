using UnityEngine;

public class pleirSingenlton : MonoBehaviour
{
    public static pleirSingenlton signelton;
    public static GameObject pleirObgect;
    public static Transform pleirTransform;

    private void Awake()
    {
        signelton = this;
        pleirObgect = gameObject;
        pleirTransform = gameObject.transform;
    }

    private void FixedUpdate()
    {
        signelton = this;
        pleirObgect = gameObject;
        pleirTransform = gameObject.transform;
    }
}
