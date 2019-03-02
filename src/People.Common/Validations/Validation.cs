using People.Common.Notifications;
using System;

namespace People.Common.Validations
{
    public class Validation : NotificationContext
    {
        public Validation IsNullOrEmpty(string val, string property, string message)
        {
            if (string.IsNullOrEmpty(val))
                AddNotification(property, message);

            return this;
        }

        public Validation HasMinLen(string val, int min, string property, string message)
        {
            if ((val ?? "").Length < min)
                AddNotification(property, message);

            return this;
        }

        public Validation HasMaxLen(string val, int max, string property, string message)
        {
            if ((val ?? "").Length > max)
                AddNotification(property, message);

            return this;
        }

        public Validation IsInvalidValidDate(DateTime val, string property, string message)
        {
            if (val == DateTime.MinValue || val == DateTime.MaxValue)
                AddNotification(property, message);

            return this;
        }

        public Validation AreEquals(int val, int comparer, string property, string message)
        {
            if (val == comparer)
                AddNotification(property, message);

            return this;
        }

        public Validation IsGreater(decimal val, int comparer, string property, string message)
        {
            if ((double)val > comparer)
                AddNotification(property, message);

            return this;
        }
    }
}
