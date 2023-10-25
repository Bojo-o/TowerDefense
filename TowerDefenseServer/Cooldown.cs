using System;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TowerDefenseServer
{
    /// <summary>
    /// Object represinting the passage of time.
    /// </summary>
    /// <remarks>
    /// It is used as tower time to towers next attack, basic income for players.
    /// </remarks>
    public class Cooldown
    {
        /// <summary>
        /// If time has already passed.
        /// </summary>
        public bool IsReady { get; private set; }
        /// <summary>
        /// Game clock,which measures time of game.
        /// </summary>
        private readonly Stopwatch _clock;
        private long _lastTimeTick;
        /// <summary>
        /// Time in millseconds, that must pass.
        /// </summary>
        private long _cooldownTimeInMs;    
        /// <summary>
        /// Assing propetries
        /// </summary>
        /// <param name="gameClock">game clock</param>
        /// <param name="timeInMs">time of cooldown in milliseconds</param>
        public Cooldown(Stopwatch gameClock,long timeInMs)
        {
            this._cooldownTimeInMs = timeInMs;
            this._clock = gameClock;
            this.IsReady = true;
        }
        /// <summary>
        /// Change time of cooldown.
        /// </summary>
        /// <param name="timeInMs">a new cooldown time</param>
        public void Update(long timeInMs)
        {
            _cooldownTimeInMs = timeInMs;
        }
        /// <summary>
        /// Start a new passage of time.
        /// Create a new Task, in which is while loop, that ends when cooldown time passed
        /// and sets cooldown as ready.
        /// </summary>
        /// <remarks>
        /// For exapmple the tower is ready launch an new attack or players gets income golds.
        /// </remarks>
        public void Start()
        {
            this.IsReady = false;
            Task.Run(() => { Run(); });
        }
        /// <summary>
        /// Run a While loop, that ends when cooldown time passed and sets cooldown as ready.
        /// </summary>
        private void Run()
        {
            if (!_clock.IsRunning)
            {
                throw new Exception("Game clocks not running");
            }

            _lastTimeTick = _clock.ElapsedMilliseconds;

            while(_clock.ElapsedMilliseconds - _lastTimeTick < _cooldownTimeInMs)
            {

            }

            IsReady = true;
        }
    }
}
