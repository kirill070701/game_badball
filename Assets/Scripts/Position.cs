using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour
{
    static public FixedJoystick joystick;
    public static float vector = 4f;
    public static float sensitivity = 7f;
    private float jumpForce = 600f ;
    private GameObject sphere;
    public bool startConnectionObject = true;
    public void PositionObject()
    {
        sphere = GameObject.Find("Sphere1");
        sphere.transform.Translate(-vector * Time.deltaTime, (-joystick.Direction.x)*Time.deltaTime * sensitivity, 0);
    }
    public void ConnectionObject()
    {
        joystick = GameObject.Find("Fixed Joystick").GetComponent<FixedJoystick>();
    }
    public void Jump()
    {
        sphere = GameObject.Find("Sphere1");
        float positionY = sphere.transform.position.y;
        if (positionY <= 0.6f && positionY >= 0.25f)
        {
            sphere.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
