using UnityEngine;

public class mob : MonoBehaviour
{
    [Header("mob")]
    public float startHp;
    public float HP;//{ get; private set; }
    public bool kill;
    public Color colKillPS;

    private void Start()
    {
        start();
    }

    protected void start()
    {
        HP = startHp;
    }

    public virtual void uron(float ur)
    {
        if (ur <= 0 || kill) return;
        HP -= ur;
        //Debug.Log(ur + "    ssssssssssssssss");
        if (HP <= 0)
            kill = true;
    }
}
