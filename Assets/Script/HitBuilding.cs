using UnityEngine;

public class HitBuilding : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] Clips;


    private AudioSource audioSource;

    
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

    }

    

    private void Hit()
    {
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip);
        
    }



    private AudioClip GetRandomClip()
    {
        return Clips[UnityEngine.Random.Range(0, Clips.Length)];
    }
}