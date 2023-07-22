// ***********************************************************************
// Assembly         : DL
// Author           : Administrator
// Created          : 09-13-2013
//
// Last Modified By : Administrator
// Last Modified On : 04-29-2015
// ***********************************************************************
// <copyright file="Guard.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Diagnostics;

/// <summary>
/// The DL namespace.
/// </summary>
namespace DL
{
    /// <summary>
    /// Implements the common guard methods.
    /// </summary>
    [CLSCompliantAttribute(false)]
    [DebuggerNonUserCodeAttribute()]
    [CompilerGeneratedAttribute()]
    public static class Guard
    {
        /// <summary>
        /// Checks a string argument to ensure it isn't null or empty.
        /// </summary>
        /// <param name="argumentValue">The argument value to check.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <exception cref="System.ArgumentException"></exception>
        public static void ArgumentNotNullOrEmptyString(string argumentValue, string argumentName)
        {
            if (String.IsNullOrEmpty(argumentValue))
            {
                throw new ArgumentException(String.Format(CultureInfo.CurrentCulture, Resources.Resources.StringCannotBeEmpty, argumentName));
            }
        }

        /// <summary>
        /// Checks an argument to ensure it isn't null.
        /// </summary>
        /// <param name="argumentValue">The argument value to check.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public static void ArgumentNotNull(object argumentValue, string argumentName)
        {
            if (argumentValue == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        /// <summary>
        /// Checks an argument to ensure that its value is not the default value for its type.
        /// </summary>
        /// <typeparam name="T">The type of the argument.</typeparam>
        /// <param name="argumentValue">The value of the argument.</param>
        /// <param name="argumentName">The name of the argument for diagnostic purposes.</param>
        /// <exception cref="System.ArgumentException"></exception>
        public static void ArgumentNotDefaultValue<T>(T argumentValue, string argumentName)
        {
            if (!IsValueDefined<T>(argumentValue))
            {
                throw new ArgumentException(String.Format(CultureInfo.CurrentCulture, Resources.Resources.ArgumentCannotBeDefault, argumentName));
            }
        }

        /// <summary>
        /// Checks an argument to ensure that its value is not zero or negative.
        /// </summary>
        /// <typeparam name="T">The type of the argument.</typeparam>
        /// <param name="argumentValue">The value of the argument.</param>
        /// <param name="argumentName">The name of the argument for diagnostic purposes.</param>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public static void ArgumentNotZeroOrNegativeValue<T>(T argumentValue, string argumentName) where T : IComparable<T>
        {
            if (Comparer<T>.Default.Compare(argumentValue, (T)Convert.ChangeType(0, typeof(T), CultureInfo.InvariantCulture)) <= 0)
            {
                throw new ArgumentOutOfRangeException(argumentName, argumentValue, String.Format(CultureInfo.CurrentCulture, Resources.Resources.ArgumentCannotBeZeroOrNegative, argumentName));
            }
        }

        /// <summary>
        /// Checks an argument to ensure that its value is not negative.
        /// </summary>
        /// <typeparam name="T">The type of the argument.</typeparam>
        /// <param name="argumentValue">The value of the argument.</param>
        /// <param name="argumentName">The name of the argument for diagnostic purposes.</param>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public static void ArgumentNotNegativeValue<T>(T argumentValue, string argumentName) where T : IComparable<T>
        {
            if (Comparer<T>.Default.Compare(argumentValue, (T)Convert.ChangeType(0, typeof(T), CultureInfo.InvariantCulture)) < 0)
            {
                throw new ArgumentOutOfRangeException(argumentName, argumentValue, String.Format(CultureInfo.CurrentCulture, Resources.Resources.ArgumentCannotBeNegative, argumentName));
            }
        }

        /// <summary>
        /// Checks if the supplied argument falls into the given range of values.
        /// </summary>
        /// <typeparam name="T">The type of the argument.</typeparam>
        /// <param name="argumentValue">The value of the argument.</param>
        /// <param name="minValue">The minimum allowed value of the argument.</param>
        /// <param name="maxValue">The maximum allowed value of the argument.</param>
        /// <param name="argumentName">The name of the argument for diagnostic purposes.</param>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public static void ArgumentInRange<T>(T argumentValue, T minValue, T maxValue, string argumentName) where T : IComparable<T>
        {
            if (Comparer<T>.Default.Compare(argumentValue, minValue) < 0 || Comparer<T>.Default.Compare(argumentValue, maxValue) > 0)
            {
                throw new ArgumentOutOfRangeException(argumentName, argumentValue, String.Format(CultureInfo.CurrentCulture, Resources.Resources.ArgumentCannotOutOfRange, argumentName, minValue, maxValue));
            }
        }

        /// <summary>
        /// Checks if the supplied argument can be parsed into a DateTime value.
        /// </summary>
        /// <param name="argumentValue">The value of the argument.</param>
        /// <param name="argumentName">The name of the argument for diagnostic purposes.</param>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public static void ArgumentValidDate(string argumentValue, string argumentName)
        {
            ArgumentNotNullOrEmptyString(argumentValue, argumentName);
            DateTime value;

            if (!DateTime.TryParse(argumentValue, out value))
            {
                throw new ArgumentOutOfRangeException(argumentName, argumentValue, String.Format(CultureInfo.CurrentCulture, Resources.Resources.ArgumentCannotBeParsedAsValidDate, argumentName));
            }
        }

        /// <summary>
        /// Arguments the convertible to.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="argumentValue">The argument value.</param>
        /// <param name="argumentName">Name of the argument.</param>
        /// <exception cref="System.ArgumentException">
        /// </exception>
        public static void ArgumentConvertibleTo<T>(string argumentValue, string argumentName)
        {
            ArgumentNotNullOrEmptyString(argumentValue, argumentName);

            try
            {
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
                if (converter != null && converter.CanConvertFrom(argumentValue.GetType()) && converter.IsValid(argumentValue)) return;

                Convert.ChangeType(argumentValue, typeof(T), CultureInfo.InvariantCulture);
                return;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(String.Format(CultureInfo.CurrentCulture, Resources.Resources.ArgumentCannotBeConvertedToSpecificType, argumentName, typeof(T).FullName), ex);
            }

            throw new ArgumentException(String.Format(CultureInfo.CurrentCulture, Resources.Resources.ArgumentCannotBeConvertedToSpecificType, argumentName, typeof(T).FullName));
        }

        #region Private methods
        /// <summary>
        /// Checks the specified value to ensure that its value is defined, i.e. not null and not default value.
        /// </summary>
        /// <typeparam name="T">The type of the value to be checked.</typeparam>
        /// <param name="value">The value to be checked.</param>
        /// <returns>True if the value is defined or false if it's null or represents a default value for its type.</returns>
        private static bool IsValueDefined<T>(T value)
        {
            return typeof(T).IsValueType ? !value.Equals(default(T)) : value != null;
        }
        #endregion
    }
}
