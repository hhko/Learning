using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Step_01_Helloworld
{
    public class PingHandler : IRequestHandler<Ping, Pong>
    {
        public Task<Pong> Handle(Ping request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new Pong { Message = request.Message + " Pong" });
        }
    }
}
