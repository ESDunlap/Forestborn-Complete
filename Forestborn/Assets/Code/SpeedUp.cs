using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    public float speedUpTime = 5f;
    private PlayerBehavior _player;
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            _player = GameObject.Find("Player").GetComponent<PlayerBehavior>();
            StartCoroutine(SpeedPlayerUp());
        }
    }

    IEnumerator SpeedPlayerUp()
    {
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        _player.moveSpeed *= 1.5f;
        yield return new WaitForSeconds(speedUpTime);
        _player.moveSpeed /= 1.5f;
        Destroy(this.transform.gameObject);
    }
}
