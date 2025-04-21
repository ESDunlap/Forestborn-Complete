using UnityEngine;

public class rabbitNoise : MonoBehaviour
{
    private void OnMouseDown()
    {
        GetComponent<AudioSource>().Play();
    }
}
