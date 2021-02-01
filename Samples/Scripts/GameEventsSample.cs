using System;
using UnityEngine;

namespace Monomite.Samples
{
    public class GameEventsSample : MonoBehaviour
    {
        #region Singleton
        public static GameEventsSample Instance
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

        private void Awake()
        {
            CreateSingleton();
        }

        public event EventHandler ToMainMenu;
        public event EventHandler ToPauseMenu;

        public event EventHandler GamePrepared;
        public event EventHandler GameStart;
        public event EventHandler GameCountdown;
        public event EventHandler<GameEndEventArgs> GameEnd;

        public void OnToMainMenu()
        {
            ToMainMenu?.Invoke(this, EventArgs.Empty);
        }

        public void OnToPauseMenu()
        {
            ToPauseMenu?.Invoke(this, EventArgs.Empty);
        }

        public void OnGamePrepared()
        {
            GamePrepared?.Invoke(this, EventArgs.Empty);
        }

        public void OnGameStart()
        {
            GameStart?.Invoke(this, EventArgs.Empty);
        }

        public void OnGameEnd(int points)
        {
            GameEndEventArgs eventArgs = new GameEndEventArgs(points);
            GameEnd?.Invoke(this, eventArgs);
        }
    }

    public class GameEndEventArgs
    {
        public int Points
        {
            get;
            private set;
        }

        public GameEndEventArgs(int points)
        {
            this.Points = points;
        }
    }
}