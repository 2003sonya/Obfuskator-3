// See https://aka.ms/new-console-template for more information
using My_obfusk;




Obfuscator o1 = new Obfuscator();
string s = o1.read();/* считываем*/
s = o1.deadCode(s); /*добавляем мертвый код*/
s = o1.deadPole(s); /*добавляем мертвый код*/
o1.write(s);
Console.WriteLine(s);



