using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MADS_GUI
{
    class ScriptRW
    {
        public ScriptRW()
        {

        }
        public static List<string> readfile(string file)
        {
            try
            {
                return File.ReadAllLines(file).ToList<string>();
            }
            catch
            {
                return new List<string>();
            }
        }
        public static void writefile(string file, string[] args)
        {
            //BinaryWriter output = new BinaryWriter(File.Open("g.out", FileMode.Create));
            //File.OpenWrite(file)
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(file))
            {
                //output.WriteLine("@echo off");
                //output.WriteLine("title updater_room");
                //output.WriteLine("echo Starting Script");
                //output.Write("start /wait updater_core.bat");
                foreach (string arg in args)
                {
                    output.Write(" " + arg);
                }
                //output.WriteLine("");
                //output.WriteLine("echo Done");
                //output.WriteLine("exit");
            }
        }

    }
}
