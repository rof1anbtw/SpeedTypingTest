using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SpeedTypingTest
{
    internal class LeaderBoard
    {
        static public int mistake;
        static public double time;
        static public string name;
        public void JsonSave(int Mistakes,double Time,string Name)
        {
            mistake= Mistakes;
            time= Time; 
            name= Name;
            LeaderBoard newName= new LeaderBoard();
            newName.JsonSave(Mistakes,Time,Name);
            string text = JsonConvert.SerializeObject(newName);
            if (File.Exists("C: \\Users\\pshum\\OneDrive\\Рабочий стол\\JsonFile.json"))
                {
                File.WriteAllText("C: \\Users\\pshum\\OneDrive\\Рабочий стол\\JsonFile.json", text); }
            else
            {
                File.Create("C: \\Users\\pshum\\OneDrive\\Рабочий стол\\JsonFile.json");
            }
        }
    }
}
