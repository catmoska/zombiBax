using UnityEngine;
using UnityEngine.Events;

public class mobUpdeit : MonoBehaviour
{
    public static mobUpdeit sig;
    public UnityEvent Updeitas = new UnityEvent();
    public UnityEvent FUpdeitas = new UnityEvent();

    private void Awake()
    {
        sig = this;
    }

    private void Update()
    {
        Updeitas?.Invoke();
    }
    private void FixedUpdate()
    {
        FUpdeitas?.Invoke();
    }
}
