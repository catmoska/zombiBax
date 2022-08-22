using System;
using UnityEngine;
using UnityEngine.Events;

public class stritelstvo : MonoBehaviour
{
    [Header("def")]
    public static stritelstvo sig;
    public int BlocIndex = 0;
    public GameObject[] Bloc;
    public int[] BlocColisestvo;
    [SerializeField] public GameObject[,] BlokPosision = new GameObject[100, 50];
    private Camera cam;

    [Header("kafisient")] 
    public float k = 0.9f;
    public float kMob = 0.9f;
    public float distansiaStroitelstva;
    public LayerMask maskMob;

    [Header("time")]
    public float timeStart;
    private float time;

    [Header("pleir")]
    public Transform pleirPos;

    [Header("Event")]
    public UnityEvent updeit = new UnityEvent();

    private void Awake()
    {
        sig = this;
    }

    private void Start()
    {
        time = timeStart;
        pleirPos = pleirSingenlton.pleirTransform;
        if (magazUI.sig)
            magazUI.sig.bloc.AddListener(pocupka);
        cam = Camera.main;
    }

    private void Update()
    {
        //if (Input.GetMouseButton(1)) time = -2;

        if (Input.GetMouseButton(1)/* && time < 0*/)
        {
            Vector2Int i = mesnostMaus();
            nostavkaBloca(i.x, i.y, BlocIndex);
            
            //time = timeStart;
        }
    }

    private void pocupka(int i)
    {
        BlocColisestvo[i] += 10;
        updeit.Invoke();
    }

    public bool nostavkaBloca(int X,int Y,int BlocIndexx,bool kreativ = false)
    {
        if (X >= 100 || Y >= 50 || X < 0 || Y < 0) return false;
        if (BlokPosision[X, Y] == null)
        {
            if (!kreativ && !NroverkaBlokov(X, Y)) return false;

            Vector2 pos = new Vector2((float)(X * k), (float)(Y * k));

            if (!kreativ && Vector2.Distance(pos, pleirPos.position) > distansiaStroitelstva) return false;

            if (!kreativ && NroverkaMob(X,Y)) return false;

            if (!kreativ)
            {
                if (BlocColisestvo[BlocIndexx] <= 0) return false;
                BlocColisestvo[BlocIndexx]--;
                updeit.Invoke();
            }
            BlokPosision[X, Y] =
                Instantiate(Bloc[BlocIndexx], pos, Quaternion.identity);
            return true;
        }
        return false;
    }


    public bool NroverkaBlokov(int X, int Y)
    {
        if (X == 0 || Y == 0 || X == 99 || Y == 49)
            return true;
        for (int i = 0; i < 4; i++)
        {
            if (BlokPosision[
                X + (i<2?((i % 2 == 0 ? -1 : 1)) :0),
                Y + (i > 1 ? ((i % 2 == 0 ? -1 : 1)) : 0)
                ] != null)
                return true;
        }
        for (int i = 0; i < 4; i++)
        {
            if (BlokPosision[
                X + (i % 2 == 0 ? -1 : 1),
                Y + (((i % 2 != 0) || i == 2) && i != 3 ? -1 : 1)
                ] != null)
                return true;
        }
        return false;
    }

    public bool NroverkaMob(int X, int Y)
    {
        return Physics2D.OverlapCircle(new Vector2((float)(X * k), (float)(Y * k)), kMob, maskMob);
    }

    public Vector2Int mesnost(float xMays, float yMays)
    {
        return new Vector2Int((int)Math.Round(xMays / k), (int)Math.Round(yMays / k));
    }

    public Vector2Int mesnost(Vector2 vec)
    {
        return new Vector2Int((int)Math.Round(vec.x / k), (int)Math.Round(vec.y / k));
    }

    public Vector2Int mesnostMaus()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        float xMays = ray.origin.x;
        float yMays = ray.origin.y;
        
        return mesnost(xMays,  yMays);
    }

    public bool lomats(int X, int Y, int Ur)
    {
        if (X >= 100 || Y >= 50 || X < 0 || Y < 0 || BlokPosision[X, Y] == null) return false;
        bloc Blo = BlokPosision[X, Y].GetComponent<bloc>();
        bool i = Blo.lomat(Ur);
        if(i&& Blo.id != -1) BlocColisestvo[Blo.id]++;
        updeit.Invoke();
        return true;
    }

    public bool lomats(Vector2Int pos, int Ur)
    {
        return lomats(pos.x, pos.y, Ur);
    }

    public int getKolisestvoReltaim()
    {
        return BlocColisestvo[BlocIndex];
    }
}
