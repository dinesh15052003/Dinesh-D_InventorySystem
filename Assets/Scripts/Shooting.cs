using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public float fireRate;

    bool shotFired;

    public void Shoot()
    {
        if (!shotFired && BagManager.availbleBulletCount > 0)
        {
            BagManager.availbleBulletCount--;
            BagManager.currentBulletCountText.text = BagManager.availbleBulletCount.ToString();

            var spawnedBullet = GameObject.Instantiate(bulletPrefab, transform.position, transform.rotation);
            var rb = spawnedBullet.GetComponent<Rigidbody>();

            rb.velocity = GameObject.Find("CameraParent").transform.forward * bulletSpeed;

            Destroy(spawnedBullet, 3f);

            shotFired = true;
            Invoke("ResetRound", fireRate);
        }
    }
    public void ResetRound()
    {
        shotFired = false;
    }
}
