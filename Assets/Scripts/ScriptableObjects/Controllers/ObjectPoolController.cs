using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Object Pool Controller", menuName ="Controllers/Object Pool Controller")]
public class ObjectPoolController : ScriptableObject
{
    [Header("Variables")]
    [SerializeField] GameObject _objectPrefab;

    ObjectPool _objectPool;

    static Transform _objectPoolsParent;

    public GameObject prefab { get { return _objectPrefab; } }

    public ObjectPool objectPool
    {
        get
        {
            // If the instance doesn't exist, find it in the scene
            if (_objectPool == null)
            {
                GameObject emptyGameObject = new GameObject(System.String.Format("{0} Pool", _objectPrefab.name));
                emptyGameObject.transform.position = new Vector3(200f, 200f, 0f);
                emptyGameObject.transform.rotation = Quaternion.identity;
                emptyGameObject.transform.parent = objectPoolsParent;
                _objectPool = emptyGameObject.AddComponent<ObjectPool>();
            }
            // Return the instance
            return _objectPool;
        }
    }

    public Transform objectPoolsParent
    {
        get
        {
            // If the instance doesn't exist, find it in the scene
            if (_objectPoolsParent == null)
            {
                GameObject emptyGameObject = new GameObject("Object Pools");
                emptyGameObject.transform.position = Vector3.zero;
                emptyGameObject.transform.rotation = Quaternion.identity;
                _objectPoolsParent = emptyGameObject.transform;
            }
            // Return the instance
            return _objectPoolsParent;
        }
    }

    public void AddObjectsToPool(int p_objectCount)
    {
        objectPool.AddObjectsToPool(_objectPrefab, p_objectCount);
    }

    public GameObject GetObject()
    {
        if (objectPool.objects.Count < 1)
        {
            objectPool.AddObjectsToPool(_objectPrefab, 1);
        }

        return objectPool.GetObject();
    }

    public void ReturnObject(GameObject p_gameObject)
    {
        objectPool.ReturnObject(p_gameObject);
    }
}
