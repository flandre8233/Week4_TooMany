using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAmmunitionDepot : MonoBehaviour
{
    public bool IsLoaded;

    public void OnReload()
    {
        IsLoaded = true;
        GetComponentInParent<Tank>().MyUIShower.SetAmmoGear(IsLoaded);
        GameObject SpawnPrefab = Resources.Load<GameObject>("Cannon Load");
        GameObject SpawnedObject = Instantiate(SpawnPrefab, transform.position, Quaternion.identity);
        Destroy(SpawnedObject, 5f);
    }
}
