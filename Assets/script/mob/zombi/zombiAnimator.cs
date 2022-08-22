using UnityEngine;

public class zombiAnimator : MonoBehaviour
{
    public Animator An;
    public zombi Zom;
    public Transform PT;
    public float distansia;
    public bool sostainia;

    private void Start()
    {
        An = GetComponent<Animator>();
        Zom.updeit.AddListener(updeit);
        sostainia = true;
        PT = pleirSingenlton.pleirTransform;
        mobUpdeit.sig.FUpdeitas.AddListener(FixedUpdates);
    }

    private void FixedUpdates()
    {
        if(!PT) PT = pleirSingenlton.pleirTransform;
        float i =Vector2.Distance(PT.position, transform.position);
        bool so = distansia > i;

        if (so != sostainia)
        {
            sostainia = so;
            An.enabled = so;
        }
    }

    private void updeit()
    {
        int i = Zom.sostainia;

        if (i == 0)
            An.SetInteger("sostoania", 1);
        else if (i == 1 || i==3)
            An.SetInteger("sostoania", 2);
        else
            An.SetInteger("sostoania", 0);
    }
}
