// --------------------------------------------------------------------------
// <copyright file="NumberExtensions.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Jason.Ly" date="2014.7.7">Created.</change>
// </history>

namespace India.Agency.Core.Utilities
{
    /// <summary>
    /// Implements extended functions for number types: Integer, Decimal.
    /// </summary>
    public static class NumberExtensions
    {
        private const string IntegerFormat = "{0:#,##0}";
        private const string DecimalFormat = "{0:#,##0.00}";
        private const string Decimal4DigitsFormat = "{0:#,##0.####}";
        private const string DecimalPercentageFormat = "{0:#,##0.00%}";

        /// <summary>
        /// Formats an integer value to a standard form.
        /// </summary>
        /// <param name="value">The value that needs to be formatted.</param>
        /// <returns>Formatted string, such as: 100,000.</returns>
        public static string Format(this int value)
        {
            return string.Format(IntegerFormat, value);
        }

        /// <summary>
        /// Formats an integer value to a standard form.
        /// </summary>
        /// <param name="value">The value that needs to be formatted.</param>
        /// <returns>Formatted string, such as: 100,000.</returns>
        public static string Format(this int? value)
        {
            if (value.HasValue)
            {
                return string.Format(IntegerFormat, value);
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Formats an decimal value to a standard form.
        /// </summary>
        /// <param name="value">The value that needs to be formatted.</param>
        /// <returns>Formatted string, such as: 100,000.20.</returns>
        public static string Format(this decimal value)
        {
            return string.Format(DecimalFormat, value);
        }

        /// <summary>
        /// Formats an decimal value to a standard form.
        /// </summary>
        /// <param name="value">The value that needs to be formatted.</param>
        /// <returns>Formatted string, such as: 100,000.20.</returns>
        public static string Format(this decimal? value)
        {
            if (value.HasValue)
            {
                return string.Format(DecimalFormat, value);
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Formats an decimal value to a standard form with at most 4 digits after the point character.
        /// </summary>
        /// <param name="value">The value that needs to be formatted.</param>
        /// <returns>Formatted string, such as: 100,000.122.</returns>
        public static string Format4Digits(this decimal value)
        {
            return string.Format(Decimal4DigitsFormat, value);
        }

        /// <summary>
        /// Formats an decimal value to a standard form with at most 4 digits after the point character.
        /// </summary>
        /// <param name="value">The value that needs to be formatted.</param>
        /// <returns>Formatted string, such as: 100,000.1234.</returns>
        public static string Format4Digits(this decimal? value)
        {
            if (value.HasValue)
            {
                return string.Format(Decimal4DigitsFormat, value);
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Formats an decimal value to a percentage string.
        /// </summary>
        /// <param name="value">The value that needs to be formatted.</param>
        /// <returns>Formatted string, such as: 20.20%.</returns>
        public static string FormatPercentage(this decimal value)
        {
            return string.Format(DecimalPercentageFormat, value);
        }

        /// <summary>
        /// Formats an decimal value to a percentage string.
        /// </summary>
        /// <param name="value">The value that needs to be formatted.</param>
        /// <returns>Formatted string, such as: 20.20%.</returns>
        public static string FormatPercentage(this decimal? value)
        {
            if (value.HasValue)
            {
                return string.Format(DecimalPercentageFormat, value);
            }
            else
            {
                return string.Empty;
            }
        }
    }
}