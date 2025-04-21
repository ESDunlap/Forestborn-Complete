using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform player;
    public Camera camera;

    private void Update()
    {
        if (Input.GetKey(KeyCode.J) && camera.orthographicSize < 20)
        {
            camera.orthographicSize += 0.2f;
        }

        if (Input.GetKey(KeyCode.K) && camera.orthographicSize > 10)
        {
            camera.orthographicSize -= 0.2f;
        }
    }

    private void LateUpdate()
    {
        Vector3 newPosition= player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
    }
}
