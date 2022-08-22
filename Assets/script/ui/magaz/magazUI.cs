using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class magazUI : MonoBehaviour
{
    public static magazUI sig;
    public tovar[] tovars;

    public UnityEvent<int> tuls = new UnityEvent<int>();
    public UnityEvent<int> bloc = new UnityEvent<int>();

    private void Awake()
    {
        sig = this;
    }

    private void Start()
    {
        for(int i = 0; i < tovars.Length; i++)
        {
            tovars[i].text.text = tovars[i].stoimost.ToString();
        }
    }

    public void nokunka(int i)
    {
        if (tovars[i].tuls)
        {
            tuls.Invoke(i);
            return;
        }
        bloc.Invoke(tovars[i].blocID);
        return;
    }
}

[System.Serializable]
public struct tovar{
    public float stoimost;
    public TMP_Text text;
    public bool tuls;
    public int blocID;
}
