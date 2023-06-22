using UnityEngine;

public class SpriteRotater : MonoBehaviour
{
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        //lookat the player by only rotating the y axis
        transform.LookAt(player.transform, Vector3.up);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        
    }
}
