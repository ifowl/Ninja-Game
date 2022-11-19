using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform player;
    private float ypos;
    private float yposLast;

    void Start()
    {
        yposLast = -20;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.y < -2.5)
        {
            if (yposLast == -20)
            {
                yposLast = player.position.y + 1f;
            }
            ypos = yposLast;
        }
        else ypos = player.position.y + 1f;
        transform.position = new Vector3(player.position.x, ypos, transform.position.z);
    }


}
