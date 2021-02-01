using System;
using System.Collections.Generic;
using UnityEngine;

namespace Monomite.Common.Common
{
    public class UnityMainThread : MonoBehaviour
    {
        #region Singleton
        public static UnityMainThread Instance
        {
            get;
            private set;
        }
        private void CreateSingleton()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Instance = this;
            }
        }
        #endregion

        Queue<Action> Jobs = new Queue<Action>();

        private void Awake()
        {
            CreateSingleton();
        }

        private void Update()
        {
            while (Jobs.Count > 0)
            {
                Jobs.Dequeue().Invoke();
            }
        }

        public void AddJob(Action newJob)
        {
            Jobs.Enqueue(newJob);
        }
    }
}