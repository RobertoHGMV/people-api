using People.Common.Notifications;

namespace People.Domain.ValueObjects
{
    public class Cpf : NotificationContext
    {
        public string Code { get; private set; }

        public Cpf(string code)
        {
            Code = code;

            if (!IsCpf(Code))
                AddNotification("Cpf", "CPF inválido");
        }

        private bool IsCpf(string cpf)
        {
            var multiplier1 = new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplier2 = new[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            cpf = cpf.Trim().Replace(".", "").Replace("-", "");

            if (cpf.Length != 11) return false;

            var haspCpf = cpf.Substring(0, 9);
            var sum = 0;

            for (var i = 0; i < 9; i++)
                sum += int.Parse(haspCpf[i].ToString()) * multiplier1[i];

            var rest = sum % 11;
            rest = rest < 2 ? 0 : 11 - rest;

            var digit = rest.ToString();
            haspCpf = haspCpf + digit;
            sum = 0;

            for (var i = 0; i < 10; i++)
                sum += int.Parse(haspCpf[i].ToString()) * multiplier2[i];

            rest = sum % 11;
            rest = rest < 2 ? 0 : 11 - rest;

            digit += rest;
            return cpf.EndsWith(digit);
        }
    }
}
