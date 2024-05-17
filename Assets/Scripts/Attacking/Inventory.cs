using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] int maxConsumables = 5;
    [SerializeField] int maxGuns = 2;

    [SerializeField] Consumable[] consumables;
    [SerializeField] public Gun[] guns;

    public int currentGunIndex;

    private void Start()
    {
        currentGunIndex = 0;
    }

    private void Update()
    {
        SwitchGun();
    }

    private void SwitchGun()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (currentGunIndex >= guns.Length - 1)
            {
                currentGunIndex = 0;
            }
            else
            {
                currentGunIndex += 1;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (currentGunIndex <= 0)
            {
                currentGunIndex = guns.Length - 1;
            }
            else
            {
                currentGunIndex -= 1;
            }
        }
    }
}
