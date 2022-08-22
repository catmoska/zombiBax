using UnityEngine;

public class GlobalTime : MonoBehaviour
{
    public static GlobalTime sig;
    public float time;
    public float deiTime;
    public float nitTime;

    private void Awake()
    {
        sig = this;
    }


    private void FixedUpdate()
    {
        sig = this;
        time += Time.fixedDeltaTime;
    }

    public int getDei()
    {
        return (int)(time / (deiTime + nitTime));
    }

    public bool getBoolDei()
    {
        int i1 = (int)(time / (deiTime + nitTime));
        int i2 = (int)((time + nitTime) / (deiTime + nitTime));
        if (i1 == i2) return true;
        return false;
    }

    public float timeDeika()
    {
        float i = (time / (deiTime + nitTime));
        return i - (int)i;
    }
}
