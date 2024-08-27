using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Hamburguesa;
    float time; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if( time >= 2)
        {
            CrearHamburguesa();
            time = 0; 
        }
    }
    private void CrearHamburguesa()
    {
        int RandomPosX = Random.Range(-5,5); 
        int RandomPosY = Random.Range(-5, 5);
        Instantiate(Hamburguesa, new Vector2(RandomPosX, RandomPosY), Quaternion.identity);
    }
    
}
