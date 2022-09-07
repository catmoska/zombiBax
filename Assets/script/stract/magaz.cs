using UnityEngine;

public class magaz : MonoBehaviour
{
    public static magaz sig;

    public Animator An;
    private bool sostoinia;

    public Animator AnUI;
    public GameObject knopka;

    public bool casania;
    public bool nazatia;
    public bool knopkaUpdeit;

    public bool torg;


    private void Awake()
    {
        sig = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == pleirSingenlton.pleirObgect)
        {
            casania = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == pleirSingenlton.pleirObgect)
        {
            casania = false;
            AnUI.SetBool("bit", false);
            nazatia = false;
        }
    }

    private void Start()
    {
        An = GetComponent<Animator>();
        knopka.SetActive(false);

        bool i = GlobalTime.sig.getBoolDei();
        sostoinia = i;
        An.SetBool("nrasa", !i);
    }

    private void FixedUpdate()
    {
        bool  i = GlobalTime.sig.getBoolDei();
        if (sostoinia != i) {
            sostoinia = i;
            An.SetBool("nrasa", !i);
        }

        if (knopkaUpdeit !=(casania && !nazatia))
        {
            knopkaUpdeit = (casania && !nazatia);
            knopka.SetActive((casania && !nazatia));
            if(!casania) nazatia = false;
            AnUI.SetBool("bit", nazatia);
        }

        torg = casania && nazatia;
    }

    private void Update()
    {
        sig = this;
        if (Input.GetKeyDown(KeyCode.E)) nazatia = !nazatia;
    }
}
