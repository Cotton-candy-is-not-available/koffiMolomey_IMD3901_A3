using Unity.Netcode;
using UnityEngine;

public class gameManager : NetworkBehaviour
{
    // For example purposes, the projectile to spawn
    public GameObject Projectile;


    // For example purposes, an offset from the weapon
    // to spawn the projectile.

    public GameObject WeaponFiringOffset;


    public override void OnNetworkDespawn()
    {
        print("despawn"); 
    }
  


    public void FireWeapon()
    {
        var instance = Instantiate(Projectile);
        var instanceNetworkObject = instance.GetComponent<NetworkObject>();
        instance.transform.position = WeaponFiringOffset.transform.position;
        instanceNetworkObject.Spawn(true);
    }
}
