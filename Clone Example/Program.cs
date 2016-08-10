using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Clone_Example
{
    class singleton
    {
        static singleton instance;

        public int a;
        static object syncRoot = new object();
        private singleton()
        {
            a = 10;
        }

        public  static singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new singleton();
                    }
                }

                return instance;
            }
        }

        protected new object MemberwiseClone()
        {
            return Instance;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            int a = 90;
            String str = a.ToString();

            Console.WriteLine(str);
            singleton s = singleton.Instance;
            BindingFlags eFlags = BindingFlags.Instance | BindingFlags.NonPublic;
            singleton copy = (singleton) s.GetType().GetMethod("MemberwiseClone", eFlags).Invoke(s,null);
            copy.a = 20;
            System.Console.WriteLine(s.a);
            System.Console.WriteLine(copy.a);
            System.Console.ReadLine();

        }
    }
}
