using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = System.Random;

public class RoadManager : MonoBehaviour
{
    
    RandFruit randFruit;
    [SerializeField] GameObject[] fruits = new GameObject[5];
    [SerializeField] GameObject roadPrefab;
    [SerializeField] GameObject finalPrefab;
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] GameObject diamondPrefab;
    
    float x;
    float y;
    float z;

    Random randDiamond= new Random();
    float randDX;
    Random  randObstacle= new Random();
    float randOX;
    int randZ;
    Random randNumsFruits = new Random();
    int fruit1;
    int fruit2;
    void Start()
    {
        
        x = 3.35f;
        y = -0.4f;
        z = 25.26f;
        RoadMaker(x,y,z);
    }

    void Update()
    {
        
    }

    private void RoadMaker(float x ,float y, float z)
    {
        int i;
        for (i = 0; i < 5; i++)
        {
            Instantiate(roadPrefab, new Vector3(x, y, z + 50 * (i + 1)), Quaternion.identity);
            
            RandFruit(z + 50 * (i + 1));
            //doorNumbers.RandomNumaraCek();
        }
        FinalRoad();

    }

    public void FinalRoad()
    {
        Instantiate(finalPrefab, new Vector3(x, y, 306.75f), Quaternion.identity);
        
    }

    private void RandFruit( float z)
    {
        fruit1=randNumsFruits.Next(0,5);
        fruit2 = randNumsFruits.Next(0,5);
        Instantiate(fruits[fruit1], new Vector3(1f, 2, z+24f), Quaternion.identity);
        Instantiate(fruits[fruit2], new Vector3(5.7f, 2, z+24f), Quaternion.identity);
        RandDiamond(z+24f);
        RandObstacle(z+24f);
    }    

    private void RandDiamond(float z)
    {
        int a = (int)z;     
        randDX=randDiamond.Next(0,8);
        randZ=  randDiamond.Next(a-40,a-10);
        for (int i = 0; i < 5; i++)
        {
            Instantiate(diamondPrefab, new Vector3(randDX, 1.2f, randZ+(i+1)*2), Quaternion.identity);
        }
    }

    private void RandObstacle(float z)
    {
        int a = (int)z;
        randOX =randObstacle.Next(0,8);
        randZ=randObstacle.Next(a-40,a-10);        
        Instantiate(obstaclePrefab, new Vector3(randOX, 0.4f,  randZ), Quaternion.Euler(0, 90, 0));

    }
}
