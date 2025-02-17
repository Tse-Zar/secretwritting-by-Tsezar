//сделано Цезарем
//made by Tsezar

namespace Cryptography
{
    class CesarCrypto(string input, int step = 1)
    {
        private readonly char[] charsRuVariable = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя".ToCharArray();
        private readonly char[] charsEngVariable = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

        private static char[] currentAlphabet = new char[33];
        private int currentCharsValue = currentAlphabet.Length;

        public void CezarCrypt()
        {
            Console.WriteLine(ProcessCezar(input, step));
        }

        public void CezarDecrypt()
        {
            if (step == 0)
            {
                CezarBrutForce();
                return;
            }

            Console.WriteLine(ProcessCezar(input, -step));
        }

        private void CezarBrutForce()
        {
            for (int i = 1; i < currentCharsValue; i++)
            {
                Console.WriteLine(ProcessCezar(input, -i));
            }
        }

        private string ProcessCezar(string input, int step)
        {

            string resultTemp = "";
            foreach (var c in input)
            {
                if (char.IsLetter(c))
                {
                    SetCurrentAlphabet(c);
                    char lowerChar = char.ToLower(c);
                    int index = Array.IndexOf(currentAlphabet, lowerChar);

                    if (index >= 0)
                    {
                        int newIndex = (index - step) % currentCharsValue;

                        if (newIndex < 0)
                        {
                            newIndex += currentCharsValue;
                        }

                        char newChar = currentAlphabet[newIndex];
                        resultTemp += char.IsUpper(c) ? char.ToUpper(newChar) : newChar;
                    }
                }
                else
                    resultTemp += c;
            }


            return resultTemp;
        }

        private bool IsRussian(char c)
        {
            return charsRuVariable.Contains(c);
        }

        private void SetCurrentAlphabet(char c)
        {
            if (IsRussian(c))
            {
                currentAlphabet = charsRuVariable;
                currentCharsValue = currentAlphabet.Length;
            }
            else
            {
                currentAlphabet = charsEngVariable;
                currentCharsValue = currentAlphabet.Length;
            }
        }
    }
}
