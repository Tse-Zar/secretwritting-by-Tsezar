namespace Cryptography
{
    class CesarCrypto(string input, int step = 1)
    {
        private readonly static char[] charsVariable = "абвгдеёжзийклмнопрстуфхцчшщъыьэюяabcdefghijklmnopqrstuvwxyz".ToCharArray();
        private readonly int charsValue = charsVariable.Length;
        public void CezarCrypt()
        {
            string resultTemp = "";
            foreach (var c in input)
            {
                if (char.IsLetter(c))
                {
                    char lowerChar = char.ToLower(c);
                    int index = Array.IndexOf(charsVariable, lowerChar);
                    if (step == 0)
                    {
                        for (int i = 0; i < charsValue; i++)
                        {
                            if (index >= 0)
                            {
                                int newIndex = (index + i) % charsValue;

                                if (newIndex < 0)
                                {
                                    newIndex += charsValue;
                                }

                                char newChar = charsVariable[newIndex];
                                resultTemp += char.IsUpper(c) ? char.ToUpper(newChar) : newChar;
                            }
                        }
                    }
                    else
                    {
                        if (index >= 0)
                        {
                            int newIndex = (index + step) % charsValue;

                            if (newIndex < 0)
                            {
                                newIndex += charsValue;
                            }

                            char newChar = charsVariable[newIndex];
                            resultTemp += char.IsUpper(c) ? char.ToUpper(newChar) : newChar;
                        }
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
                    int index = Array.IndexOf(charsVariable, lowerChar);

                    if (index >= 0)
                    {
                        int newIndex = (index - step) % charsValue;

                        if (newIndex < 0)
                        {
                            newIndex += charsValue;
                        }

                        char newChar = charsVariable[newIndex];
                        resultTemp += char.IsUpper(c) ? char.ToUpper(newChar) : newChar;
                    }
                }
                else
                    resultTemp += c;
            }


            Console.WriteLine(resultTemp);

        }
    }
}
