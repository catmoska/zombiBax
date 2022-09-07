using UnityEngine;

public class bancaHP : MonoBehaviour
{
    public static bancaHP sig;
    public float Hp;
    public float HpStart;
    public float HP�ocazatel;
    public float HP�romezutoc;

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

        if (HP�ocazatel != i)
        {
            if (Mathf.Abs(HP�ocazatel - i) <= HP�romezutoc)
                HP�ocazatel = i;
            else if (HP�ocazatel > i)
                HP�ocazatel -= HP�romezutoc;
            else
                HP�ocazatel += HP�romezutoc;
        }

        Hpsca.localScale = new Vector3(HP�ocazatel, 1);
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
