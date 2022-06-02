using GodelTourAgensy.BLL.Interfaces;

namespace GodelTourAgensy.BLL.Services
{
    public class StringComparerService : IStringComparerService
    {
        public bool Compare(string obj, string comparing)
        {
            return Set(obj).Contains(Set(comparing));
        }

        private static string Set(string obj)
        {
            return obj.Trim().ToLower();
        }
    }
}
