using System;

namespace Backup_Practice
{
    public class DoesnotContainOnlyLettersException : ApplicationException
    {
        private string _message;

        public DoesnotContainOnlyLettersException()
        {
            _message = "Word doesn't contain only letters.";
        }
        public DoesnotContainOnlyLettersException(in string message)
        {
            if (String.IsNullOrWhiteSpace(message))
                _message = "Word doesn't contain only letters.";
            else
            _message = message;
        }

        public override string Message => _message;
    }
}
