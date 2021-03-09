using MediatR;

namespace Step_01_Helloworld
{
    public class Ping : IRequest<Pong>
    {
        public string Message { get; set; }
    }
}
