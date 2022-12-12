using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace chechen_latyn_cyrillic_convertor
{
    internal class Convertor
    {
        private Dictionary<string, string> letterDictionary = new Dictionary<string, string>(){
        {"аь", "ä"},
        {"гӏ", "ġ"},
        {"кх", "q"},
        {"къ", "q̇"},
        {"кӏ", "kh"},
        {"оь", "ö"},
        {"пӏ", "ph"},
        {"тӏ", "th"},
        {"уь", "ü"},
        {"хь", "ẋ"},
        {"хӏ", "h"},
        {"цӏ", "ċ"},
        {"чӏ", "ҫ̇"},
        {"юь", "yü"},
        {"яь", "yä"},
        {"ӏ", "j"},
        {"а", "a"},
        {"б", "b"},
        {"в", "v"},
        {"г", "g"},
        {"д", "d"},
        {"е", "e"},
        {"ё", "yo"},
        {"ж", "ƶ"},
        {"з", "z"},
        {"и", "i"},
        {"й", "y"},
        {"к", "k"},
        {"л", "l"},
        {"м", "m"},
        {"н", "n"},
        {"о", "o"},
        {"п", "p"},
        {"р", "r"},
        {"с", "s"},
        {"т", "t"},
        {"у", "u"},
        {"ф", "f"},
        {"х", "x"},
        {"ц", "c"},
        {"ч", "ҫ"},
        {"ш", "ş"},
        {"щ", "ş"},
        {"ъ", "ə"},
        {"ы", ""},
        {"ь", ""},
        {"э", "e"},
        {"ю", "yu"},
        {"я", "ya"},
        };

        public Convertor()
        {
            this.letterDictionary = new Dictionary<string, string>();
            foreach (string line in System.IO.File.ReadLines("dictionary.txt", Encoding.UTF8))
            {   
                string cyrillicLetter = line.Trim().Split(' ')[0];
                string latinlLetter = line.Trim().Split(' ')[1];
                if (latinlLetter == "*")
                    latinlLetter = "";
                letterDictionary.Add(cyrillicLetter, latinlLetter);
            }
        }

        public string convert(String input, Boolean to_cyrillic = false)
        {
            if (to_cyrillic)
            {
                foreach (KeyValuePair<String, String> pair in this.letterDictionary)
                {
                    if (pair.Value.Length == 0)
                        continue;
                    input = Regex.Replace(input, pair.Value, pair.Key);
                    input = Regex.Replace(input, FirstCharToUpper(pair.Value), FirstCharToUpper(pair.Key));
                    input = Regex.Replace(input, pair.Value.ToUpper(), FirstCharToUpper(pair.Key));
                }
            } 
            else
            {

                foreach (KeyValuePair<String, String> pair in this.letterDictionary)
                {
                    input = Regex.Replace(input, pair.Key, pair.Value);
                    input = Regex.Replace(input, FirstCharToUpper(pair.Key), FirstCharToUpper(pair.Value));
                    input = Regex.Replace(input, pair.Key.ToUpper(), FirstCharToUpper(pair.Value));
                }
            }
            return input;
        }
        public static string FirstCharToUpper(string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": return "";
                default: return input[0].ToString().ToUpper() + input.Substring(1);
            }
        }
    }
}