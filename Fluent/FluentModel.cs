using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSharpDesignPatterns.Fluent
{
    public class FluentModel<T> where T : FluentModel<T>
    {
        private string _query = "";

        public T Where(string col, string arg1, string arg2 = null)
        {
            string op = "=";
            string value = "";

            if (!string.IsNullOrWhiteSpace(arg2))
            {
                op = arg1;
                value = arg2;
            }
            else
            {
                // only 2 args is present then use = as default operator
                value = arg1;
            }

            // format properly strings or characters
            value = IsNumber(value) ? value : $"[{value}]";

            if (string.IsNullOrWhiteSpace(_query))
            {
                _query = $"{col}{op}{value}";
            }
            else
            {
                _query += $" and {col}{op}{value}";
            }

            return (T) this;
        }

        public T OrWhere(string col, string arg1, string arg2 = null)
        {
            string op = "=";
            string value = "";

            if (!string.IsNullOrWhiteSpace(arg2))
            {
                op = arg1;
                value = arg2;
            }
            else
            {
                // only 2 args is present then use = as default operator
                value = arg1;
            }

            // format properly strings or characters
            value = IsNumber(value) ? value : $"[{value}]";

            if (string.IsNullOrWhiteSpace(_query))
            {
                _query = $"{col}{op}{value}";
            }
            else
            {
                _query += $" or {col}{op}{value}";
            }

            return (T)this;
        }

        private Boolean IsNumber(string input)
        {
            return Regex.IsMatch(input, @"^\d+$");
        }

        public string ToQuery()
        {
            string _temp = _query;
            _query = "";
            return _temp;
        }
    }
}
