using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Numerics;

namespace JamHelpers
{
	public static class ConversionExtensions
	{
		public static string[] Split(this string s)
		{
			return s.Split(' ');
		}

		public static string Join<T>(this IEnumerable<T> parts)
		{
			return string.Join(" ", parts.Select(o => o.ToStringInv()));
		}

		//Scalar

		public static int ToInt(this string s)
		{
			return int.Parse(s, CultureInfo.InvariantCulture);
		}

		public static BigInteger ToBigInt(this string s)
		{
			return BigInteger.Parse(s, CultureInfo.InvariantCulture);
		}

		public static Int64 ToInt64(this string s)
		{
			return Int64.Parse(s, CultureInfo.InvariantCulture);
		}

		public static double ToDouble(this string s)
		{
			return double.Parse(s, CultureInfo.InvariantCulture);
		}

		public static string ToStringInv(this object o)
		{
			var formattable = o as IFormattable;
			if (formattable != null)
				return formattable.ToString(null, CultureInfo.InvariantCulture);
			else
				return o.ToString();
		}

		//array
		public static int[] ToInt(this string[] s)
		{
			return s.Select(ToInt).ToArray();
		}

		public static BigInteger[] ToBigInt(this string[] s)
		{
			return s.Select(ToBigInt).ToArray();
		}

		public static Int64[] ToInt64(this string[] s)
		{
			return s.Select(ToInt64).ToArray();
		}

		public static double[] ToDouble(this string[] s)
		{
			return s.Select(ToDouble).ToArray();
		}

		public static string[] ToStringInv<T>(this T[] arr)
		{
			return arr.Select(o => o.ToStringInv()).ToArray();
		}
	}
}
