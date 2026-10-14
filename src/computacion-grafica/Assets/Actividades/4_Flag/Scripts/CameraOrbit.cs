using UnityEngine;


namespace Activity.Flag
{
    public class CameraOrbit : MonoBehaviour
{
    [SerializeField] float degreesPerSecond = 45f;

    void Update()
    {
        transform.Rotate(Vector3.up * -degreesPerSecond * Time.deltaTime);
    }
}
}
