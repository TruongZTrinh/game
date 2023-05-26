using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public GameObject player;   // Nhân vật của mình
    public float start, end;    // Điểm bắt đầu và kết thúc 


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Get the character's position (Lấy vị trí của nhân vật)
        var playerX = player.transform.position.x;

        // Get the camera's position (Lấy vị trí của camera)
        var camX = transform.position.x;
        var camY = transform.position.y;
        var camZ = transform.position.z;

        if (playerX > start && playerX < end)
        {
            camX = playerX; // Lấy vị trí người chơi để cập nhật cho cam
        }
        else
        {
            if (playerX < start)
                camX = start;
            if (playerX > end)
                camX = end;
        }

        // set lại ví trí cho camera
        transform.position = new Vector3(camX, camY, camZ);
    }
}
