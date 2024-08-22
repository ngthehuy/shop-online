using System;
using System.Globalization;
using System.Text;

namespace ShopOnline.Helpers
{
    public static class Commons
    {
        public static string RemoveVietnameseAccents(this string input)
        {
            //remove  space to string
            input = input.Replace(" ","-");

            // chuyen ve chuoi thuong
            input = input.ToLower();

            // Normalize the input string to decomposed Unicode (Normalization Form D)
            string normalized = input.Normalize(NormalizationForm.FormD);

            StringBuilder result = new StringBuilder();

            foreach (char c in normalized)
            {
                UnicodeCategory category = CharUnicodeInfo.GetUnicodeCategory(c);
                if (category != UnicodeCategory.NonSpacingMark)
                {
                    result.Append(c);
                }
            }

            // Re-combine the characters into one string
            return result.ToString().Normalize(NormalizationForm.FormC);
        }
        public static string[] GetListImage(this string value)
        {
            string[] result = value.Split('\n');

            return result;
        }
        public static string GetCurrencyFormat(this double? value)
        {
            if(value == null)
            {
                return string.Empty;
            }
            else
            {
              return  value.Value.ToString("0,0đ");
            }
        }
    }
}
