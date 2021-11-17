using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    public int selectedGun = 0;

    private void Start()
    {
        selectGun();
    }

    private void Update()
    {
        controlSwitch();
    }

    private void controlSwitch()
    {
        int previousGun = selectedGun;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedGun >= transform.childCount - 1)
            {
                selectedGun = 0;
            }
            else
            {
                selectedGun++;
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedGun <= 0)
            {
                selectedGun = transform.childCount - 1;
            }
            else
            {
                selectedGun--;
            }
        }

        if (previousGun != selectedGun)
        {
            selectGun();
        }
    }

    private void selectGun()
    {
        int atual = 0;
        foreach (Transform gun in transform)
        {
            if (atual == selectedGun)
            {
                gun.gameObject.SetActive(true);
            }
            else
            {
                gun.gameObject.SetActive(false);
            }
            atual++;
        }
    }
}
