using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = System.Random;

public class PowerUpScript : MonoBehaviour
{
    public GameObject powerUpPrefab;

    public void SpawnNewPowerUp(Vector3 position)
    {
         var powerInstance = Instantiate(powerUpPrefab);
         powerInstance.transform.position = position;
         var powerSelector = powerInstance.GetComponent<PowerUp>();
         var randomInt = UnityEngine.Random.Range(1, 5);
         powerSelector.SelectColor(randomInt);
    }
}
