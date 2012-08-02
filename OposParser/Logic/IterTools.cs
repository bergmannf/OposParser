using System;
using System.Collections.Generic;

namespace OposParser.Logic
{
	public static class IterTools
	{
		/// <summary>
		/// Applies the function action on two elements of the enumeration.
		/// The function stops as soon as the result of the application fulfills
		/// the comparison function.
		/// </summary>
		/// <example>
		/// int[] arr = new int[]{1, 2, 3, 4};
		/// => a = action(1, 2);
		/// => if (comparison(a)) => break;
		/// => a = action(a, 3);
		/// => if (comparison(a)) => break;
		/// => a = action(a, 4);
		/// => if (comparison(a)) => break;
		/// </example>
		/// <returns>The element of the enumeration the fulfilled the comparison,
		/// and the element of the application of the function.</returns>
		/// <param name="source">The enumeration the function should
		/// be applied to.</param>
		/// <param name="action">The action that should be applied to the
		/// elements.</param>
		/// <param name="comparison">The comparison to be performed.</param>
		public static Tuple<T, T> ApplyUntil<T>(this IEnumerable<T> source,
		                                        Func<T, T, T> action,
		                                        Func<T, bool> comparison)
		{
			T operand = default(T);
			foreach (T element in source) {
				if (operand == null) {
					operand = element;
				} else {
					operand = action(operand, element);
				}
				if (comparison(operand)) {
					return Tuple.Create(element, operand);
				}
			}
			return Tuple.Create(operand, operand);
		}

		/// <summary>
		/// Partial application of the GreaterEqual function.
		/// </summary>
		/// <param name="f">The function to be partially applied</param>
		/// <param name="argument">The parameter to be used.</param>
		/// <returns>The function with the argument passed to it.
		/// </returns>
		public static Func<T, TResult> PartiallyApply<T, TResult>(Func<T, T, TResult> f,
		                                                          T argument) {
			return (argument2) => f(argument2, argument);
		}

	}
}
