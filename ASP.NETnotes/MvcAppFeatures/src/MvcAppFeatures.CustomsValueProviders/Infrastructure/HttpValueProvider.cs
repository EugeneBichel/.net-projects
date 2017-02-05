using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Linq;
using System.Collections.Specialized;
using System.Globalization;
using System.Threading.Tasks;

namespace MvcAppFeatures.CustomsValueProviders.Infrastructure
{
	public class HttpValueProvider : IValueProvider
	{
		private readonly NameValueCollection _headers;
		private readonly string[] _headerKeys;

		public HttpValueProvider(NameValueCollection httpHeaders)
		{
			_headers = httpHeaders;
			_headerKeys = _headers.AllKeys;
		}

		public bool ContainsPrefix(string prefix)
		{
			return _headerKeys.Any(h => h.Replace("-", "").Equals(prefix, StringComparison.OrdinalIgnoreCase));
		}

		public ValueProviderResult GetValue(string key)
		{
			var header = _headerKeys.FirstOrDefault(h => h.Replace("-", "").Equals(key, StringComparison.OrdinalIgnoreCase));

			var value = _headers[header];

			if(!string.IsNullOrWhiteSpace(value))
			{
				return new ValueProviderResult(value, CultureInfo.CurrentCulture);
			}

			return ValueProviderResult.None;
		}
	}
	
}
