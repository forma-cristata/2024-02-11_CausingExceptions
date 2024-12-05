/*
* Name: Kaci Craycraft
* South Hills Username: kcraycraft45
*/

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace IT100_ExceptionHomework
{
    public class Program
    {
        public const int bigNumber = int.MaxValue;
        public const String filename = "File.txt";
        public static void Main()
        {
            Delegate[] meth = GetInstantiates();
            for (int i = 0; i < meth.Length; i++)
            {
                try
                {
                    meth[i].DynamicInvoke();
                }
                catch (Exception e)
                {
                    if (e.InnerException != null)
                    {
                        Console.Write($"In {meth[i].Method.ToString()![5..]}:{Environment.NewLine}\t");
                        Console.WriteLine(e.InnerException.Message);
                    }
                    Thread.Sleep(1000);
                    Console.Write(Environment.NewLine);
                }
            }
        }
        public static Delegate[] GetInstantiates()
        {
            Delegate[] methods = [new Overflow(CheckedOverflow), new Mem(Memory), new SysIO(SystemIO), new DS(DelegateStupidity), new RI(Arrays)];
            return methods;
        }
        public delegate void Overflow();
        public delegate void Mem();
        public delegate void SysIO();
        public delegate void DS();
        public delegate void RI();
        public static void CheckedOverflow()
        {
            int x = bigNumber;
            while (true)
            {
                x = checked(x*x);
            }
        }
        public static void Memory()
        {
            List<String> infinity = [];
            while (true)
            {
                infinity.Add(new String('x', bigNumber));
            }
        }
        public static void SystemIO()
        {
            File.Create(filename);
            File.Create(filename);
        }
        public static void DelegateStupidity()
        {
            Delegate del = new Overflow(CheckedOverflow);
            del.DynamicInvoke();
        }
        public static void Arrays()
        {
            String[] array = new String[10]; 
             for (int i = 0; i < bigNumber; i++)
            {
                array[i] = "string";
            }
        }

    }
}