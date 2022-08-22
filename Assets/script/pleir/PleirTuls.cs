using UnityEngine;
using UnityEngine.Events;


public class PleirTuls : MonoBehaviour
{
    public static PleirTuls sig;
    public defoltTuls[] tuls;
    public int sostoania { get; private set; }
    public stritelstvo stroi;
    public UnityEvent tulsUndeit = new UnityEvent();
    public UnityEvent BlocUndeit = new UnityEvent();
    public int TulsID;
    public int BlocID;

    private void Awake()
    {
        sig = this;
    }

    private void Start()
    {
        if (tuls.Length != 0)
        {
            tuls[0].videmost(true);
            sostoania = 0;
        }
        stroi = stritelstvo.sig;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift)|| Input.GetKey(KeyCode.RightShift))
        {
            BlocID = nazatia();
            if (BlocID == -1 || BlocID == 0) return;
            if (stroi.Bloc.Length-2 <= BlocID) return;
            stroi.BlocIndex = BlocID + 2;
            BlocUndeit.Invoke();
            return;
        }

        TulsID = nazatia();
        if (TulsID == -1) return;
        if (tuls.Length<= TulsID) return;
        if (sostoania == TulsID) return;
        tuls[TulsID].videmost(true);
        tuls[sostoania].videmost(false);
        sostoania = TulsID;
        tulsUndeit.Invoke();
    }



    private int nazatia(bool t = false)
    {
        if (Input.GetKeyDown(KeyCode.F))
            return 0;
        else if (Input.GetKeyDown(KeyCode.Alpha0))
            if (t) return 0;
            else return 10;
        else if (Input.GetKeyDown(KeyCode.Alpha1))
            return 1;
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            return 2;
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            return 3;
        else if (Input.GetKeyDown(KeyCode.Alpha4))
            return 4;
        else if (Input.GetKeyDown(KeyCode.Alpha5))
            return 5;
        else if (Input.GetKeyDown(KeyCode.Alpha6))
            return 6;
        else if (Input.GetKeyDown(KeyCode.Alpha7))
            return 7;
        else if (Input.GetKeyDown(KeyCode.Alpha8))
            return 8;
        else if (Input.GetKeyDown(KeyCode.Alpha9))
            return 9;
        return -1;
    }
}
