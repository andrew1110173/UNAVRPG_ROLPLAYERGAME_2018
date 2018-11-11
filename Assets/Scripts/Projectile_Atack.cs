using System.Collections;
using UnityEngine;
using Core.ControlSystem;

public class Projectile_Atack : MonoBehaviour {

    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform bulletSpawn;
    [SerializeField]
    public float bulletSpeed = 30;
    [SerializeField]
    public float lifeTime = 3;
    void Update()
    {
        if (ControlSystem.FireAtack)
        {
            Fire();
        }
    }

    private void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        Physics.IgnoreCollision(bullet.GetComponent<Collider>(), bulletSpawn.parent.GetComponent<Collider>());

        bullet.transform.position = bulletSpawn.position;

        var rot = bullet.transform.rotation.eulerAngles;

        bullet.transform.rotation = Quaternion.Euler(rot.x, transform.eulerAngles.y, rot.z);

        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * bulletSpeed, ForceMode.Impulse);

        StartCoroutine(DestroyBulletAfterTime(bullet, lifeTime));
        Debug.Log("->");
    }
    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);

        Destroy(bullet);
    }
}
