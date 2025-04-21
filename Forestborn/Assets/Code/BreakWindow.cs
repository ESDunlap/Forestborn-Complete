using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakWindow : MonoBehaviour
{
    [SerializeField] AudioClip[] destructionNoise;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "thrownRock(Clone)")
        {
            StartCoroutine(destroyedGlass());
            Debug.Log("*CRASH*");
        }
    }

    IEnumerator destroyedGlass()
    {
        int index = UnityEngine.Random.Range(0, destructionNoise.Length);
        AudioClip breakSound = destructionNoise[index];
        GetComponent<AudioSource>().PlayOneShot(breakSound);
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(3);
        Destroy(this.transform.gameObject);
    }
}
