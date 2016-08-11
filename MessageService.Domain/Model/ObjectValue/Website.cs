using System;
using System.Collections.Generic;

namespace MessageService.Domain.Model
{
    [Serializable]
    public class WebSite : ValueObject
    {
        private const int MaxLenght = 50;
        private const string HTTP = "http://";
        private readonly string _value;

        private WebSite(string value)
        {
            AssertionConcern.AssertArgumentNotEmpty(value, nameof(value), string.Empty);
            AssertionConcern.AssertArgumentTrue(IsValid(value), nameof(value), string.Empty);

            this._value = value;
        }

        public static implicit operator string(WebSite website)
        {
            return website._value;
        }

        public static implicit operator WebSite(string website)
        {
            return new WebSite(website);
        }

        public static bool IsValid(string value)
        {
            string prefix = string.Empty;
            if (!value.StartsWith(HTTP) && value.StartsWith("www"))
            {
                prefix = HTTP;
            }

            if (Uri.IsWellFormedUriString(prefix + value, UriKind.Absolute))
            {
                Uri l_strUri = new Uri(prefix + value);
                return (l_strUri.Scheme == Uri.UriSchemeHttp || l_strUri.Scheme == Uri.UriSchemeHttps);
            }
            else
            {
                return false;
            }
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return _value;
        }
    }
}
