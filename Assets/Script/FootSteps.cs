using UnityEngine;

public class FootSteps : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] Clips;
    

    private AudioSource audioSource;

    public GameObject Effect;
    public Transform Right;
    public Transform Left;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    private void RightStep()
    {
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip);
        Instantiate(Effect, Right.position, Right.rotation);
    }

    private void LeftStep()
    {
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip);
        Instantiate(Effect, Left.position, Left.rotation);
    }



    private AudioClip GetRandomClip()
    {
        return Clips[UnityEngine.Random.Range(0, Clips.Length)];   
    }
}