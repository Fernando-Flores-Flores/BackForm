namespace ProyectoCurso.Servicios
{
    public interface IServicio
    {
        void realizarTarea();
    }
    public class ServicioA : IServicio
        {
            private readonly ILogger<ServicioA> _logger;

            public ServicioA(ILogger<ServicioA> logger)
            {
                this._logger = logger;
            }

        public void realizarTarea()
        {
            throw new NotImplementedException();
        }
    }

        public class ServicioB : IServicio
        {
            public void realizarTarea()
            {
                throw new NotImplementedException();
            }
        }
    }

