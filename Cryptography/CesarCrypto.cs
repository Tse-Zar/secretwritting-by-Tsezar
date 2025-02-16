namespace Cryptography
{
    class CesarCrypto(string input, int step = 1)
    {
        private readonly static char[] charsRuVariable = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя".ToCharArray();
        private readonly static char[] charsEngVariable = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

        private static char[] currentAlphabet = new char[33];
        private int currentCharsValue = currentAlphabet.Length;

        public void CezarCrypt()
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
                        int newIndex = (index + step) % currentCharsValue;

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

            Console.WriteLine(resultTemp);
        }

        public void CezarEncrypt()
        {
            if (step == 0)
            {
                CezarBrutForce();
                return;
            }

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


            Console.WriteLine(resultTemp);
        }

        private void CezarBrutForce()
        {
            for (int i = 1; i < 33; i++)
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
                            int newIndex = (index - i) % currentCharsValue;

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


                Console.WriteLine(resultTemp);
            }
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
                currentAlphabet = charsRuVariable;
                currentCharsValue = currentAlphabet.Length;
            }
        }
    }
}
