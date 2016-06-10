using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TomsGraphicsProgram
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*
            int number = 0;
            AddNumber(number);
            MessageBox.Show(number.ToString());


            List<string> names = new List<string>();
            SomeMethod(names);
            MessageBox.Show(names[0]);


            */
            string something = "some text";
            Dictionary<string, string> myDict = new Dictionary<string, string>();

            myDict["my key"] = "my value";

            MessageBox.Show(myDict["my key"]);


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }


        public static int AddNumber(int number)
        {
            number = number + 1;
            MessageBox.Show(number.ToString());

            return number;
        }

        public static void SomeMethod(List<string> names)
        {
            names.Add("Tom");
        }
    }
}
