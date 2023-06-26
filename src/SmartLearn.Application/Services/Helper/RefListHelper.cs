using SmartLearn.Domain.Enum;
using SmartLearn.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SmartLearn.Services.Helper
{
    public static class RefListHelper
    {
        public static string GetEnumDescription<T>(this T value)
        {
            if (value == null)
                return null;
            FieldInfo fi = value.GetType().GetField(value.ToString());

            if (fi == null) return null;

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return value.ToString();
            }
        }
        public static List<string> GetMultiReferenceListItemValueList<T>(T role) where T : struct, IConvertible
        {
            List<string> result = new List<string>();

            if (role.ToString() == "0")
                return result;

            var flag = Enum.Parse(typeof(T), role.ToString()) as Enum;

            foreach (var r in (long[])Enum.GetValues(typeof(T)))
            {
                if ((Convert.ToInt32(flag) & r) == r)
                {
                    result.Add(Enum.GetName(typeof(T), r));
                }
            }
            return result;
        }

        public static int SetMultiValueReferenceList(List<int> input)
        {
            if (input == null || input.Count == 0) return 0;

            int tt = 0;

            foreach (var item in input)
            {
                tt += item;
            }

            //var tt = temp.Aggregate((i, t) => i | t);
            return (int)tt;
        }

        public static int[] DecomposeIntoBitFlagComponents(int? val)
        {
            if (!val.HasValue || val == 0)
            {
                return new int[] { };
            }
            else
            {
                var resultAr = new List<int>();

                int currentVal = 1;
                while (currentVal <= val)
                {
                    if ((val & currentVal) == currentVal)
                        resultAr.Add(currentVal);
                    currentVal = currentVal * 2;
                }

                return resultAr.ToArray();
            }
        }

        public static RefListSubject[] GetIndividualSubjects(RefListSubject combinedSubjects)
        {

            //Get alll enum values
            RefListSubject[] allSubjects = (RefListSubject[])Enum.GetValues(typeof(RefListSubject));

            var individualSubjects = new List<RefListSubject>();

            foreach (var subject in allSubjects)
            {
                if (combinedSubjects.HasFlag(subject))
                {
                    individualSubjects.Add(subject);
                }
            }
            return individualSubjects.ToArray();
        }
    }
}
