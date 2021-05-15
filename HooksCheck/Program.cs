using System;
using System.ComponentModel;

namespace HooksCheck
{
    internal class Program
    {
        private static String ObjectDumper(object obj)
        {
            string s = string.Empty;
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(obj))
            {
                string name = descriptor.Name;
                object value = descriptor.GetValue(obj);
                s += ("{0}={1}", name, value);
            }
            return s;
        }

        private static int i = 2;
        private static Service1Client sc = new Service1Client();

        private static void Main(string[] args)
        {
            Console.WriteLine("check");
            User current = sc.GetUserByID(i);
            foreach (User u in sc.GetAllFriendshipsByUser(current))
            {
                Console.WriteLine(u.FullName);
                //Console.WriteLine(ObjectDumper(u));
            }
            Console.ReadKey();
        }
    }
}