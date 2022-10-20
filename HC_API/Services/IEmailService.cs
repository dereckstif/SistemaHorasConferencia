using HC_API.Data;

namespace HC_API.Services
{
    public interface IEmailService
    {
        void EnviarEmail(EmailDTO peticion);
    }
}