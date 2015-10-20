using System;
using System.Linq;
using System.Collections;
using System.Text;


/*
 *Задание 1.

1 Разработать класс «многочлен» для работы с многочленами от одной переменной вещественного типа (в 

качестве внутренней стркутуры для хранения коэффициетов использовать sz-массив). 

2 Переопределить в классе необходимые виртуальные методы.

3 Перегрузить для класса операции, допустимые для работы с многочленами (исключая деление многочлена на 

многочлен).

4 Разработать unit-тесты для тестирования разработанных методов. 
 * 
 * 
*/



namespace Polynom
{
	public class Polynom
	{
		

		private double[] coefficient;

		public int Length {
			get { return coefficient.Length; }
		}


		public Polynom ()
		{
			coefficient = new double[] { };
		}

		public Polynom (params double[] arr)
		{
			if (arr == null)
				throw new ArgumentNullException ();
			coefficient = new double[arr.Length];
			arr.CopyTo (coefficient, 0);
		}

		public double Get (int i)
		{
			return coefficient [i];
		}



		public static Polynom operator + (Polynom p1, Polynom p2)
		{
			if (p1 == null || p2 == null)
				throw new ArgumentNullException ();

			int n = Math.Max (p1.Length, p2.Length);

			double[] r = new double[n];

			for (int i = 0; i < p1.Length; i++) {
				r [i] = p1.Get (i);
			}
			for (int i = 0; i < p2.Length; i++) {
				r [i] += p2.Get (i);
			}


			return new Polynom (r);
		}

		public static Polynom operator - (Polynom p1, Polynom p2)
		{
			if (p1 == null || p2 == null)
				throw new ArgumentNullException ();

			int n = Math.Max (p1.Length, p2.Length);

			double[] r = new double[n];

			for (int i = 0; i < p1.Length; i++) {
				r [i] = p1.Get (i);
			}
			for (int i = 0; i < p2.Length; i++) {
				r [i] -= p2.Get (i);
			}

			return new Polynom (r);
		}

		public static Polynom operator * (Polynom p1, Polynom p2)
		{
			if (p1 == null || p2 == null)
				throw new ArgumentNullException ();

			int n = p1.Length + p2.Length - 1;

			double[] r = new double[n];

			for (int i = 0; i < p1.Length; i++) {
				for (int j = 0; j < p2.Length; j++) {
					r [i + j] += p1.Get (i) * p2.Get (j);
				}
			}

			return new Polynom (r);
		}



		public override string ToString ()
		{
			StringBuilder result = new StringBuilder ();
			if (coefficient.Length == 0)
				result.Append (0);
			else
				result.Append (coefficient [0]);
			for (int i = 1; i < coefficient.Length; i++) {
				if (coefficient [i] > 0)
					result.AppendFormat ("+{0}x^{1}", coefficient [i], i);
				else if (coefficient [i] < 0)
					result.AppendFormat ("-{0}x^{1}", -coefficient [i], i);
				else
					continue;
			}
			return string.Format ("{0}", result);
		}
	}
		
}

