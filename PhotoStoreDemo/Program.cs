//*********************************************************
//
// Copyright (c) Microsoft. All rights reserved.
// This code is licensed under the MIT License (MIT).
// THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
// IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
// PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
//
//*********************************************************

// // Copyright (c) Microsoft. All rights reserved.
// // Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

namespace PhotoStoreDemo
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            using (var xamlApp = new Microsoft.Toolkit.Win32.UI.XamlHost.XamlApplication())
            {
                var appOwnedWindowsXamlManager = xamlApp.WindowsXamlManager;

                var app = new App();
                app.InitializeComponent();
                app.Run();
            }
        }
    }
}