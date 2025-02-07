using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography
{
    class CesarCrypto(string input, int step = 1)
    {
        private readonly static char[] charsRuVariable = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя".ToCharArray();
        private readonly int charsRuValue = charsRuVariable.Length;

        private readonly static char[] charsEngVariable = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        private readonly int charsEngValue = charsEngVariable.Length;
        public void CezarCrypt()
        {
            string resultTemp = "";
            foreach (var c in input)
            {
                if (char.IsLetter(c))
                {
                    char lowerChar = char.ToLower(c);
                    int index = Array.IndexOf(charsRuVariable, lowerChar);

                    if (index >= 0)
                    {
                        int newIndex = (index + step) % charsRuValue;

                        if (newIndex < 0)
                        {
                            newIndex += charsRuValue;
                        }
                   
                        char newChar = charsRuVariable[newIndex];
                        resultTemp += char.IsUpper(c) ? char.ToUpper(newChar) : newChar;
                    }
                }
                else
                    resultTemp += c;
            }


            Console.WriteLine(resultTemp);

        }

        public void CezarEncrypt()
        {
            string resultTemp = "";
            foreach (var c in input)
            {
                if (char.IsLetter(c))
                {
                    char lowerChar = char.ToLower(c);
                    int index = Array.IndexOf(charsRuVariable, lowerChar);

                    if (index >= 0)
                    {
                        int newIndex = (index - step) % charsRuValue;

                        if (newIndex < 0)
                        {
                            newIndex += charsRuValue;
                        }

                        char newChar = charsRuVariable[newIndex];
                        resultTemp += char.IsUpper(c) ? char.ToUpper(newChar) : newChar;
                    }
                }
                else
                    resultTemp += c;
            }


            Console.Write(resultTemp);

        }
    }
}
