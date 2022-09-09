using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class zombi : mob
{
    [Header("def")]
    public int sostainia;
    public casaniaNola CN;
    public stritelstvo stro;
    public UnityEvent updeit;
    private Rigidbody2D rb;

    [Header("datsici")]
    public Transform blokSnizu;
    public Transform blokSenter;
    public blocDetast bloc;

    [Header("detectControl")]
    public float checkRadius;
    public LayerMask blocDetect;
    public LayerMask ZombiDetect;
    public LayerMask pleirDetect;
    public float distansiaUP;

    [Header("Dvizenia")]
    public float jamp;
    public float speed;
    public float speedStart;
    public float speedFines;
    public float speedMinus;

    [Header("time")]
    public float timeJamp;
    public float timeStartJamp;

    public float XBanca = 3;

    private void Start()
    {
        speed = speedStart;
        start();
        CN = GetComponent<casaniaNola>();
        rb = GetComponent<Rigidbody2D>();
        stro = stritelstvo.sig;
        mobUpdeit.sig.FUpdeitas.AddListener(FixedUpdates);
    }

    private void FixedUpdates()
    {
        stro = stritelstvo.sig;

        if (speed> speedFines)
            speed -= speedMinus;
        else
            speed = speedFines;
        


        if (GlobalTime.sig.getBoolDei()) {
            
            if (globalNeramenia.sig.debug) Debug.DrawRay(transform.position, Vector2.up * distansiaUP*5);
            RaycastHit2D[] o = Physics2D.RaycastAll(transform.position, Vector2.up, distansiaUP*5, blocDetect);
            if (o.Length == 0 || sostainia == 3) kill = true;
        }

        if (kill) {
            if (sostainia != -1)
                StartCoroutine(kils());
            sostainia = -1; 
        }
        else NN();

        if(timeJamp>=0)  
            timeJamp -= Time.fixedDeltaTime;
    }

    private void NN()
    {
        switch (sostainia)
        {
            case 0://idti
                idti();
                break;
            case 1://lomat
                lomat();
                break;
            case 2://zdot
                if (Random.Range(0, 2) == 0)
                    obnovleniaSostainia(1);
                if (!Physics2D.OverlapCircle(blokSenter.position, checkRadius, ZombiDetect)) obnovleniaSostainia(0);
                break;
            case 3://fineh
                float i = 3.8f - transform.position.y;
                if (Mathf.Abs(i) > 0.8f)
                {
                    if (i < 0)
                        obnovleniaSostainia(5);
                    else
                        obnovleniaSostainia(6);
                }

                bancaHP.sig.yron();
                if (transform.position.x > XBanca)
                    obnovleniaSostainia(1);
                break;
            case 4://pleir
                if (!pleirHp.sig.yron(1)) obnovleniaSostainia(1);
                else if (!Physics2D.OverlapCircle((Vector2)blokSenter.position, checkRadius, pleirDetect)) obnovleniaSostainia(1);
                break;
            case 5://fineh Sverxu
                if (transform.position.x > XBanca)
                    obnovleniaSostainia(1);

                float pos= 3.8f - transform.position.y;
                if (!(Mathf.Abs(pos) > 0.8f))
                    obnovleniaSostainia(3);

                Vector2 Vec = (Vector2)(transform.position) + Vector2.down * distansiaUP;
                bool sos = stro.lomats(stro.mesnost(Vec), 1);
                if (!sos) obnovleniaSostainia(3);
                break;
            case 6://fineh snizu
                bancaHP.sig.yron();
                jam();
                if (transform.position.x > XBanca)
                    obnovleniaSostainia(1);
                break;
            default:
                obnovleniaSostainia(1);
                Debug.LogError("zombi NN: sostainia = " + sostainia);
                break;
        }
    }

    public void idti()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        bloc.SnizuL = Physics2D.OverlapCircle(blokSnizu.position, checkRadius, blocDetect);
        bloc.SenterL = Physics2D.OverlapCircle(blokSenter.position, checkRadius, blocDetect);

        if (!bloc.SenterL)
        {
            if (Physics2D.OverlapCircle((Vector2)blokSenter.position, checkRadius, ZombiDetect)) obnovleniaSostainia(2);
            else if (Physics2D.OverlapCircle((Vector2)blokSenter.position, checkRadius, pleirDetect)) obnovleniaSostainia(4);
        }

        if (bloc.SenterL)
        {
            obnovleniaSostainia(1);
        }
        else if (bloc.SnizuL)
        {
            if (globalNeramenia.sig.debug) Debug.DrawRay(transform.position, Vector2.up * distansiaUP);
            RaycastHit2D[] o = Physics2D.RaycastAll(transform.position, Vector2.up, distansiaUP, blocDetect);
            if (o.Length == 0) jam();
            else obnovleniaSostainia(1);
        }

        if (transform.position.x <= XBanca)
            obnovleniaSostainia(3);
    }

    public void lomat()
    {
        bloc.SenterL = Physics2D.OverlapCircle(blokSenter.position, checkRadius, blocDetect);
        if (globalNeramenia.sig.debug) Debug.DrawRay(transform.position, Vector2.up * distansiaUP);

        if (bloc.SenterL)
        {
            Vector2 Vec = (Vector2)(blokSenter.position) + Vector2.left * 0.2f;
            bool sos = stro.lomats(stro.mesnost(Vec), 1);
            if (!sos) obnovleniaSostainia(0);
        }
        else if ((Physics2D.RaycastAll(transform.position, Vector2.up, distansiaUP, blocDetect)).Length != 0)
        {
            Vector2 Vec = (Vector2)(transform.position) + Vector2.up * 1.3f;
            bool sos = stro.lomats(stro.mesnost(Vec), 1);
            if (!sos) obnovleniaSostainia(0);
        }
        else obnovleniaSostainia(0);
    }




    public void jam()
    {
        if (timeJamp > 0) return;
        if(CN.casania) rb.AddForce(new Vector2(0, jamp), ForceMode2D.Impulse);
        timeJamp = timeStartJamp;
        //Debug.Log("jam" + CN.casania);
    }

    public IEnumerator kils()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    private void obnovleniaSostainia(int i)
    {
        sostainia = i;
        updeit.Invoke();
    }
}

[System.Serializable]
public struct blocDetast
{
    public bool SnizuL;
    public bool SenterL;
}