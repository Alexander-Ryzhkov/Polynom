using NUnit.Framework;
using System;
using System.Collections;
using Polynom;

namespace Polynom.Test
{
	[TestFixture]
	public class PolynomTest
	{
		[Test, TestCaseSource (typeof(PolynomTestData), "TestString")]
		public string ToString_Test (double[] c)
		{
			return new Polynom (c).ToString ();
		}


		[Test, TestCaseSource (typeof(PolynomTestData), "TestPlus")]
		public string OperatorPlus_Test (Polynom p1, Polynom p2)
		{
			return (p1 + p2).ToString ();
		}


		[Test, TestCaseSource (typeof(PolynomTestData), "TestMinus")]
		public string OperatorMinus_Test (Polynom p1, Polynom p2)
		{
			return (p1 - p2).ToString ();
		}

		[Test, TestCaseSource (typeof(PolynomTestData), "TestMultiply")]
		public string OperatorMultiply_Test (Polynom p1, Polynom p2)
		{
			return (p1 * p2).ToString ();
		}


	}



	public class PolynomTestData
	{

		public static IEnumerable TestString {
			get {
				yield return new TestCaseData (new double[] { }).Returns ("0")
					.SetName ("ToString_EmptyArray");
				yield return new TestCaseData (new double[] { 1, 2.5 }).Returns ("1+2,5x^1")
					.SetName ("2 positive");
				yield return new TestCaseData (new double[] { -3.33, -870, -0.001 }).Returns ("-3,33-870x^1-0,001x^2")
					.SetName ("3 negative");
				yield return new TestCaseData (new double[] { -3.33, 810, -0.001, 0, 0, 15, 0 }).Returns ("-3,33+810x^1-0,001x^2+15x^5")
					.SetName ("5 degree");
				yield return new TestCaseData (null)
					.Throws (typeof(ArgumentNullException))
					.SetName ("ToString_Null");
			}
		}

		private static Polynom CreatePolynom (params double[] arg)
		{
			return new Polynom (arg);
		}

		public static IEnumerable TestPlus {
			get {
				yield return new TestCaseData (CreatePolynom (), CreatePolynom (0)).Returns ("0");
				yield return new TestCaseData (CreatePolynom (1, 2.5, 0), CreatePolynom (18)).Returns ("19+2,5x^1");
				yield return new TestCaseData (CreatePolynom (-3, -7, 12), CreatePolynom (7, 1, 2)).Returns ("4-6x^1+14x^2");
				yield return new TestCaseData (null, null)
					.Throws (typeof(ArgumentNullException))
					.SetName ("OperatorPlus_Null");
			}
		}

		public static IEnumerable TestMinus {
			get {
				yield return new TestCaseData (CreatePolynom (), CreatePolynom (0)).Returns ("0");
				yield return new TestCaseData (CreatePolynom (1, 2.5, 0), CreatePolynom (18)).Returns ("-17+2,5x^1");
				yield return new TestCaseData (CreatePolynom (-3, -7, 12), CreatePolynom (7, 1, 2)).Returns ("-10-8x^1+10x^2");
				yield return new TestCaseData (null, null)
					.Throws (typeof(ArgumentNullException))
					.SetName ("OperatorMinus_Null");
			}
		}

		public static IEnumerable TestMultiply {
			get {
				yield return new TestCaseData (CreatePolynom (), CreatePolynom (0)).Returns ("0");
				yield return new TestCaseData (CreatePolynom (1, 2.5, 0), CreatePolynom (18)).Returns ("18+45x^1");
				yield return new TestCaseData (CreatePolynom (-3, -7), CreatePolynom (7, 1)).Returns ("-21-52x^1-7x^2");
				yield return new TestCaseData (null, null)
					.Throws (typeof(ArgumentNullException))
					.SetName ("OperatorMultiply_Null");
			}
		}


	}

}

