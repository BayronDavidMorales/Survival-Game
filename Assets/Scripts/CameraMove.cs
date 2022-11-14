using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform player;
    public float speed;
    public Vector3 CameraPosition;

    // Update is called once per frame

    private void Start()
    {
        //CameraPosition = new Vector3(player.position.x + 20, player.position.y + 2, player.position.z + 2);
    }
    void FixedUpdate()
    {

        Vector3 Dposition = player.position + CameraPosition;
        Vector3 Sposition = Vector3.Lerp(transform.position, Dposition, speed * Time.deltaTime);
        //transform.LookAt(player.transform);
        transform.position = Sposition;
    }
}
