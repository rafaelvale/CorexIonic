using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using YouLearn.Domain.Resource;

namespace YouLearn.Domain.ValueObjects
{
    public class Nome : Notifiable
    {
        public string PrimeiroNome { get; private set; }

        public string UltimoNome { get; private set; }

        
        public Nome(string primeiroNome, string ultimoNome)
        {
            PrimeiroNome = primeiroNome;
            UltimoNome = ultimoNome;
            new AddNotifications<Nome>(this)
                .IfNullOrInvalidLength(x => x.PrimeiroNome, 1, 50, MSG.X0_OBRIGATORIO_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Primeiro Nome", 1, 50))
                .IfNullOrInvalidLength(x => x.UltimoNome, 1, 50, MSG.X0_OBRIGATORIO_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Ultimo Nome", 1, 50));

            //validações
            if (PrimeiroNome.Length < 3 || PrimeiroNome.Length > 50)
            {
                throw new Exception("Primeiro nome é obrigatorio e deve conter entre 3 e 50 caracteres");
            }

            if (UltimoNome.Length < 3 || UltimoNome.Length > 50)
            {
                throw new Exception("Ultimo nome é obrigatorio e deve conter entre 3 e 50 caracteres");
            }
        }
    }
}
