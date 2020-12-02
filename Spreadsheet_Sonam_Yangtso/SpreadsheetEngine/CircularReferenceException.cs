// <copyright file="CircularReferenceException.cs" company="Sonam Yangtso">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// This class throws an  exception if circular reference occurs during the program.
    /// </summary>
    public class CircularReferenceException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CircularReferenceException"/> class.
        /// This is constructor of the class.
        /// </summary>
        public CircularReferenceException()
        {
        }
    }
}
