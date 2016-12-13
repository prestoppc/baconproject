using UnityEngine;
using System.Collections;

public class RangeWeapo : MonoBehaviour 
{
    public float damage = 0.0f;
    public float range = 0.0f;
    public float weaponCoolDown = 0.0f;
    public int ammoAmount = 0;
    public RANGE_WEAPON weaponType = RANGE_WEAPON.BASE_WEAPON;
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

    public void SetRange(float _range)
    {
        range = _range;
    }

    public void SetCoolDown(float _coolDown)
    {
        weaponCoolDown = _coolDown;
    }

    public void SetAmmo(int _ammo)
    {
        ammoAmount = _ammo;
    }

    public void SetType(RANGE_WEAPON _type)
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

    public float GetRange()
    {
        return range;
    }

    public float GetCoolDown()
    {
        return weaponCoolDown;
    }

    public int GetAmmo()
    {
        return ammoAmount;
    }

    public RANGE_WEAPON GetType()
    {
        return weaponType;
    }

    public Sprite GetImage()
    {
        return weaponImage;
    }
}
