using UnityEngine;

public class destroyedTower : MonoBehaviour
{
    [SerializeField] AudioClip[] explosionSounds;
    void Start()
    {
        int index = UnityEngine.Random.Range(0, explosionSounds.Length);
        AudioClip explosion = explosionSounds[index];
        GetComponent<AudioSource>().PlayOneShot(explosion);
    }
}
