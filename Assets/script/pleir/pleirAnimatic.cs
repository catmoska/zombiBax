using UnityEngine;

public class pleirAnimatic : MonoBehaviour
{
    public Animator an;
    public SpriteRenderer SR;

    private void Start()
    {
        an = GetComponent<Animator>();
        SR = GetComponent<SpriteRenderer>();

        pleirControlir.sig.evXodbi.AddListener(xodba);
        pleirControlir.sig.evstop.AddListener(stop);
        pleirControlir.sig.prig.AddListener(prig);
    }

    private void xodba()
    {
        an.SetBool("xodba", true);
        SR.flipX = pleirControlir.sig.novarot;
    }

    private void stop()
    {
        an.SetBool("xodba", false);
    }

    private void prig()
    {
        an.SetBool("nrig", !pleirControlir.sig.isGrqaund);
    }
}
