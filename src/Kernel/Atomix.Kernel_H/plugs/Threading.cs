﻿/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
* Copyright (c) 2015, Atomix Development, Inc - All Rights Reserved                                        *
*                                                                                                          *
* Unauthorized copying of this file, via any medium is strictly prohibited                                 *
* Proprietary and confidential                                                                             *
* Written by Aman Priyadarshi <aman.eureka@gmail.com>, March 2016                                          *
*                                                                                                          *
*   Namespace     ::  Atomix.Kernel_H.plugs                                                                *
*   File          ::  Threading.cs                                                                         *
*                                                                                                          *
*   Description                                                                                            *
*       File Contains various mscorlib plug belongs to Threading class                                     *
*                                                                                                          *
*   History                                                                                                *
*       24-03-2016      Aman Priyadarshi      Added Methods                                                *
*                                                                                                          *
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using System;

using Atomix.CompilerExt.Attributes;

using Atomix.Assembler.x86;
using Core = Atomix.Assembler.AssemblyHelper;

namespace Atomix.Kernel_H.plugs
{
    public class ThreadingImpl
    {
        [Assembly(0x8), Plug("System_Void_System_Threading_Monitor_Enter_System_Object__System_Boolean__")]
        public static void AcquireLock(object aObj, ref bool aLockTaken)
        {
            Core.AssemblerCode.Add(new Call("AcquireLock", true));
            //we don't carry exception flag from here, although Thread.Exception contains the flag
        }

        [Assembly(0x4), Plug("System_Void_System_Threading_Monitor_Exit_System_Object_")]
        public static void ReleaseLock(object aObj)
        {
            Core.AssemblerCode.Add(new Call("ReleaseLock", true));
            //we don't carry exception flag from here, although Thread.Exception contains the flag
        }
    }
}