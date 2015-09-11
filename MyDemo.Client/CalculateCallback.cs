using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyDemo.Client
{
    public class CalculateCallback : ICallback
    {
        public event EventHandler<DisplayEventArgs> Display;
        public void DisplayResult(double x, double y, double result)
        {
            OnDisplay(x, y, result);
        }
        void OnDisplay(double x, double y, double result)
        {
            if (Display != null)
                Display(this, new DisplayEventArgs(x, y, result));
        }
    }
    public class DisplayEventArgs : EventArgs
    {
        public DisplayEventArgs(double x, double y, double result)
        {
            this.X = x;
            this.Y = y;
            this.Result = result;
        }
        public double X { get; private set; }
        public double Y { get; private set; }
        public double Result { get; private set; }
    }
}
