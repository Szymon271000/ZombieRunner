using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int currentWaepon = 0;
    // Start is called before the first frame update
    void Start()
    {
        SetWeaponActive();
    }

    void Update()
    {
        int previousWeapon = currentWaepon;

        ProcessKeyInput();
        ProcessScrollWheel();

        if (previousWeapon != currentWaepon)
        {
            SetWeaponActive();
        }

    }

    void ProcessScrollWheel()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (currentWaepon >= transform.childCount - 1)
            {
                currentWaepon = 0;
            }
            else
            {
                currentWaepon++;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (currentWaepon <= 0)
            {
                currentWaepon = transform.childCount - 1;
            }
            else
            {
                currentWaepon--;
            }
        }
    }

    void ProcessKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWaepon = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWaepon = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWaepon = 2;
        }
    }

    void SetWeaponActive()
    {
        int weaponIndex = 0;

        foreach (Transform weapon in transform)
        {
            if (weaponIndex == currentWaepon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }
}
