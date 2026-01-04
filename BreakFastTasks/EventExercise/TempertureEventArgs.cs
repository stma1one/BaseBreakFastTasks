using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakFastTasks.EventExercise
{
	internal class TempertureEventArgs:EventArgs
	{
		public double temperature { get; }
		public  DateTime eventTime
		{
			get;
		}
		public TempertureEventArgs(double temperature)
		{
			this.temperature = temperature;
			this.eventTime = DateTime.Now;
		}
	}
}
