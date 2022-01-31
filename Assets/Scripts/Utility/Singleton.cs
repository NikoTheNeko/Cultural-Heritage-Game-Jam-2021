using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance;

    protected void Awake()
    {
        // If Instance has not been set, populate it
        // Otherwise, destroy the new instance of this Singleton
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this as T;

        // If the Singleton is on the parent object, don't destroy
        // the gameObject on scene changes
        if (transform.parent == null)
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
