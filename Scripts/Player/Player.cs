using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool holdingGun=false;
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;

    [SerializeField] private int maxCash;
    public int currentCash;

}
