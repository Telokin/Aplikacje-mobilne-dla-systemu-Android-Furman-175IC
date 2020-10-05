using System;
using UnityEngine;
using UnityEngine.AI;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField]
    private string seed = null;

    [SerializeField]
    private GameObject prefab = null;

    [SerializeField]
    private GameObject pickUp = null;

    [SerializeField]
    private GameObject player = null;

    [SerializeField]
    private GameObject chest = null;

    // public GameObject skeleton;

    [SerializeField]
    private GameObject[] enemies = null;

    [SerializeField]
    private GameObject enemy = null;

    public Vector2 mapSize = new Vector2(10, 10);

    Ceil[,] ceils;
    System.Random random;

    void Awake()
    {
        ceils = new Ceil[(int)(mapSize.x), (int)(mapSize.y)];
    }

    void Start()
    {
        random = new System.Random((!string.IsNullOrEmpty(seed)) ? seed.GetHashCode() : System.Guid.NewGuid().GetHashCode());
        BuildCeils();
        SetCeils();
        SpawnBall();
        SpawnPlayer();
        SpawnSkeleton();
        SpawnChest();


    }

    void BuildCeils()
    {
        for (int y = 0; y < mapSize.y; y++)
        {
            for (int x = 0; x < mapSize.x; x++)
            {
                GameObject newCeil = Instantiate(prefab, new Vector3(x, 0, y), Quaternion.identity) as GameObject;
                newCeil.name = string.Format("_Ceil({0},{1})", x, y);
                newCeil.transform.parent = this.transform;
                ceils[x, y] = newCeil.GetComponent<Ceil>();
            }
        }
       
    }


    void SetCeils()
    {
        int x = 0, y = 0;

        while (ceils[x, y].state != 2)
        {
            Ceil myCeil = ceils[x, y];
            Dirs myDir = (myCeil.dirs.Count > 0) ? myCeil.dirs[random.Next(0, myCeil.dirs.Count)] : Dirs.None;
            if (myDir != Dirs.None)
            {
                
                myCeil.dirs.Remove(myDir);
            }

            switch (myDir)
            {


                case Dirs.Left:
                    if (x > 0)
                    {
                        x--;
                        Ceil addCeil = ceils[x, y];

                        if (addCeil.state == 0)
                        {
                            myCeil.CreateDir(Dirs.Left);
                            addCeil.CreateDir(Dirs.Right);
                            addCeil.backWay = new Vector2(x + 1, y);
                        }
                    }

                    break;
                case Dirs.Right:
                    
                    if (x < mapSize.x - 1)
                    {
                        x++;
                        Ceil addCeil = ceils[x, y];

                        if (addCeil.state == 0)
                        {
                            myCeil.CreateDir(Dirs.Right);
                            addCeil.CreateDir(Dirs.Left);
                            addCeil.backWay = new Vector2(x - 1, y);
                        }
                    }

                    break;
                case Dirs.Top:
                    if (y < mapSize.y - 1)
                    {
                        y++;
                        Ceil addCeil = ceils[x, y];

                        if (addCeil.state == 0)
                        {
                            myCeil.CreateDir(Dirs.Top);
                            addCeil.CreateDir(Dirs.Bottom);
                            addCeil.backWay = new Vector2(x, y - 1);
                        }
                    }

                    break;
                case Dirs.Bottom:
                    if (y > 0)
                    {
                        y--;
                        Ceil addCeil = ceils[x, y];

                        if (addCeil.state == 0)
                        {
                            myCeil.CreateDir(Dirs.Bottom);
                            addCeil.CreateDir(Dirs.Top);
                            addCeil.backWay = new Vector2(x, y + 1);
                        }
                    }
                    break;
                case Dirs.None:
                    myCeil.state = 2;
                    x = (int)(myCeil.backWay.x);
                    y = (int)(myCeil.backWay.y);
                    break;

                    
            }

        }
        
    }


    public void SpawnBall()
    {
        Vector3 spawnBall = new Vector3(UnityEngine.Random.Range(0.5f, 9.5f), 0.2f, UnityEngine.Random.Range(0.5f, 9.5f));
        Instantiate(pickUp, spawnBall, gameObject.transform.rotation);
        
    }

    public void SpawnPlayer()
    {
        Vector3 spawnPlayer = new Vector3(UnityEngine.Random.Range(0.5f, 9.5f), 0.2f, UnityEngine.Random.Range(0.5f, 9.5f));
        player.gameObject.SetActive(true);
        Instantiate(player, spawnPlayer, gameObject.transform.rotation);
    }

    /* public void SpawnSkeleton()
     {
         Vector3 spawnSkeleton = new Vector3(UnityEngine.Random.Range(0f, 10f), 0.2f, UnityEngine.Random.Range(0f, 10f));
         Instantiate(skeleton, spawnSkeleton + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
     }
     */

    public void SpawnSkeleton()
    {
        Vector3 spawnEnemy = new Vector3(UnityEngine.Random.Range(0.5f, 9.5f), 0.2f, UnityEngine.Random.Range(0.5f, 9.5f));
        Instantiate(enemy, spawnEnemy, gameObject.transform.rotation);
    }

    public void SpawnChest()
    {
        Vector3 spawnChest = new Vector3(UnityEngine.Random.Range(0.5f, 9.5f), 0.2f, UnityEngine.Random.Range(0.5f, 9.5f));
        Instantiate(chest, spawnChest, gameObject.transform.rotation);
    }


}
