﻿using System;

namespace NArchitecture
{
    public static class Guard
    {
        public static void AgainstNull(string argumentName, object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }
    }
}
