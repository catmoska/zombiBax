using UnityEngine;
using UnityEngine.Events;

public class pleirControlir : MonoBehaviour
{
    [Header("def")]
    public static pleirControlir sig;
    public Rigidbody2D RB;
    public casaniaNola CN;
    public UnityEvent evXodbi = new UnityEvent();
    public UnityEvent evstop = new UnityEvent();
    public UnityEvent prig = new UnityEvent();
    public bool BevXodbi;

    [Header("dvizenia")]
    public float speed = 1;
    public float jamp = 5;
    public bool novarot;
    private float moveInput;
    private float moveInputX;
    public bool dublJamp;
    public bool isGrqaund;


    private void Awake()
    {
        sig = this;
    }

    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        CN = GetComponent<casaniaNola>();
        dublJamp = true;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (CN.casania|| dublJamp))
        {
            isGrqaund = false;
            prig.Invoke();
            dublJamp = CN.casania;
            RB.velocity *= new Vector2(1,0);
            RB.AddForce(Vector2.up* jamp, ForceMode2D.Impulse);
        }
        else if(!dublJamp && CN.casania)
        {
            prig.Invoke();
            dublJamp = true;
        }
    }


    private void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        novarot = moveInput > 0;
        if (moveInput != 0)
        {
            if (!BevXodbi)
            {
                BevXodbi = true;
                evXodbi.Invoke();
            }else if (moveInputX != moveInput) evXodbi.Invoke();
            
            transform.Translate(Vector2.right * speed * moveInput * Time.deltaTime);
        }
        else if (BevXodbi)
        {
            RB.velocity *= new Vector2(0, 1);
            BevXodbi = false;
            evstop.Invoke();
        }
        moveInputX = moveInput;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "bloc" || collision.gameObject.tag == "zombi")
        {
            isGrqaund = CN.casania;
            prig.Invoke();
        }
    }

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    isGrqaund = CN.casania;
    //    prig.Invoke();
    //}
}
