using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MessageService.Domain.Model
{
    [Serializable]
    public class Email : ValueObject
    {
        private static string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
        private byte EmailMaxLength = 254;
        private readonly string _value;

        private Email(string email)
        {
            AssertionConcern.AssertArgumentNotEmpty(email, nameof(email), string.Empty);
            AssertionConcern.AssertArgumentLength(email, EmailMaxLength, nameof(email), string.Empty);
            AssertionConcern.AssertArgumentMatches(validEmailPattern, email, nameof(email), string.Empty);

            this._value = email;
        }

        public static implicit operator string(Email email)
        {
            return email._value;
        }

        public static implicit operator Email(string email)
        {
            return new Email(email);
        }

        public static bool IsValid(string email)
        {
            return Regex.IsMatch(email, validEmailPattern);
        }

        public override string ToString()
        {
            return _value;
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return _value;
        }
    }
}
