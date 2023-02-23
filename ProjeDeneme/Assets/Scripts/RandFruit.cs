using System;
using System.Collections;
using System.Collections.Generic;
using Random = System.Random;
using UnityEngine;


public class RandFruit : MonoBehaviour
{
    

    [SerializeField] GameObject[] fruits = new GameObject[5];
    [SerializeField] GameObject[] fruitSpawnPoints = new GameObject[2];
    [SerializeField] GameObject diamondPrefab;

    Random randNumsFruits = new Random();
    int fruit1;
    int fruit2;

    Random randNumsDiamonds = new Random();
    int randPosX;
    int randPosZ;
    

    Random randNumsObstacle = new Random();
    [SerializeField] GameObject obstacle;
    int randPosX2;
    int randPosZ2;

    void Start()
    {
        
        RandomNumMaker();
    }

    void Update()
    {
        
    }

    private void RandomNumMaker()
    {
        
        fruit1= randNumsFruits.Next(0, 5);
        fruit2 = randNumsFruits.Next(0, 5);
        FruitSpawner(fruit1, fruit2);

        randPosX=randNumsDiamonds.Next(0, 8);
        randPosZ = randNumsDiamonds.Next(11, 33);
        DiamondSpawner(randPosX, randPosZ);
        randPosX2 = randNumsObstacle.Next(0, 8);
        randPosZ2 = randNumsObstacle.Next(11,41);

        ObstacleSpawner(randPosX, randPosX2,randPosZ, randPosZ2);
       
    }

    private void FruitSpawner(int f1,int f2)
    {      
        Instantiate(fruits[f1], fruitSpawnPoints[0].transform);
        Instantiate(fruits[f2], fruitSpawnPoints[1].transform);
    }

    private void DiamondSpawner(int x,int z)
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(diamondPrefab, new Vector3(x, 1, z),Quaternion.identity);
            z += 2;
        }

    }

    private void ObstacleSpawner(int x1, int x2, int z1,int z2)
    {
        if (x1!=x2 &&(z2<z1 ||z2>z1+8 ))
        {
            Instantiate(obstacle, new Vector3(x2, 0.4f, z2), Quaternion.Euler(0,90,0));
        }
        else if(x2+1<8)
        {
            Instantiate(obstacle, new Vector3(x2+1, 0.4F, z2), Quaternion.Euler(0, 90, 0));
        }
        else
        {
            Instantiate(obstacle, new Vector3(1, 0.4f, z2), Quaternion.Euler(0, 90, 0));
        }
    }

   
}
