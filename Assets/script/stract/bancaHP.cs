using UnityEngine;

public class bancaHP : MonoBehaviour
{
    public static bancaHP sig;
    public float Hp;
    public float HpStart;
    public float HPÇocazatel;
    public float HPÇromezutoc;

    public Transform Hpsca;

    public bool kil;


    private void Awake()
    {
        sig = this;
        Hp = HpStart;
    }

    private void FixedUpdate()
    {
        if (kil) return;
        float i = (float)((decimal)Hp/ (decimal)HpStart);

        if (HPÇocazatel != i)
        {
            if (Mathf.Abs(HPÇocazatel - i) <= HPÇromezutoc)
                HPÇocazatel = i;
            else if (HPÇocazatel > i)
                HPÇocazatel -= HPÇromezutoc;
            else
                HPÇocazatel += HPÇromezutoc;
        }

        Hpsca.localScale = new Vector3(HPÇocazatel, 1);
    }


    public void yron(float Yron = 1)
    {
        if (Yron > 0 && !kil)
        {
            Hp -= Yron;
            if (Hp <= 0)
            {
                Hp = 0;
                kill.sig.kils();
                FixedUpdate();
                kil = true;
            }
        }
    }

}
