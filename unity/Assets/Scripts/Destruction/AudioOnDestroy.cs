using UnityEngine;

public class AudioOnDestroy : MonoBehaviour
{
    [SerializeField]
    public AudioClip audioClip;
    public float volume = 1;

    private void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
            return;
        AudioSource.PlayClipAtPoint(audioClip, transform.position, volume);
    }
}
