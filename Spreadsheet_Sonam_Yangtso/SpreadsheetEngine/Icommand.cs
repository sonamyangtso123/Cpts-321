// <copyright file="ICommand.cs" company="Sonam Yangtso">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    /// <summary>
    /// This is a interface class.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// this id Execute method.
        /// </summary>
         void Execute();

        /// <summary>
        /// this is unexecute method.
        /// </summary>
         void UnExecute();
    }
}
