using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float bulletSpeed;

    public void Travel(Vector3 location)
    {
        //gameObject.transform.Translate(location * bulletSpeed * Time.deltaTime, Space.World);
        Debug.Log("Yes");
        Debug.Log(location);
        transform.position = Vector3.Lerp(transform.position, location, Time.deltaTime * bulletSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}
