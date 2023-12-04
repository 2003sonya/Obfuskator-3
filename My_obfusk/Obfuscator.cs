using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace My_obfusk
{
    public class Obfuscator
    {
        public Obfuscator() { } /*конструктор*/

        public string path = "text_for_obf.txt";
        public string t ="";
        //public string str = "";
        // асинхронное чтение
        public string read()  /*самый первый метод считывания кода из файла, путь которого указан в переменной path*/
        {
            StreamReader reader = new StreamReader(path);
            
            while (!reader.EndOfStream)
            {
                t = t+ reader.ReadLine(); /*считывание всех строк кода из файла*/
            }

            t = Regex.Replace(t, @"(?s)\s*\/\/.+?\n|\/\*.*?\*\/\s*", String.Empty); /* удаление комментариев*/
            t = Regex.Replace(t, "\t", String.Empty); /* удаление табуляции*/

            /*замена имени класса везде*/
            int c1 = t.IndexOf("class", 0);
            int c2 = t.IndexOf("{", 0);
            
            string snew = t.Substring(c1 + 6, c2 - c1 - 6);
            t = Regex.Replace(t, snew, "acfebfrbdfgt_ruf85cede99 "); /* замена имени класса на короткое имя*/

            return t;
        }

        public string deadCode(string readStr) /*добавление мертвого кода (метода)*/
        {
            string garbage = " public int asddfsa=-10000000; private bool bolololol=true; private long sksksks(){return 18255252525;} public void goTo(int z){ while (z>=100000){asddfsa=-7897410;}}";
            int len = readStr.Length - 1;
            string newStr = readStr.Insert(len, garbage);
            return newStr;
        }

        public string deadPole(string readStr) /*добавление мертвого кода (метода)*/
        {
            string garbage = " public long ogkog=18;/* " +
                "поле,которое обозначает сколько всего лет должен прожить данный экземпляр, чтобы пройти все уровни*/" +
                " private int oganta=984; /*код, который навсегда изименился edhns лв ff*/ protected long sds; ";
            int vxod = readStr.IndexOf("{", 0);
            string strAll = readStr.Insert(vxod + 1, garbage);
            return strAll;
        }

        public void write(string str) /*запись текста в файл*/
        {
	/*обработка ошибок*/
	/*если всё ок, то:*/
            try
            {
                StreamWriter sw = new StreamWriter("TextObf.txt");
                sw.WriteLine(str);
                sw.Close();
            }
	/* в случае ошибки:*/
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

	public float test(float count)
	{
		if (count>=10) return count;
		return 10;
	}

    }
}
