using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour 
{
    public float damage = 0.0f;
    public float weaponCoolDown = 0.0f;
    public MELEE_WEAPON weaponType = MELEE_WEAPON.BASE_WEAPON;
    public Sprite weaponImage = null;
    
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void SetDamage(float _damage)
    {
        damage = _damage;
    }

    public void SetCoolDown(float _coolDown)
    {
        weaponCoolDown = _coolDown;
    }

    public void SetType(MELEE_WEAPON _type)
    {
        weaponType = _type;
    }

    public void SetImage(Sprite _image)
    {
        weaponImage = _image;
    }

    public float GetDamage()
    {
        return damage;
    }

    public float GetCoolDown()
    {
        return weaponCoolDown;
    }

    public MELEE_WEAPON GetType()
    {
        return weaponType;
    }

    public Sprite GetImage()
    {
        return weaponImage;
    }
}
