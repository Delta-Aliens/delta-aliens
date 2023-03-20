using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public bool X, Y, Z;

    public float XOffset, YOffset, ZOffset;

    void Start()
    {
        transform.position = new Vector3(0,YOffset,0);
    }

    void Update() 
    { 
        Vector3 targetPos = target.position;
        Vector3 currentPos = transform.position;

        transform.position = new Vector3(
                X ? targetPos.x + XOffset : currentPos.x,
                //Y ? targetPos.y + YOffset : currentPos.y,
                //Y ? Mathf.Min(currentPos.y, targetPos.y + YOffset) : currentPos.y,
                Y ? currentPos.y : currentPos.y,
                Z ? targetPos.z + ZOffset : currentPos.z);
    }
}
