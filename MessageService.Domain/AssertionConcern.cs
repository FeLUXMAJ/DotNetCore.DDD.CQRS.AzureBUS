using System;
using System.Text.RegularExpressions;

namespace MessageService.Domain.Model
{
    public class AssertionConcern
    {
        protected AssertionConcern() { }

        public static void AssertArgumentEquals(object object1, object object2, string code, string message)
        {
            if (!object1.Equals(object2))
            {
                throw new ArgumentException(code, message);
            }
        }

        public static void AssertArgumentFalse(bool boolValue, string code, string message)
        {
            if (boolValue)
                throw new ArgumentException(code, message);
        }

        public static void AssertArgumentLength(string stringValue, int maximum, string code, string message)
        {
            int length = stringValue.Trim().Length;
            if (length > maximum)
                throw new ArgumentException(code, message);
        }

        public static void AssertArgumentLength(string stringValue, int minimum, int maximum, string code, string message)
        {
            int length = stringValue.Trim().Length;
            if (length < minimum || length > maximum)
                throw new ArgumentException(code, message);
        }

        public static void AssertArgumentMatches(string pattern, string stringValue, string code, string message)
        {
            Regex regex = new Regex(pattern);

            if (!regex.IsMatch(stringValue))
                throw new ArgumentException(code, message);
        }

        public static void AssertArgumentNotMatches(string pattern, string stringValue, string code, string message)
        {
            Regex regex = new Regex(pattern);

            if (regex.IsMatch(stringValue))
                throw new ArgumentException(code, message);
        }

        public static void AssertArgumentNotEmpty(string stringValue, string code, string message)
        {
            if(string.IsNullOrWhiteSpace(stringValue))
                throw new ArgumentException(code, message);
        }

        public static void AssertArgumentNotGuid(string stringValue, string code, string message)
        {
            Guid guid;
            if (!Guid.TryParse(stringValue, out guid) || guid.Equals(Guid.Empty))
                throw new ArgumentException(code, message);
        }

        public static void AssertArgumentNotEmpty(Guid guidValue, string code, string message)
        {
            if (guidValue == Guid.Empty)
                throw new ArgumentException(code, message);
        }

        public static void AssertArgumentNotEquals(object object1, object object2, string code, string message)
        {
            if (object1.Equals(object2))
                throw new ArgumentException(code, message);
        }

        public static void AssertArgumentNotNull(object object1, string code, string message)
        {
            if (object1 == null)
                throw new ArgumentException(code, message);
        }

        public static void AssertArgumentNull(object object1, string code, string message)
        {
            if (object1 != null)
                throw new ArgumentException(code, message);
        }

        public static void AssertArgumentRange(double value, double minimum, double maximum, string code, string message)
        {
            if (value < minimum || value > maximum)
                throw new ArgumentException(code, message);
        }

        public static void AssertArgumentRange(float value, float minimum, float maximum, string code, string message)
        {
            if (value < minimum || value > maximum)
                throw new ArgumentException(code, message);
        }

        public static void AssertArgumentRange(int value, int minimum, int maximum, string code, string message)
        {
            if (value < minimum || value > maximum)
                throw new ArgumentException(code, message);
        }

        public static void AssertArgumentRange(decimal value, decimal minimum, decimal maximum, string code, string message)
        {
            if (value < minimum || value > maximum)
                throw new ArgumentException(code, message);
        }

        public static void AssertArgumentRange(long value, long minimum, long maximum, string code, string message)
        {
            if (value < minimum || value > maximum)
                throw new ArgumentException(code, message);
        }

        public static void AssertArgumentRange(byte value, byte minimum, byte maximum, string code, string message)
        {
            if (value < minimum || value > maximum)
                throw new ArgumentException(code, message);
        }

        public static void AssertArgumentRange(short value, short minimum, short maximum, string code, string message)
        {
            if (value < minimum || value > maximum)
                throw new ArgumentException(code, message);
        }

        public static void AssertArgumentTrue(bool boolValue, string code, string message)
        {
            if (!boolValue)
                throw new ArgumentException(code, message);
        }

        public static void AssertStateFalse(bool boolValue, string code, string message)
        {
            if (boolValue)
                throw new ArgumentException(code, message);
        }

        public static void AssertStateTrue(bool boolValue, string code, string message)
        {
            if (!boolValue)
                throw new ArgumentException(code, message);
        }

        protected void SelfAssertArgumentEquals(object object1, object object2, string code, string message)
        {
            AssertionConcern.AssertArgumentEquals(object1, object2, code, message);
        }

        protected void SelfAssertArgumentFalse(bool boolValue, string code, string message)
        {
            AssertionConcern.AssertArgumentFalse(boolValue, code, message);
        }

        protected void SelfAssertArgumentLength(string stringValue, int maximum, string code, string message)
        {
            AssertionConcern.AssertArgumentLength(stringValue, maximum, code, message);
        }

        protected void SelfAssertArgumentLength(string stringValue, int minimum, int maximum, string code, string message)
        {
            AssertionConcern.AssertArgumentLength(stringValue, minimum, maximum, code, message);
        }

        protected void SelfAssertArgumentMatches(string pattern, string stringValue, string code, string message)
        {
            AssertionConcern.AssertArgumentMatches(pattern, stringValue, code, message);
        }

        protected void SelfAssertArgumentNotMatches(string pattern, string stringValue, string code, string message)
        {
            AssertionConcern.AssertArgumentNotMatches(pattern, stringValue, code, message);
        }

        protected void SelfAssertArgumentNotEmpty(string stringValue, string code, string message)
        {
            AssertionConcern.AssertArgumentNotEmpty(stringValue, code, message);
        }

        protected void SelfAssertArgumentNotEquals(object object1, object object2, string code, string message)
        {
            AssertionConcern.AssertArgumentNotEquals(object1, object2, code, message);
        }

        protected void SelfAssertArgumentNotNull(object object1, string code, string message)
        {
            AssertionConcern.AssertArgumentNotNull(object1, code, message);
        }

        protected void SelfAssertArgumentRange(double value, double minimum, double maximum, string code, string message)
        {
            AssertionConcern.AssertArgumentRange(value, minimum, maximum, code, message);
        }

        protected void SelfAssertArgumentRange(float value, float minimum, float maximum, string code, string message)
        {
            AssertionConcern.AssertArgumentRange(value, minimum, maximum, code, message);
        }

        protected void SelfAssertArgumentRange(int value, int minimum, int maximum, string code, string message)
        {
            AssertionConcern.AssertArgumentRange(value, minimum, maximum, code, message);
        }

        protected void SelfAssertArgumentRange(long value, long minimum, long maximum, string code, string message)
        {
            AssertionConcern.AssertArgumentRange(value, minimum, maximum, code, message);
        }

        protected void SelfAssertArgumentTrue(bool boolValue, string code, string message)
        {
            AssertionConcern.AssertArgumentTrue(boolValue, code, message);
        }

        protected void SelfAssertStateFalse(bool boolValue, string code, string message)
        {
            AssertionConcern.AssertStateFalse(boolValue, code, message);
        }

        protected void SelfAssertStateTrue(bool boolValue, string code, string message)
        {
            AssertionConcern.AssertStateTrue(boolValue, code, message);
        }
    }
}
