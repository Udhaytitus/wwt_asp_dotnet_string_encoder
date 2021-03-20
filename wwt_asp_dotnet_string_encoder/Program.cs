using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace wwt_asp_dotnet_string_encoder
{
    public class Program
    {
        public static void Main(string[] args)
        {
           
            Console.WriteLine("String encoder test...");

            Console.WriteLine("Input : Hello World! 1234");
            Console.WriteLine("Expected Output: g2kk4yv4qkc!y4321" + ". Actual Output: " +string_encoder("Hello World! 1234"));
            Console.ReadLine();

            Console.WriteLine("Input : 123B456");
            Console.WriteLine("Expected Output: 321a654" + ". Actual Output: " + string_encoder("123B456"));
            Console.ReadLine();

            Console.WriteLine("Input : Have you tried turning it off and on again?");
            Console.WriteLine("Expected Output: g1u2y 45ysq32cys5qm3mfy3sy4eey1mcy4my1f13m?" + ". Actual Output: " + string_encoder("Have you tried turning it off and on again?"));
            Console.ReadLine();

            Console.WriteLine("Input : The quick brown fox jumps over the lazy dog");
            Console.WriteLine("Expected Output: sg2yp53bjyaq4vmye4wyi5lory4u2qysg2yk1y yc4f" + ". Actual Output: " + string_encoder("The quick brown fox jumps over the lazy dog"));
            Console.ReadLine();

            Console.WriteLine("Input :"+ @"Why haven\‘t you finished the exercise yet?” said Nate.");
            Console.WriteLine("Expected Output: "+@"vg yg1u2m\‘sy 45ye3m3rg2cysg2y2w2qb3r2y 2s ?”yr13cym1s2.""" + ". Actual Output: " + string_encoder(@"Why haven\‘t you finished the exercise yet?” said Nate."));
            Console.ReadLine();

            Console.WriteLine("Input :" + @"You\’ve never heard of the Millennium Falcon? It\‘s the ship that made the Kessel Run in less than 12 parsecs.");
            Console.WriteLine("Expected Output: " + @" 45\’u2ym2u2qyg21qcy4eysg2yl3kk2mm35lye1kb4m?y3s\‘rysg2yrg3oysg1syl1c2ysg2yj2rr2kyq5my3myk2rrysg1my21yo1qr2br.""" + ". Actual Output: " + string_encoder(@"You\’ve never heard of the Millennium Falcon? It\‘s the ship that made the Kessel Run in less than 12 parsecs."));
            Console.ReadLine();

            Console.WriteLine("Input :" + @"The one from the village, FN2187");
            Console.WriteLine("Expected Output: " + @"sg2y4m2yeq4lysg2yu3kk1f2,yem7812""" + ". Actual Output: " + string_encoder(@"The one from the village, FN2187"));
            Console.ReadLine();


        }

        public static string string_encoder(string str_encode_value)
        {
            string ret_val = "";
            if (str_encode_value == "Hello World")
            {
                ret_val = str_encode_value.ToLower();
            }
            else
            {
                var replacedString = Regex.Replace(str_encode_value.ToLower(), @"\d+", m => new string(m.Value.Reverse().ToArray()));
                ret_val = replaceValues(replacedString.ToCharArray());
            }
            return ret_val;
        }

        static String replaceValues(char[] s)
        {
            for (int i = 0; i < s.Length; i++)
            {

                if (s[i].ToString() == "a" || s[i].ToString() == "e" || s[i].ToString() == "i" ||
                        s[i].ToString() == "o" || s[i].ToString() == "u")
                {
                    switch (s[i].ToString())
                    {
                        case "a":
                            s[i] = '1';
                            break;
                        case "e":
                            s[i] = '2';
                            break;
                        case "i":
                            s[i] = '3';
                            break;
                        case "o":
                            s[i] = '4';
                            break;
                        case "u":
                            s[i] = '5';
                            break;
                    }
                }
                else
                {
                    if (s[i] == 'b')
                    {
                        s[i] = 'a';
                    }
                    else if (s[i] == ' ')
                    {
                        s[i] = 'y';
                    }
                    else if (s[i] == 'y')
                    {
                        s[i] = ' ';
                    }
                    else
                    {
                        if (!char.IsDigit(s[i])) //check it's contain digits or not
                        {
                            if (Char.IsLetter(s[i]))
                            {
                                s[i] = (char)(s[i] - 1);
                            }
                            else
                            { //remaining punctuation will be same
                                s[i] = s[i];
                            }

                        }
                        else
                        {
                            s[i] = s[i];
                        }

                    }
                }
            }
            return String.Join("", s);
        }
    }
}
