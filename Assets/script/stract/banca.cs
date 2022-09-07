using UnityEngine;

public class banca : MonoBehaviour
{
    public static banca sig;

    public Animator An;
    private bool sostoinia;

    private void Awake()
    {
        sig = this;
    }

    private void Start()
    {
        bool i = GlobalTime.sig.getBoolDei();
        sostoinia = i;
        An.SetBool("nrasa", !i);
        
    }

    private void FixedUpdate()
    {
        bool i = GlobalTime.sig.getBoolDei();
        if (sostoinia != i)
        {
            sostoinia = i;
            An.SetBool("nrasa", !i);
        }
    }
}
