using UnityEngine;

public class globalNeramenia : MonoBehaviour
{
    public static globalNeramenia sig;
    public bool fix;
    public bool debug;
    public bool fixZombi;

    public Sprite[] SpriteLomat;

    public stritelstvo stro;
    public mobUpdeit mobs;
    public GlobalTime GT;
    public magaz mag;
    public banca ban;
    public bancaHP banHP;
    public kill kills;
    public pleirSingenlton PS;
    public pleirHp PH;


    private void Awake()
    {
        Updet();
    }

    public void Updet()
    {
        sig = this;
        stritelstvo.sig = stro;
        mobUpdeit.sig = mobs;
        GlobalTime.sig = GT;
        magaz.sig = mag;
        banca.sig = ban;
        bancaHP.sig = banHP;
        kill.sig = kills;
        pleirSingenlton.signelton = PS;
        PS.upd();

        pleirHp.sig = PH;
    }




#if UNITY_EDITOR
    public void Update()
    {
        if (fix)
        {
            if (sig != this) 
            {
                Updet();

                if (fixZombi)
                {
                    GameObject[] t = GameObject.FindGameObjectsWithTag("zombi");
                    for (int i = 0; i < t.Length; i++)
                        Destroy(t[i]);
                }
                //GameObject y;
                //int i = 0;
                //do
                //{
                //    i++;
                //    y = GameObject.FindWithTag("zombi");
                //    Destroy(y);
                //    Debug.Log("ss" + y == null);
                //    if (i > 100)
                //    {
                //        Debug.Log("sss");
                //        return;
                //    }
                //} while (y != null);
            }
        }
    }
#endif

}
