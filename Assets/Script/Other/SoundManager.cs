using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] private AudioSource tSfxSource;

    private void Awake()
    {
        MakeInstance();
    } 

    public void MakeInstance()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlaySFX(AudioClip clip)
    {
        tSfxSource.PlayOneShot(clip);
    }
}
