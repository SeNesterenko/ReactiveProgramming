using UnityEngine;

namespace Scenes._9._Inventory_Homework.Scripts
{
    public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        public static T Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(this);
            }

            Instance = (T) this;
            DontDestroyOnLoad(this);
        }
    }
}