using BreakFastTasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoreCollectionsAsync
{

    class SimpleBreakfast
    {
        public static DateTime startTime;

        public static async Task MakeBreakFastDemo2()
        {
			DateTime start = DateTime.Now;
			//Prepare Salad
			startTime = DateTime.Now;
			Task task = MakeOmletteAsync();
            Task task1 = MakeToastAsync();
            MakeSalad();
          await Task.WhenAll(task1,task);
			DateTime end = DateTime.Now;
			TimeSpan length = end - start;
			Console.WriteLine($"Breakfast is ready at {end.ToString()}");
			Console.WriteLine($"Total time in seconds: {length.TotalSeconds}");


		}
        public static async Task MakeBreakFastDemo3()
        {
            List<Task> tasks = new List<Task>();
            startTime = DateTime.Now;
            Task<Omlette> o = MakeOmletteAsync();
            Task<Toast> t = MakeToastAsync();
            Task s = Task.Run(() => MakeSalad());
            tasks.Add(s);
            tasks.Add(t);
            tasks.Add(o);

            while (tasks.Count > 0)
            {
                Task finished = await Task.WhenAny(tasks);
                if (finished == o)
                {
                   Omlette omlette = await o;
					Console.WriteLine("Omlette is ready to serve!");
                }
                else if (finished == t)
                {
                    Toast toast = await t;
					Console.WriteLine("Toast is ready to serve!");
                }
                else if (finished == s)
                {
                    Console.WriteLine("Salad is ready to serve!");
                }
                tasks.Remove(finished);





			}
        }




		public static void MakeSalad()
        {
			DateTime start = DateTime.Now;
			//Prepare Salad
			startTime = DateTime.Now;
			Console.WriteLine($"Start preparing the Salad at {startTime.ToString()}");
            Console.WriteLine("Start cutting Tomato");
			Tomato tomato = new Tomato("myTomato");
			tomato.OnProgress += Progress;
            tomato.Start();
			Console.WriteLine($"Start preparing the Cucumber at {startTime.ToString()}");
			Cucumber cucumber = new Cucumber("myCucumber");
			cucumber.OnProgress += Progress;
			cucumber.Start();

			Console.WriteLine("Finish Salad");
			DateTime end = DateTime.Now;
			TimeSpan length = end - start;
			Console.WriteLine($"Salad is ready at {end.ToString()}");
			Console.WriteLine($"Total time in seconds: {length.TotalSeconds}");
		}

        public static async Task<Toast> MakeToastAsync()
        {
			DateTime start = DateTime.Now;
			//Prepare Toast
			startTime = DateTime.Now;
			Console.WriteLine($"Start preparing the Toast at {startTime.ToString()}");
			Toast myToast = new Toast("myToast");
			myToast.OnProgress += Progress;
			await myToast.StartAsync();
			Console.WriteLine("Finish Toast");
			DateTime end = DateTime.Now;
			TimeSpan length = end - start;
			Console.WriteLine($"Toast is ready at {end.ToString()}");
			Console.WriteLine($"Total time in seconds: {length.TotalSeconds}");
            return myToast;
		}


		public static async Task<Omlette> MakeOmletteAsync()
        {
			
			DateTime start = DateTime.Now;
			//Prepare Omlette
			startTime = DateTime.Now;
			Console.WriteLine($"Start preparing the Omlette at {startTime.ToString()}");
			Omlette myOmlette = new Omlette("myOmlette");
			myOmlette.OnProgress += Progress;
            await myOmlette.StartAsync();
			Console.WriteLine("Finish Omlette");
			DateTime end = DateTime.Now;
			TimeSpan length = end - start;
			Console.WriteLine($"Omlette is ready at {end.ToString()}");
			Console.WriteLine($"Total time in seconds: {length.TotalSeconds}");
            return myOmlette;

		}


		public static void MakeBreakfastDemo_1()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            DateTime start = DateTime.Now;
            //Prepare Omlette
            startTime = DateTime.Now;
            Console.WriteLine($"Start preparing the Omlette at {startTime.ToString()}");
            Omlette myOmlette = new Omlette("myOmlette");
            myOmlette.OnProgress += Progress;
            
            myOmlette.Start();

            //Prepare toast
            startTime = DateTime.Now;
            Console.WriteLine($"Start preparing the toast at {startTime.ToString()}");

            Toast toast = new Toast("toast");
            
            toast.Start();

            //Prepare first cucumbers
            startTime = DateTime.Now;
            Console.WriteLine($"Start preparing the first cucumber at {startTime.ToString()}");

            Cucumber cucumber1 = new Cucumber("first cucumber");
            
            cucumber1.Start();

            //Prepare second cucumbers
            startTime = DateTime.Now;
            Console.WriteLine($"Start preparing the second cucumber at {startTime.ToString()}");

            Cucumber cucumber2 = new Cucumber("second cucumber");
            
            cucumber2.Start();

            //Prepare tomato
            startTime = DateTime.Now;
            Console.WriteLine($"Start preparing the tomato at {startTime.ToString()}");
            Tomato tomato = new Tomato("tomato");
            
            Console.WriteLine();
            
            tomato.Start();

            stopWatch.Stop();
            Console.WriteLine($"Breakfast is ready after {stopWatch.Elapsed.TotalSeconds} seconds");
            DateTime end = DateTime.Now;
            TimeSpan length = end - start;
            Console.WriteLine($"Breakfast is ready at {end.ToString()}");
            Console.WriteLine($"Total time in seconds: {length.TotalSeconds}");

        }

        //The event OnProgressUpdate will fire this function! 
        static void Progress(object? sender, int percent)
        {
            if (sender is TaskExecutor)
            {

                TaskExecutor obj = (TaskExecutor)sender;
                Console.WriteLine($"Progress for {obj.Name}: {percent}%");
               // Console.SetCursorPosition((Console.CursorLeft -(obj.Name.Length+percent.ToString().Length+16)), Console.CursorTop);
            }
        }

        //The event OnFinish will fire this function! 
        static void Finish(Object? sender, EventArgs e)
        {
            if (sender is TaskExecutor)
            {
                TaskExecutor obj = (TaskExecutor)sender;
                Console.WriteLine($"\n{obj.Name} is ready!");
            }
        }









    }
}
