using PathFinder.Interfaces;

namespace PathFinder.Services
{
    public class Validator : IValidator
    {
        public bool Valid(params string[] values)
        {
            foreach (var value in values)
            {
                if (string.IsNullOrEmpty(value))
                    return false;
            }

            return true;
        }
    }
}
