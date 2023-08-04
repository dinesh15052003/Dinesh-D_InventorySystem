using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{
    [Header("Animator")]
    public Animator animator;

    [Header("Sounds")]
    public AudioClip emptyGunAudio;
    public AudioClip shootAudio1;
    public AudioClip shootAudio2;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (BagManager.hasWeapon && BagManager.availbleBulletCount == 0)
            {
                audioSource.PlayOneShot(emptyGunAudio);
            }
            if (BagManager.hasWeapon && BagManager.availbleBulletCount > 0)
            {
                if (BagManager.currentGun == "M416")
                    audioSource.PlayOneShot(shootAudio1);
                else if (BagManager.currentGun == "AKM")
                    audioSource.PlayOneShot(shootAudio2);
                animator.SetTrigger("Shoot");
                GameObject.Find("Muzzle").GetComponent<Shooting>().Shoot();
            }
        }
    }
 }
