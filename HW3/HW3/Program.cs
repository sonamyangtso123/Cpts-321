// Sonam Yangtso
// <copyright file="program.cs" company="wsu">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace HW3
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// main class
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
