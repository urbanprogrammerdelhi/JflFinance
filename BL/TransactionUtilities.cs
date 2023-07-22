// ***********************************************************************
// Assembly         : BL
// Author           : Administrator
// Created          : 09-13-2013
//
// Last Modified By : Administrator
// Last Modified On : 04-29-2015
// ***********************************************************************
// <copyright file="TransactionUtilities.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Transactions;

/// <summary>
/// The BL namespace.
/// </summary>
namespace BL
{
    /// <summary>
    /// Transcation scop method
    /// </summary>
    [CLSCompliantAttribute(false)]
    public static class TransactionUtility
    {
        /// <summary>
        /// Creates the transaction scope.
        /// </summary>
        /// <returns>TransactionScope.</returns>
        public static TransactionScope CreateTransactionScope()
        {
            var transactionOptions = new TransactionOptions()
            {
                IsolationLevel = IsolationLevel.ReadCommitted,
                Timeout = TimeSpan.MaxValue
            };

            return new TransactionScope(TransactionScopeOption.Required, transactionOptions);
        }
    }
}
