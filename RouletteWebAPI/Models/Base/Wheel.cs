using RouletteWebAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RouletteWebAPI.Models.Base
{

    public class Wheel : RouletteBaseComponents
    {
        public readonly WheelNumber[] WheelNumbers =
{
        new WheelNumber(0, WheelNumberColour.Green),
        new WheelNumber(32, WheelNumberColour.Red),
        new WheelNumber(15, WheelNumberColour.Black),
        new WheelNumber(19, WheelNumberColour.Red),
        new WheelNumber(4, WheelNumberColour.Black),
        new WheelNumber(21, WheelNumberColour.Red),
        new WheelNumber(2, WheelNumberColour.Black),
        new WheelNumber(25, WheelNumberColour.Red),
        new WheelNumber(17, WheelNumberColour.Black),
        new WheelNumber(34, WheelNumberColour.Red),
        new WheelNumber(6, WheelNumberColour.Black),
        new WheelNumber(27, WheelNumberColour.Red),
        new WheelNumber(13, WheelNumberColour.Black),
        new WheelNumber(36, WheelNumberColour.Red),
        new WheelNumber(11, WheelNumberColour.Black),
        new WheelNumber(30, WheelNumberColour.Red),
        new WheelNumber(8, WheelNumberColour.Black),
        new WheelNumber(23, WheelNumberColour.Red),
        new WheelNumber(10, WheelNumberColour.Black),
        new WheelNumber(5, WheelNumberColour.Red),
        new WheelNumber(24, WheelNumberColour.Black),
        new WheelNumber(16, WheelNumberColour.Red),
        new WheelNumber(33, WheelNumberColour.Black),
        new WheelNumber(1, WheelNumberColour.Red),
        new WheelNumber(20, WheelNumberColour.Black),
        new WheelNumber(14, WheelNumberColour.Red),
        new WheelNumber(31, WheelNumberColour.Black),
        new WheelNumber(9, WheelNumberColour.Red),
        new WheelNumber(22, WheelNumberColour.Black),
        new WheelNumber(18, WheelNumberColour.Red),
        new WheelNumber(29, WheelNumberColour.Black),
        new WheelNumber(7, WheelNumberColour.Red),
        new WheelNumber(28, WheelNumberColour.Black),
        new WheelNumber(12, WheelNumberColour.Red),
        new WheelNumber(35, WheelNumberColour.Black),
        new WheelNumber(3, WheelNumberColour.Red),
        new WheelNumber(26, WheelNumberColour.Black)
    };

        public event Func<Task> OnStartAsync;

        public event Func<Task> OnFinishAsync;

        public event Func<Task> OnNumberChangedAsync;

        public async Task RollTheBallAsync()
        {
            WinningNumber = null;
            Running = true;

            if (OnStartAsync != null)
            {
                await OnStartAsync.Invoke();
            }

            var running = true;
            var random = new Random();
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var lengthOfSpin = new TimeSpan(0, 0, random.Next(5, 15));

            random = new Random();
            var speed = new TimeSpan(random.Next(30000, 40000));

            while (running)
            {
                CurrentNumberIndex += 1;

                if (CurrentNumberIndex > WheelNumbers.GetUpperBound(0))
                {
                    CurrentNumberIndex = 0;
                }
                if (OnNumberChangedAsync != null)
                {
                    await OnNumberChangedAsync.Invoke();
                }

                await Task.Delay(speed);

                if (stopwatch.Elapsed.TotalSeconds > lengthOfSpin.TotalSeconds - 5)
                {
                    random = new Random();
                    speed = new TimeSpan(random.Next(100000, 200000));
                }
                if (stopwatch.Elapsed.TotalSeconds > lengthOfSpin.TotalSeconds - 2)
                {
                    random = new Random();
                    speed = new TimeSpan(random.Next(500000, 700000));
                }
                if (stopwatch.Elapsed.TotalSeconds > lengthOfSpin.TotalSeconds)
                {
                    running = false;
                }
            }

            WinningNumber = WheelNumbers[CurrentNumberIndex];

            Running = false;

            if (OnFinishAsync != null)
            {
                await OnFinishAsync.Invoke();
            }
        }
    }
}
