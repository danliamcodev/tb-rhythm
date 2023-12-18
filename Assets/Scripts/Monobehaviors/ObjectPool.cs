using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    Queue<GameObject> _objects = new Queue<GameObject>();

    public Queue<GameObject> objects { get { return _objects; } }

    public void AddObjectsToPool(GameObject p_object, int p_objectCount)
    {
        for (int i = 0; i < p_objectCount; i++)
        {
            GameObject obj = Instantiate(p_object, this.transform.position, p_object.transform.rotation, this.transform);
            obj.SetActive(false);
            _objects.Enqueue(obj);
        }
    }

    public GameObject GetObject()
    {
        GameObject obj = _objects.Dequeue();
        return obj;
    }

    public void ReturnObject(GameObject p_gameObject)
    {
        p_gameObject.SetActive(false);
        _objects.Enqueue(p_gameObject);
    }
}
