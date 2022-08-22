using UnityEngine;

public static class audios
{
    public static void plei(AudioSource ass)
    {
        ass.pitch = Random.Range(0.9f, 1.1f);
        ass.volume = Random.Range(0.9f, 1.1f);
        ass.Play();    
    }
}
