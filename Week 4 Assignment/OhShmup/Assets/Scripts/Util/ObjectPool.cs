﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Provides object pooling for bullets and enemies
/// </summary>
public class ObjectPool : MonoBehaviour, IBulletCreatedInvoker, IEnemyCreatedInvoker
{
    static GameObject prefabBullet;
    static GameObject prefabEnemy;
    static Dictionary<PooledObjectName, List<GameObject>> pools;

    // events invoked by class (for autograding only)
    static BulletCreated bulletCreated = new BulletCreated();
    static EnemyCreated enemyCreated = new EnemyCreated();

    #region Constructor

    // Uncomment the code below after you copy this class into the console
    // app for the automated grader. DON'T uncomment it now; it won't
    // compile in a Unity project

    /// <summary>
    /// Constructor
    /// 
    /// Note: The class in the Unity solution doesn't use a constructor;
    /// this constructor is to support automated grading
    /// </summary>
    /// <param name="gameObject">the game object the script is attached to</param>
    //public ObjectPool(GameObject gameObject) :
    //    base(gameObject)
    //{
    //    EventManager.AddBulletCreatedInvoker(this);
    //    EventManager.AddEnemyCreatedInvoker(this);
    //}

    #endregion

    /// <summary>
    /// Initializes the pools
    /// </summary>
    public static void Initialize()
    {
        // load prefabs
        // Caution: Don't change the location of the prefabs in the Resources folder
        prefabBullet = Resources.Load<GameObject>("Bullet");
        prefabEnemy = Resources.Load<GameObject>("Enemy");

        // initialize dictionary
        pools = new Dictionary<PooledObjectName, List<GameObject>>();
        pools.Add(PooledObjectName.Bullet,
            new List<GameObject>(GameConstants.InitialBulletPoolCapacity));
        pools.Add(PooledObjectName.Enemy,
            new List<GameObject>(GameConstants.InitialEnemyPoolCapacity));

        // fill bullet pool

        // fill enemy pool

    }

    /// <summary>
    /// Gets a bullet object from the pool
    /// </summary>
    /// <returns>bullet</returns>
    public static GameObject GetBullet()
    {
        // replace code below with correct code
        return null;
    }

    /// <summary>
    /// Gets an enemy object from the pool
    /// </summary>
    /// <returns>enemy</returns>
    public static GameObject GetEnemy()
    {
        // replace code below with correct code
        return null;
    }

    /// <summary>
    /// Gets a pooled object from the pool
    /// </summary>
    /// <returns>pooled object</returns>
    /// <param name="name">name of the pooled object to get</param>
    static GameObject GetPooledObject(PooledObjectName name)
    {
        List<GameObject> pool = pools[name];

        // check for available object in pool
        if (pool.Count > 0)
        {
            // remove object from pool and return (replace code below)
            return null;
        }
        else
        {
            // pool empty, so expand pool and return new object (replace code below)
            return null;
        }
    }

    /// <summary>
    /// Returns a bullet object to the pool
    /// </summary>
    /// <param name="bullet">bullet</param>
    public static void ReturnBullet(GameObject bullet)
    {
        // add your code here
    }

    /// <summary>
    /// Returns an enemy object to the pool
    /// </summary>
    /// <param name="enemy">enemy</param>
    public static void ReturnEnemy(GameObject enemy)
    {
        // add your code here
    }

    /// <summary>
    /// Returns a pooled object to the pool
    /// </summary>
    /// <param name="name">name of pooled object</param>
    /// <param name="obj">object to return to pool</param>
    public static void ReturnPooledObject(PooledObjectName name,
        GameObject obj)
    {
        // add your code here

    }

    /// <summary>
    /// Gets a new object
    /// </summary>
    /// <returns>new object</returns>
    static GameObject GetNewObject(PooledObjectName name)
    {
        GameObject obj;
        if (name == PooledObjectName.Bullet)
        {
            obj = GameObject.Instantiate(prefabBullet);
            bulletCreated.Invoke(obj);
            obj.GetComponent<Bullet>().Initialize();
        }
        else
        {
            obj = GameObject.Instantiate(prefabEnemy);
            enemyCreated.Invoke(obj);
            obj.GetComponent<Enemy>().Initialize();
        }
        obj.SetActive(false);
        GameObject.DontDestroyOnLoad(obj);
        return obj;
    }

    /// <summary>
    /// Removes all the pooled objects from the object pools
    /// </summary>
    public static void EmptyPools()
    {
        // add your code here
    }

    #region Methods to support autograder

    /// <summary>
    /// Adds the given listener for the BulletCreated event
    /// </summary>
    /// <param name="listener">listener</param>
    public void AddBulletCreatedListener(UnityAction<GameObject> listener)
    {
        bulletCreated.AddListener(listener);
    }

    /// <summary>
    /// Adds the given listener for the EnemyCreated event
    /// </summary>
    /// <param name="listener">listener</param>
    public void AddEnemyCreatedListener(UnityAction<GameObject> listener)
    {
        enemyCreated.AddListener(listener);
    }

    /// <summary>
    /// Gets the current pool count for the given pooled object
    /// </summary>
    /// <param name="name">pooled object name</param>
    /// <returns>current pool count</returns>
    public int GetPoolCount(PooledObjectName name)
    {
        if (pools.ContainsKey(name))
        {
            return pools[name].Count;
        }
        else
        {
            // should never get here
            return -1;
        }
    }

    /// <summary>
    /// Gets the current pool capacity for the given pooled object
    /// </summary>
    /// <param name="name">pooled object name</param>
    /// <returns>current pool capacity</returns>
    public int GetPoolCapacity(PooledObjectName name)
    {
        if (pools.ContainsKey(name))
        {
            return pools[name].Capacity;
        }
        else
        {
            // should never get here
            return -1;
        }
    }

    #endregion
}
