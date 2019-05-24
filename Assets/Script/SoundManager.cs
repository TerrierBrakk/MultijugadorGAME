using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public  AudioClip PlayerHitSound, FireSound, EnemyDeathSound,DamageMod,DamageHeavy,DamageLight;
    public AudioSource audioSrc;

    // Start is called before the first frame update
    void Awake()
    {
        StaticManager.soundmanager = this;
    }
    void Start()
    {
        FireSound = Resources.Load<AudioClip>("shoot");
        PlayerHitSound = Resources.Load<AudioClip>("hit_obstacle");
        DamageHeavy = Resources.Load<AudioClip>("damage_heavy");
        DamageMod = Resources.Load<AudioClip>("damage_mod");
        DamageLight = Resources.Load<AudioClip>("damage_light");
        
       
        audioSrc = GetComponent<AudioSource>();
    }
    
    // Update is called once per frame
    void Update()
    {
        
        
    }
    public void PlaySound(string clip)
    {
        switch (clip)
        {
            case "disparo":
                audioSrc.PlayOneShot (FireSound);
                break;

            case "choque":
                audioSrc.PlayOneShot(PlayerHitSound);
                break;
            case "heavy":
                audioSrc.PlayOneShot(DamageHeavy);
                break;
            case "moderate":
                audioSrc.PlayOneShot(DamageMod);
                break;
            case "light":
                audioSrc.PlayOneShot(DamageLight);
                break;
            default:
                print("no pasa nada D:");
                break;
            
        }
    }
}
