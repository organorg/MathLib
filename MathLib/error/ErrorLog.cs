using System.Collections.Generic;

namespace com.@base.error
{

	public class ErrorLog
	{
		internal static List<Error> last_hundred_errors;


		internal static void NewError(string s)
		{
			last_hundred_errors.Add(new Error(s));
		}

	}

}