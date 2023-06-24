using UnityEngine;
using UnityEngine.Animations;

public class SpriteRotater : MonoBehaviour
{
    private GameObject player;
    [SerializeField]
    public Axis axis = Axis.Y;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        //lookat the player by only rotating the y axis
        transform.LookAt(player.transform, WorldUp);
        transform.rotation = AxisRotation;
        
    }

    public Quaternion AxisRotation => axis switch
    {
        Axis.X => Quaternion.Euler(transform.rotation.eulerAngles.x, 0, 0),
        Axis.Y => Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0),
        Axis.Z => Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z),
        _ => Quaternion.identity        
    };
    public Vector3 WorldUp => axis switch
    {
        Axis.X => Vector3.right,
        Axis.Y => Vector3.up,
        Axis.Z => Vector3.forward,
        _ => Vector3.up
    };
}

