using System;

namespace WarehouseManagementSystem.Core.Exceptions
{
    public class BusinessLogicException : Exception
    {
        public BusinessLogicException(string message) : base(message)
        {
        }

        public static void Throw(string message) => throw new BusinessLogicException(message: message);
        public static void ThrowInsufficientPrivilege() => throw new BusinessLogicException(message: "The user has insufficient privilege to perform this command.");
    }
}